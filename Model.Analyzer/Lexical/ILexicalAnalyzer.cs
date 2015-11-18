using System.Collections.Generic;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;

namespace AnsiSoft.Calculator.Model.Analyzer.Lexical
{
    /// <summary>
    /// Interface for lexical parsing of string expression
    /// </summary>
    public interface ILexicalAnalyzer
    {
        /// <summary>
        /// Compilated lexical rules
        /// </summary>
        IEnumerable<CompiledLexicalRule> Rules { get; }

        /// <summary>
        /// Parse input expression sting into token list.
        /// </summary>
        /// <param name="text">Input expression string</param>
        /// <returns>List of tokens</returns>
        IEnumerable<IToken> Parse(string text);
    }
}