using System.Collections.Generic;
using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes
{
    /// <summary>
    /// Class for terminal block of synactic analyzer's parsing result (tokens)
    /// </summary>
    public sealed class TokenSyntacticNode : ISyntacticNode
    {
        #region implement ISyntacticNode
        public IEnumerable<ISyntacticNode> Nodes => 
            Enumerable.Empty<ISyntacticNode>();
        public ISyntacticNode Rewrite(IEnumerable<ISyntacticNode> nodes) => this;
        #endregion

        /// <summary>
        /// Token from source token sequence
        /// </summary>
        public IToken Token { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenSyntacticNode"/> class.
        /// </summary>
        /// <param name="token">Token from source token sequence</param>
        public TokenSyntacticNode(IToken token)
        {
            Token = token;
        }
    }
}
