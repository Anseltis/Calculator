using System.Collections.Generic;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Blocks;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic
{
    /// <summary>
    /// Interface for syntactic parsing of token sequence
    /// </summary>
    public interface ISyntacticAnalyzer
    {
        /// <summary>
        /// Rules of context-free grammar
        /// </summary>
        IEnumerable<IBlock> Rules { get; }

        /// <summary>
        /// Syntactic parse token sequence.
        /// </summary>
        /// <param name="target">Target non-terminal symbol of parsing</param>
        /// <param name="tokens">Input token sequence</param>
        /// <returns>Root node of syntactic tree</returns>
        ISyntacticNode Parse(IEnumerable<IToken> tokens, ISyntacticNodeType target);

        /// <summary>
        /// Iterate of parsing for the rule.
        /// </summary>
        /// <param name="iterate">Current iterate</param>
        /// <returns>Next iterate</returns>
        IEnumerable<SyntacticParseIterateResult> Parse(SyntacticParseIterateResult iterate);
    }
}
