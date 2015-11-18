using AnsiSoft.Calculator.Model.Analyzer.Lexical.Exceptions;
using NUnit.Framework;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Lexical.Exceptions
{
    [TestFixture]
    public class LexicalParsingExceptionTest
    {
        [Test]
        public void Message_2at4_CantParse2at4()
        {
            var exception = new LexicalParsingException("2@4");
            Assert.That(exception.Message, Is.EqualTo("Can't parse expression 2@4"));
        }

        [Test]
        public void Expression_2at4_2at4()
        {
            var exception = new LexicalParsingException("2@4");
            Assert.That(exception.Expression, Is.EqualTo("2@4"));
        }

    }
}
