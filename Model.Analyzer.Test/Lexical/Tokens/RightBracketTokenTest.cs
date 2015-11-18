using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using NUnit.Framework;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Lexical.Tokens
{
    [TestFixture]
    public class RightBracketTokenTest
    {
        [Test, Description("Check error under constructor")]
        public void Constructor_Do_DoesNotThrow()
        {
            var builder = new TokenBuilder();
            Assert.DoesNotThrow(() => new RightBracketToken(builder));
        }

    }
}
