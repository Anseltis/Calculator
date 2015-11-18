using System.Collections.Generic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic
{
    /// <summary>
    /// Class for storage iterate data of sysntact parse
    /// </summary>
    public sealed class SyntacticParseIterateResult
    {

        /// <summary>
        /// Result nodes for read element of syntactic rules 
        /// </summary>
        public IEnumerable<ISyntacticNode> Nodes { get; }

        /// <summary>
        /// Non-read element of syntactic rules
        /// </summary>
        public IEnumerable<ISyntacticNodeType> NodeTypes { get; }

        /// <summary>
        /// Non-read token sequence
        /// </summary>
        public IEnumerable<TokenSyntacticNode> TokenNodes { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SyntacticParseIterateResult"/> class.
        /// </summary>
        /// <param name="nodes">Result nodes for read element of syntactic rules</param>
        /// <param name="nodeTypes">Non-read element of syntactic rules</param>
        /// <param name="tokenNodes">Non-read token sequence</param>
        public SyntacticParseIterateResult(IEnumerable<ISyntacticNode> nodes,
            IEnumerable<ISyntacticNodeType> nodeTypes, IEnumerable<TokenSyntacticNode> tokenNodes)
        {
            Nodes = nodes;
            NodeTypes = nodeTypes;
            TokenNodes = tokenNodes;
        }

    }
}
