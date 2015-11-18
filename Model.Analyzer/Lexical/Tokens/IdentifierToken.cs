namespace AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens
{
    /// <summary>
    /// Token class for identifier
    /// </summary>
    public sealed class IdentifierToken : Token
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="IdentifierToken"/> class.
        /// </summary>
        /// <param name="builder">Token builder</param>
        public IdentifierToken(TokenBuilder builder) : base(builder)
        {
        }
    }
}
