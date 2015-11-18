using System;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;

namespace AnsiSoft.Calculator.Model.Analyzer.Lexical
{
    /// <summary>
    /// Interface for rules for lexiacl analyzer
    /// </summary>
    public interface ILexicalRule
    {
        /// <summary>
        /// Regular expression for retrieve token
        /// Expression contain four section: left trivia (l), lexeme (t), right trivia (r) and tail (e)
        /// </summary>
        string Pattern { get; }

        /// <summary>
        /// Factory for create token
        /// </summary>
        Func<TokenBuilder, IToken> TokenFactory { get; }
    }
}