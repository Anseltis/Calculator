using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Lexical;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Blocks;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Exceptions;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes;
using AnsiSoft.Calculator.Model.Analyzer.Translate.Exceptions;
using AnsiSoft.Calculator.Model.Analyzer.Translate.Operators;
using AnsiSoft.Calculator.Model.Analyzer.Translate.Rewriter;
using AnsiSoft.Calculator.Model.Analyzer.Translate.Terms;
using static AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes.SyntacticNodeTypeHelper;

namespace AnsiSoft.Calculator.Model.Analyzer.Facade
{
    public class AnalyzerFacade
    {
        /// <summary>
        /// Standard rules for lexical parsing
        /// </summary>
        /// Identifier = /[_a-zA-Z][_a-zA-Z0-9]{0,30}/
        /// Number = /[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?/
        /// LeftBracket = /[\(]/
        /// RightBracket = /[\)]/
        /// Separator = /[,]/
        /// Operator = /[+-]/
        /// BinaryOperator = /[\*/]/
        public static IEnumerable<ILexicalRule> LexicalRules { get; } =
            new[]
            {
                new LexicalRule(
                    @"^(?<l>\s*)(?<t>[_a-zA-Z][_a-zA-Z0-9]{0,30})((?<e>([^_a-zA-Z0-9\s]|\s*\S)[\s\S]*$)|(?<r>\s*$))",
                    builder => new IdentifierToken(builder)),
                new LexicalRule(
                    @"^(?<l>\s*)(?<t>[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)((?<e>([^0-9]|\s*\S)[\s\S]*$)|(?<r>\s*$))",
                    builder => new NumberToken(builder)),
                new LexicalRule(
                    @"^(?<l>\s*)(?<t>[\(])((?<e>[\s\S]*\S[\s\S]*$)|(?<r>\s*$))",
                    builder => new LeftBracketToken(builder)),
                new LexicalRule(
                    @"^(?<l>\s*)(?<t>[\)])((?<e>[\s\S]*\S[\s\S]*$)|(?<r>\s*$))",
                    builder => new RightBracketToken(builder)),
                new LexicalRule(
                    @"^(?<l>\s*)(?<t>[,])((?<e>[\s\S]*\S[\s\S]*$)|(?<r>\s*$))",
                    builder => new SeparatorToken(builder)),
                new LexicalRule(
                    @"^(?<l>\s*)(?<t>[+-])((?<e>[\s\S]*\S[\s\S]*$)|(?<r>\s*$))",
                    builder => new OperatorToken(builder)),
                new LexicalRule(
                    @"^(?<l>\s*)(?<t>[\*/])((?<e>[\s\S]*\S[\s\S]*$)|(?<r>\s*$))",
                    builder => new BinaryOperatorToken(builder))
            };


        public enum SyntacticRuleType
        {
            ExprIsProductExpr,
            ExprIsProductExprAndBOpAndExpr,
            ProductExprIsUnaryExpr,
            ProductExprIsUnaryExprAndOpAndProductExpr,
            UnaryExprIsIdentifier,
            UnaryExprIsNumber,
            UnaryExprIsLBrAndExprAndRBr,
            UnaryExprIsOperatorAndUnaryExpr,
            UnaryExprIsIdentifierAndLBrAndTuppleAndRBr,
            TuppleIsExpr,
            TuppleIsExprAndSeparatorAndTupple,
        }

