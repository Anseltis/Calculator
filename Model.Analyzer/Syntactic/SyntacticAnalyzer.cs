using System;
using System.Collections.Generic;
using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Blocks;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Exceptions;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic
{
    /// <summary>
    /// Class for syntactic parsing of token sequence
    /// </summary>
    public sealed class SyntacticAnalyzer : ISyntacticAnalyzer
    {
        #region implement ISyntacticAnalyzer

        /// <summary>
        /// Rules of context-free grammar
        /// </summary>
        public IEnumerable<IBlock> Rules { get; }

        /// <summary>
        /// Syntactic parse token sequence.
        /// </summary>
        /// <param name="target">Target non-terminal symbol of parsing</param>
        /// <param name="tokens">Input token sequence</param>
        /// <returns>Root node of syntactic tree</returns>
        /// <exception cref="SyntacticParseException">Expression doesn't pass syntactic analyzer</exception>
        public ISyntacticNode Parse(IEnumerable<IToken> tokens, ISyntacticNodeType target)
        {
            var tokenNodes = tokens
                .Select(token => new TokenSyntacticNode(token))
                .ToList();
            var node = target.Parse(tokenNodes, this)
                .Where(result => !result.TokenNodes.Any())
                .Select(result => result.Node)
                .FirstOrDefault();

            if (node == null)
            {
                var expression = string.Join("", tokens.Select(token => token.ToString()));
                throw new SyntacticParseException(expression);
            }
            return node;
        }

        /// <summary>
        /// Iterate of parsing for the rule.
        /// </summary>
        /// <param name="iterate">Current iterate</param>
        /// <returns>Next iterate</returns>
        public IEnumerable<SyntacticParseIterateResult> Parse(SyntacticParseIterateResult iterate)
        {
            if (!iterate.NodeTypes.Any())
            {
                return Enumerable.Repeat(iterate, 1);
            }

            var nodeType = iterate.NodeTypes.First();
            return nodeType.Parse(iterate.TokenNodes, this)
                .Select(res => new SyntacticParseIterateResult(
                    iterate.Nodes.Concat(Enumerable.Repeat(res.Node, 1)),
                    iterate.NodeTypes.Skip(1), res.TokenNodes))
                .SelectMany(it => Parse(it));
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SyntacticAnalyzer"/> class.
        /// </summary>
        /// <param name="rules">Rules of context-free grammar</param>
        public SyntacticAnalyzer(IEnumerable<IBlock> rules)
        {
            Rules = rules;
        }
    }
}
