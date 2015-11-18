using System.Collections.Generic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes
{
    /// <summary>
    /// Interface for elements of syntactic rules
    /// </summary>
    /// Implement Union Type Pattern
    public interface ISyntacticNodeType
    {
        /// <summary>
        /// Syntactic parse current element of syntactic rules
        /// </summary>
        /// <param name="tokenNodes">Token nodes tail</param>
        /// <param name="analyzer">Sysntactic analyzer</param>
        /// <returns></returns>
        IEnumerable<SyntacticParseResult> Parse(IEnumerable<TokenSyntacticNode> tokenNodes, ISyntacticAnalyzer analyzer);
    }
}
