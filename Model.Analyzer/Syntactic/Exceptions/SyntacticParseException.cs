using System;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic.Exceptions
{
    /// <summary>
    /// Exception class for wrong syntactic parsing of expression
    /// This case reveals if expression doesn't pass syntactic analyzer
    /// </summary>
    public sealed class SyntacticParseException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SyntacticParseException"/> class.
        /// </summary>
        /// <param name="expression"></param>
        public SyntacticParseException(string expression) : base($"Syntactic error in <<{expression}>>")
        {
        }
    }
}
