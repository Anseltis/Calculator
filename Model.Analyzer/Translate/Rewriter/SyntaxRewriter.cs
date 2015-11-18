using System;
using System.Collections.Generic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;

namespace AnsiSoft.Calculator.Model.Analyzer.Translate.Rewriter
{
    /// <summary>
    /// Record class for syntactic tree translation 
    /// </summary>
    public sealed class SyntaxRewriter : ISyntaxRewriter
    {
        #region implement ISyntaxRewriter
        public bool Filter(ISyntacticNode node) => FilterPredicate(node);
        public ISyntacticNode Visit(ISyntacticNode node, IEnumerable<ISyntacticNode> children) =>
            Visitor(node, children);
        #endregion

        /// <summary>
        /// Filter predicate for filtering of nodes
        /// </summary>
        private Func<ISyntacticNode, bool> FilterPredicate { get; }

        /// <summary>
        /// Visitor delegate for node rewriting
        /// </summary>
        private Func<ISyntacticNode, IEnumerable<ISyntacticNode>, ISyntacticNode> Visitor { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SyntaxRewriter"/> class.
        /// </summary>
        /// <param name="filterPredicate">Filter predicate</param>
        /// <param name="visitor">Visitor delegate for node rewriting</param>
        public SyntaxRewriter(Func<ISyntacticNode, bool> filterPredicate,
            Func<ISyntacticNode, IEnumerable<ISyntacticNode>, ISyntacticNode> visitor)
        {
            FilterPredicate = filterPredicate;
            Visitor = visitor;
        }
    }
}
