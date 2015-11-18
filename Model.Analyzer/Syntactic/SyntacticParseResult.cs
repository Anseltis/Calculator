using System.Collections.Generic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic
{
    /// <summary>
    /// Class for storage data of sysntact parse
    /// </summary>
    public sealed class SyntacticParseResult
    {
        /// <summary>
        /// Syntactic node
        /// </summary>
        public ISyntacticNode Node { get;  }

        /// <summary>
        /// Non-read token sequence
        /// </summary>
        public IEnumerable<TokenSyntacticNode> TokenNodes { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SyntacticParseResult"/> class.
        /// </summary>
        /// <param name="node">Syntactic node</param>
        /// <param name="tokenNodes">Non-read token sequence</param>
        public SyntacticParseResult(ISyntacticNode node, IEnumerable<TokenSyntacticNode> tokenNodes)
        {
            Node = node;
            TokenNodes = tokenNodes;
        }
    }


}
