namespace AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens
{
    /// <summary>
    /// Minimal unit of lexical meaning 
    /// </summary>
    public interface IToken
    {
        /// <summary>
        /// Lexeme text
        /// </summary>
        string Lexeme { get; }

        /// <summary>
        /// Space symbols before token
        /// </summary>
        string LeftTrivia { get; }

        /// <summary>
        /// Space symbols after token
        /// </summary>
        string RightTrivia { get; }
    }
}