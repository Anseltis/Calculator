using System;

namespace AnsiSoft.Calculator.Model.Analyzer.Lexical.Exceptions
{
    /// <summary>
    /// Exception class for wrong lexical rules
    /// This case reveals if don't reduce tail length.
    /// </summary>
    public sealed class WrongLexicalRuleException : Exception
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="WrongLexicalRuleException"/> class.
        /// </summary>
        /// <param name="pattern">Expression pattern</param>
        public WrongLexicalRuleException(string pattern) : base($"Wrong lexical rule {pattern}")
        {
            Pattern = pattern;
        }

        /// <summary>
        /// regular expression of lexical rule
        /// </summary>
        public string Pattern { get; }

    }
}
