using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using NUnit.Framework;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Lexical.Tokens
{
    [TestFixture]
    public class TokenTest
    {
        /// <summary>
        /// Stub for abstract token class
        /// </summary>
        private sealed class TokenStub : Token
        {
            /// <summary>
            ///  Initializes a new instance of the <see cref="TokenStub"/> class.
            /// </summary>
            /// <param name="builder">Token builder</param>
            public TokenStub(TokenBuilder builder) : base(builder)
            {
            }
        }

        [Test, Description("When Xp with trivia Ua and Bu Then Lexeme is Xp, left is Ua, right is Bu")]
        public void LexemeAndTrivia_UaAndXpAndBu_UaAndXpAndBu()
        {
            var tokenBuilder = new TokenBuilder {Lexeme = "Xp", LeftTrivia = "Ua", RightTrivia = "Bu"};
            var lexeme = new TokenStub(tokenBuilder);

            Assert.That(lexeme.Lexeme, Is.EqualTo("Xp"));
            Assert.That(lexeme.LeftTrivia, Is.EqualTo("Ua"));
            Assert.That(lexeme.RightTrivia, Is.EqualTo("Bu"));
        }

        [Test, Description("When Xp with trivia Ua and Bu Then UaXpBu")]
        public void ToString_UaAndXpAndBu_UaXpBu()
        {
            var tokenBuilder = new TokenBuilder { Lexeme = "Xp", LeftTrivia = "Ua", RightTrivia = "Bu" };
            var lexeme = new TokenStub(tokenBuilder);
            Assert.That(lexeme.ToString(), Is.EqualTo("UaXpBu"));
        }
    }
}
