using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using NUnit.Framework;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Lexical.Tokens
{
    [TestFixture]
    public class OperatorTokenTest
    {
        [Test, Description("Check error under the constructor")]
        public void Constructor_Do_DoesNotThrow()
        {
            var builder = new TokenBuilder();
            Assert.DoesNotThrow(() => new OperatorToken(builder));
        }

    }
}
