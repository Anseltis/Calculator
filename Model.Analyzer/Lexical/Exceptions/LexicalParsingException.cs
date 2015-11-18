using System;

namespace AnsiSoft.Calculator.Model.Analyzer.Lexical.Exceptions
{
    /// <summary>
    /// Exception class for wrong leical parsing of expression
    /// This case reveals if expression doesn't pass lexical analyzer
    /// </summary>
    public sealed class LexicalParsingException : Exception
    {
        /// <summary>
        /// Wrog exprexxion which doesn't pass lexical analyzer
        /// </summary>
        public string Expression { get; }

        /// <summary>
        ///  Initializes a new instance of the <see cref="LexicalParsingException"/> class.
        /// </summary>
        /// <param name="expression">Wrong expression</param>
        public LexicalParsingException(string expression) :
            base($"Can't parse expression {expression}")
        {
            Expression = expression;
        }

    }
}