        /// <summary>
        /// Standard rules for syntactic parsing
        /// </summary>
        /// Expression = ProductExpression
        /// Expression = ProductExpression BinaryOperator Expression
        /// ProductExpression = UnaryExpression
        /// ProductExpression = UnaryExpression Operator ProductExpression
        /// UnaryExpression = Identifier
        /// UnaryExpression = Number
        /// UnaryExpression = LeftBracket Expression RightBracket
        /// UnaryExpression = Operator UnaryExpression
        /// UnaryExpression = Identifier LeftBracket Tupple RightBracket
        /// Tupple = Expression
        /// Tupple = Expression Separator Tupple
        public static IEnumerable<IBlock> SyntacticRules { get; } =
            new IBlock[]
            {
                new ExpressionBlock(
                    nameof(SyntacticRuleType.ExprIsProductExpr),
                    new ISyntacticNodeType[]
                    {
                        BlockOf<ProductExpressionBlock>()
                    }),
                new ExpressionBlock(
                    nameof(SyntacticRuleType.ExprIsProductExprAndBOpAndExpr),
                    new ISyntacticNodeType[]
                    {
                        BlockOf<ProductExpressionBlock>(), TokenOf<OperatorToken>(), BlockOf<ExpressionBlock>()
                    }),
                new ProductExpressionBlock(
                    nameof(SyntacticRuleType.ProductExprIsUnaryExpr),
                    new ISyntacticNodeType[]
                    {
                        BlockOf<UnaryExpressionBlock>()
                    }), 
                new ProductExpressionBlock(
                    nameof(SyntacticRuleType.ProductExprIsUnaryExprAndOpAndProductExpr),
                    new ISyntacticNodeType[]
                    {
                        BlockOf<UnaryExpressionBlock>(), TokenOf<BinaryOperatorToken>(), BlockOf<ProductExpressionBlock>()
                    }), 
                new UnaryExpressionBlock(
                    nameof(SyntacticRuleType.UnaryExprIsIdentifier),
                    new ISyntacticNodeType[]
                    {
                        TokenOf<IdentifierToken>()
                    }),
                new UnaryExpressionBlock(
                    nameof(SyntacticRuleType.UnaryExprIsNumber),
                    new ISyntacticNodeType[]
                    {
                        TokenOf<NumberToken>()
                    }),
                new UnaryExpressionBlock(
                    nameof(SyntacticRuleType.UnaryExprIsLBrAndExprAndRBr),
                    new ISyntacticNodeType[]
                    {
                        TokenOf<LeftBracketToken>(), BlockOf<ExpressionBlock>(), TokenOf<RightBracketToken>(),
                    }),
                new UnaryExpressionBlock(
                    nameof(SyntacticRuleType.UnaryExprIsOperatorAndUnaryExpr),
                    new ISyntacticNodeType[]
                    {
                        TokenOf<OperatorToken>(), BlockOf<UnaryExpressionBlock>()
                    }),
                new UnaryExpressionBlock(
                    nameof(SyntacticRuleType.UnaryExprIsIdentifierAndLBrAndTuppleAndRBr),
                    new ISyntacticNodeType[]
                    {
                        TokenOf<IdentifierToken>(),
                        TokenOf<LeftBracketToken>(), BlockOf<TuppleBlock>(), TokenOf<RightBracketToken>(),
                    }),
                new TuppleBlock(
                    nameof(SyntacticRuleType.TuppleIsExpr),
                    new ISyntacticNodeType[]
                    {
                        BlockOf<ExpressionBlock>()
                    }),
                new TuppleBlock(
                    nameof(SyntacticRuleType.TuppleIsExprAndSeparatorAndTupple),
                    new ISyntacticNodeType[]
                    {
                        BlockOf<ExpressionBlock>(), TokenOf<SeparatorToken>(), BlockOf<TuppleBlock>()
                    })
            };



