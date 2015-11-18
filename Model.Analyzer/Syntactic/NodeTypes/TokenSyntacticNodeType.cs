using System.Collections.Generic;
using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes
{
    /// <summary>
    /// Class for terminal symbol of context-free grammar
    /// </summary>
    /// <typeparam name="T">Lexical token</typeparam>
    public sealed class TokenSyntacticNodeType<T> : ISyntacticNodeType where T : IToken
    {
        #region implement ISyntacticNodeType
        public IEnumerable<SyntacticParseResult> Parse(IEnumerable<TokenSyntacticNode> tokenNodes, ISyntacticAnalyzer analyzer)
        {
            if (tokenNodes.Any())
            {
                var tokenNode = tokenNodes.First();
                if (tokenNode.Token is T)
                {
                    yield return new SyntacticParseResult(tokenNodes.First(), tokenNodes.Skip(1));
                }
            }
        }
        #endregion
    }
}
