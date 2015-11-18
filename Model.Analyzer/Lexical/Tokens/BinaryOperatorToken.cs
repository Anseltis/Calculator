namespace AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens
{
    /// <summary>
    /// Token class for binary operator
    /// </summary>
    public sealed class BinaryOperatorToken : Token
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="BinaryOperatorToken"/> class.
        /// </summary>
        /// <param name="builder">Token builder</param>
        public BinaryOperatorToken(TokenBuilder builder) : base(builder)
        {
        }
    }
}
