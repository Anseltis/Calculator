namespace AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens
{
    /// <summary>
    /// Token class for number
    /// </summary>
    public sealed class NumberToken : Token
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="NumberToken"/> class.
        /// </summary>
        /// <param name="builder">Token builder</param>
        public NumberToken(TokenBuilder builder) : base(builder)
        {
        }
    }
}
