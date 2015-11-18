using System;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;

namespace AnsiSoft.Calculator.Model.Analyzer.Lexical
{
    /// <summary>
    /// Class for rules for lexiacl analyzer
    /// </summary>
    public sealed class LexicalRule : ILexicalRule
    {
        #region implement ILexicalRule
        public string Pattern { get; }
        public Func<TokenBuilder, IToken> TokenFactory { get; }
        #endregion

        /// <summary>
        ///  Initializes a new instance of the <see cref="LexicalRule"/> class.
        /// </summary>
        /// <param name="pattern">Regular expression for retrieve token</param>
        /// <param name="factory">Factory for create token</param>
        public LexicalRule(string pattern, Func<TokenBuilder, IToken> factory)
        {
            Pattern = pattern;
            TokenFactory = factory;
        }
    }
}
