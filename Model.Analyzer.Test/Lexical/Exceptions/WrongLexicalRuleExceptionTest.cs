using AnsiSoft.Calculator.Model.Analyzer.Lexical.Exceptions;
using NUnit.Framework;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Lexical.Exceptions
{
    [TestFixture]
    public class WrongLexicalRuleExceptionTest
    {
        [Test]
        public void Message_2at4_WrongLexical2at4()
        {
            var exception = new WrongLexicalRuleException("2@4");
            Assert.That(exception.Message, Is.EqualTo("Wrong lexical rule 2@4"));
        }

        [Test]
        public void Pattern_2at4_2at4()
        {
            var exception = new WrongLexicalRuleException("2@4");
            Assert.That(exception.Pattern, Is.EqualTo("2@4"));
        }

    }
}
