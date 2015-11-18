using System.Collections.Generic;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes
{
    /// <summary>
    /// Interface for node of syntactic tree
    /// </summary>
    public interface ISyntacticNode
    {
        /// <summary>
        /// Descendant nodes
        /// </summary>
        /// Empty enumerable for leaf
        IEnumerable<ISyntacticNode> Nodes { get; }

        /// <summary>
        /// Rewrite syntactic tree's node 
        /// </summary>
        /// <param name="nodes">Descendant nodes</param>
        /// <returns>Rewritten node</returns>
        ISyntacticNode Rewrite(IEnumerable<ISyntacticNode> nodes);
    }
}
