namespace AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens
{
    /// <summary>
    /// Token class for left bracket
    /// </summary>
    public sealed class LeftBracketToken : Token
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="LeftBracketToken"/> class.
        /// </summary>
        /// <param name="builder">Token builder</param>
        public LeftBracketToken(TokenBuilder builder) : base(builder)
        {
        }
    }
}
