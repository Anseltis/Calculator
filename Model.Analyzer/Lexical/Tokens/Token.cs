namespace AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens
{
    /// <summary>
    /// Base implementation of token
    /// </summary>
    public abstract class Token : IToken
    {
        #region implement IToken
        public string Lexeme { get; }
        public string LeftTrivia { get; }
        public string RightTrivia { get; }
        #endregion
        public override string ToString() => LeftTrivia + Lexeme + RightTrivia;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Token"/> class.
        /// </summary>
        /// <param name="builder">Token builder</param>
        protected Token(TokenBuilder builder)
        {
            Lexeme = builder.Lexeme;
            LeftTrivia = builder.LeftTrivia;
            RightTrivia = builder.RightTrivia;
        }
    }

}
