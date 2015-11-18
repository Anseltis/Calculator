using System.Collections.Generic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Blocks;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes
{
    /// <summary>
    /// Class for non-terminal block of synactic analyzer's parsing result
    /// </summary>
    public sealed class BlockSyntacticNode : ISyntacticNode
    {
        #region implement ISyntacticNode
        public IEnumerable<ISyntacticNode> Nodes { get; }
        public ISyntacticNode Rewrite(IEnumerable<ISyntacticNode> nodes) => 
            new BlockSyntacticNode(Block, nodes);
        #endregion

        /// <summary>
        /// Block of context-free grammar
        /// </summary>
        public IBlock Block { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockSyntacticNode"/> class.
        /// </summary>
        /// <param name="block">Block of context-free grammar</param>
        /// <param name="nodes">Descendant nodes</param>
        public BlockSyntacticNode(IBlock block, IEnumerable<ISyntacticNode> nodes)
        {
            Block = block;
            Nodes = nodes;
        }
    }
}
