using System.Collections.Generic;
using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Facade;
using AnsiSoft.Calculator.Model.Analyzer.Lexical;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Exceptions;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using NUnit.Framework;
using Rhino.Mocks;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Lexical
{
    [TestFixture]
    public class LexicalAnalyzerTest
    {
        [Test, Description("No exception if use standard rules")]
        public void Countructor_StandardRules_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => new LexicalAnalyzer(AnalyzerFacade.LexicalRules));
        }

        [Test, Description("Set rule property in constructor")]
        public void Constructor_Rules_SameCount()
        {
            var lexicalRule = MockRepository.GenerateStub<ILexicalRule>();
            lexicalRule.Stub(x => x.Pattern).Return("pattern");
            var rules = new List<ILexicalRule> {lexicalRule, lexicalRule};

            var analyzer = new LexicalAnalyzer(rules);
            Assert.That(analyzer.Rules.Count(), Is.EqualTo(rules.Count));
        }

        [Test, Description("Rignt construction")]
        public void Parse_Text_TrueToken()
        {
            var analyzer = new LexicalAnalyzer(AnalyzerFacade.LexicalRules);
            const string text = "2 +3.3 + func(4,7)*u ";
            var tokens = analyzer.Parse(text).ToArray();

            Assert.That(tokens.Length, Is.EqualTo(12));

            Assert.That(tokens[0], Is.TypeOf<NumberToken>());
            Assert.That(tokens[1], Is.TypeOf<OperatorToken>());
            Assert.That(tokens[2], Is.TypeOf<NumberToken>());
            Assert.That(tokens[3], Is.TypeOf<OperatorToken>());
            Assert.That(tokens[4], Is.TypeOf<IdentifierToken>());
            Assert.That(tokens[5], Is.TypeOf<LeftBracketToken>());
            Assert.That(tokens[6], Is.TypeOf<NumberToken>());
            Assert.That(tokens[7], Is.TypeOf<SeparatorToken>());
            Assert.That(tokens[8], Is.TypeOf<NumberToken>());
            Assert.That(tokens[9], Is.TypeOf<RightBracketToken>());
            Assert.That(tokens[10], Is.TypeOf<BinaryOperatorToken>());
            Assert.That(tokens[11], Is.TypeOf<IdentifierToken>());
        }

        [Test, Description("Wrong rules")]
        [ExpectedException(typeof(WrongLexicalRuleException))]
        public void Parse_WrongRules_Throw()
        {
            const string pattern = @"^(?<e>[\s\S]*)$";
            const string text = "  a1vd bu ";

            var token = MockRepository.GenerateStub<IToken>();
            var lexicalRule = MockRepository.GenerateStub<ILexicalRule>();

            lexicalRule.Stub(r => r.Pattern).Return(pattern);
            lexicalRule.Stub(r => r.TokenFactory).Return(builder => token);

            var analyzer = new LexicalAnalyzer(new[] {lexicalRule});
            analyzer.Parse(text);
        }
    }
}