        /// <summary>
        /// Standard rules for trnslation
        /// </summary>
        public static IEnumerable<ISyntaxRewriter> TranslateRules { get; } =
            new ISyntaxRewriter[]
            {
                new SyntaxRewriter(
                    node => node.IsBlockOf(nameof(SyntacticRuleType.TuppleIsExprAndSeparatorAndTupple)),
                    (node, children) =>
                    {
                        var blockNode = (BlockSyntacticNode) node;
                        return new BlockSyntacticNode(
                            blockNode.Block,
                            children.Take(1).Concat(children.Last().Nodes));
                    }),
                new SyntaxRewriter(
                    node => node.IsBlockOf(nameof(SyntacticRuleType.UnaryExprIsLBrAndExprAndRBr)),
                    (node, children) => children.Skip(1).First()),
                new SyntaxRewriter(
                    node => node.IsBlockOf(nameof(SyntacticRuleType.ExprIsProductExpr)),
                    (node, children) => children.First()),
                new SyntaxRewriter(
                    node => node.IsBlockOf(nameof(SyntacticRuleType.ProductExprIsUnaryExpr)),
                    (node, children) => children.First()),
                new SyntaxRewriter(
                    node => node.IsBlockOf(nameof(SyntacticRuleType.UnaryExprIsIdentifierAndLBrAndTuppleAndRBr)),
                    (node, children) =>
                    {
                        var blockNode = (BlockSyntacticNode) node;
                        return new BlockSyntacticNode(
                            blockNode.Block,
                            children.Take(1).Concat(children.Skip(2).Take(1)));
                    }),
                new SyntaxRewriter(
                    node => node.IsBlockOf<ProductExpressionBlock>() &&
                            node.Nodes.Last().IsBlockOf<ProductExpressionBlock>(),
                    (node, children) => node.Rewrite(children.Take(2).Concat(children.Last().Nodes))),
                new SyntaxRewriter(
                    node => node.IsBlockOf<ExpressionBlock>() &&
                            node.Nodes.Last().IsBlockOf<ExpressionBlock>(),
                    (node, children) => node.Rewrite(children.Take(2).Concat(children.Last().Nodes))),
                new SyntaxRewriter(node => node is BlockSyntacticNode,
                    (node, children) =>
                    {
                        if (node.IsBlockOf<UnaryExpressionBlock>())
                        {
                            var tokenNode = (TokenSyntacticNode) children.First();
                            if (node.IsBlockOf(nameof(SyntacticRuleType.UnaryExprIsIdentifier)))
                            {
                                var term = new IdentifierTerm(tokenNode.Token.Lexeme);
                                return new TermSyntacticNode(term, Enumerable.Empty<ISyntacticNode>());
                            }
                            if (node.IsBlockOf(nameof(SyntacticRuleType.UnaryExprIsNumber)))
                            {
                                try
                                {
                                    var term =
                                        new NumberTerm(double.Parse(tokenNode.Token.Lexeme, CultureInfo.InvariantCulture));
                                    return new TermSyntacticNode(term, Enumerable.Empty<ISyntacticNode>());
                                }
                                catch (OverflowException)
                                {
                                    throw new DoubleParseException();
                                }
                            }
                            if (node.IsBlockOf(nameof(SyntacticRuleType.UnaryExprIsIdentifierAndLBrAndTuppleAndRBr)))
                            {
                                var term = new FunctionTerm(tokenNode.Token.Lexeme);
                                return new TermSyntacticNode(term, children.Last().Nodes);
                            }
                            if (node.IsBlockOf(nameof(SyntacticRuleType.UnaryExprIsOperatorAndUnaryExpr)))
                            {
                                var operators = new Dictionary<string, IUnaryOperator>
                                {
                                    ["+"] = new UnaryPlusOperator(),
                                    ["-"] = new UnaryMinusOperator()
                                };
                                var term = new UnaryOperatorTerm(operators[tokenNode.Token.Lexeme]);
                                return new TermSyntacticNode(term, Enumerable.Repeat(children.Last(), 1));
                            }
                        }
                        if (node.IsBlockOf<ProductExpressionBlock>() || node.IsBlockOf<ExpressionBlock>())
                        {
                            return children.ToLeftAssociationTree(
                                new Dictionary<string, IBinaryOperator>
                                {
                                    ["+"] = new PlusOperator(),
                                    ["-"] = new MinusOperator(),
                                    ["*"] = new MultiplicationOperator(),
                                    ["/"] = new DivisionOperator()
                                });
                        }
                        return node.Rewrite(children);
                    })
            };

    }
}
  