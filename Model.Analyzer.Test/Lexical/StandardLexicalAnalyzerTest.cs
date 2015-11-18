using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Facade;
using AnsiSoft.Calculator.Model.Analyzer.Lexical;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Exceptions;
using NUnit.Framework;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Lexical
{
    [TestFixture]
    public class StandardLexicalAnalyzerTest
    {
        private LexicalAnalyzer Analyzer { get; set; }

        [SetUp]
        public void SetUp()
        {
            Analyzer = new LexicalAnalyzer(AnalyzerFacade.LexicalRules);
        }

        [Test]
        [TestCase(@"1+2")]
        [TestCase(@"1-2*4")]
        [TestCase(@"1-2*4*")]
        [TestCase(@"1-2*4* ")]
        [TestCase(@"1-2*4*(2-4)")]
        [TestCase(@"1/2")]
        [TestCase(@"func")]
        [TestCase(@"(")]
        [TestCase(@"func (")]
        [TestCase(@"func(")]
        [TestCase(@"func(1,3)")]
        [TestCase(@"1*func(1,3)")]
        [TestCase(@"-6 * 2e-8  / (1+f)")]
        [TestCase(@"-6.3 * 2e-8  / (((1+f)")]
        public void Parse_ValidLexicalExpression_DoesNotThrow(string text)
        {
            Assert.DoesNotThrow(() => Analyzer.Parse(text));
        }

        [Test]
        [TestCase(@"1+%2")]
        [TestCase(@"1 + 2..7")]
        [ExpectedException(typeof (LexicalParsingException))]
        public void Parse_InValidLexicalExpression_Throw(string text)
        {
            Analyzer.Parse(text);
        }

        [Test]
        [TestCase(@" ", 0)]
        [TestCase(@"1+2", 3)]
        [TestCase(@"1-2*4*(2-4)", 11)]
        [TestCase(@"1/2", 3)]
        [TestCase(@"func", 1)]
        [TestCase(@"(", 1)]
        [TestCase(@"func (", 2)]
        [TestCase(@"func(", 2)]
        [TestCase(@"func(1,3)", 6)]
        [TestCase(@"1*func(1,3)", 8)]
        [TestCase(@"-6 * 2e-8  / (1+f)", 10)]
        [TestCase(@"-6.3 * 2e-8  / (((1+f)", 12)]
        public void Parse_ValidLexicalExpression_TargetTokenCount(string text, int count)
        {
            Assert.That(Analyzer.Parse(text).Count(), Is.EqualTo(count));
        }
    }
}
