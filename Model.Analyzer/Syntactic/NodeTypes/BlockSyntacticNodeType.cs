using System.Collections.Generic;
using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Blocks;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes
{
    /// <summary>
    /// Class for non-terminal symbol of context-free grammar
    /// </summary>
    /// <typeparam name="T">Syntactic block</typeparam>
    public sealed class BlockSyntacticNodeType<T> : ISyntacticNodeType where T : IBlock
    {
        #region implement ISyntacticNodeType

        public IEnumerable<SyntacticParseResult> Parse(IEnumerable<TokenSyntacticNode> tokenNodes,
            ISyntacticAnalyzer analyzer)
        {
            return analyzer.Rules
                .OfType<T>()
                .Where(block => block.Rule.Any())
                .Select(
                    block =>
                        new
                        {
                            Block = block,
                            Iterate =
                                new SyntacticParseIterateResult(
                                    Enumerable.Empty<ISyntacticNode>(),
                                    block.Rule, tokenNodes)
                        })
                .SelectMany(
                    rec => analyzer.Parse(rec.Iterate)
                        .Select(iterate => new { Block = rec.Block, Iterate = iterate}))
                .Select(
                    rec =>
                        new SyntacticParseResult(
                            new BlockSyntacticNode(rec.Block, rec.Iterate.Nodes),
                            rec.Iterate.TokenNodes));
        }

        #endregion
    }
}
