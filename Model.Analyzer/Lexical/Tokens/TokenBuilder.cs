namespace AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens
{
    /// <summary>
    /// Builder class for create token class
    /// </summary>
    public sealed class TokenBuilder
    {
        /// <summary>
        /// Lexeme text
        /// </summary>
        public string Lexeme { get; set; } = "";

        /// <summary>
        /// Space symbols before token
        /// </summary>
        public string LeftTrivia { get; set; } = "";

        /// <summary>
        /// Space symbols after token
        /// </summary>
        public string RightTrivia { get; set; } = "";
    }
}
