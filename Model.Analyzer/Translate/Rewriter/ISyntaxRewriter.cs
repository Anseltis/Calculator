using System.Collections.Generic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;

namespace AnsiSoft.Calculator.Model.Analyzer.Translate.Rewriter
{
    /// <summary>
    /// Interfave for modify syntactic tree by immutable-style
    /// </summary>
    public interface ISyntaxRewriter
    {
        /// <summary>
        /// Filter node for visit.
        /// </summary>
        /// <param name="node">Current node</param>
        /// <returns>True if visitor must visit this node</returns>
        bool Filter(ISyntacticNode node);

        /// <summary>
        /// Rewrite visited node.
        /// </summary>
        /// <param name="node">Current node</param>
        /// <param name="children">Rewritten chilren node</param>
        /// <returns>Rewritten node</returns>
        ISyntacticNode Visit(ISyntacticNode node, IEnumerable<ISyntacticNode> children);
    }
}
