using AnsiSoft.Calculator.Model.Analyzer.Lexical;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using NUnit.Framework;
using Rhino.Mocks;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Lexical
{
    [TestFixture]
    public class CompiledLexicalRuleTest
    {
        private const string IdentifierExpression =
            @"^(?<l>\s*)(?<t>[_a-zA-Z][_a-zA-Z0-9]{0,30})((?<e>([^_a-zA-Z0-9\s]|\s*\S)[\s\S]*$)|(?<r>\s*$))";

        [Test, Description("Init lexical rulues in constructor")]
        public void Constructor_LexicalRule_Same()
        {
            var lexicalRule = MockRepository.GenerateStub<ILexicalRule>();
            lexicalRule.Stub(x => x.Pattern).Return("pattern");
            var compiledLexicalRule = new CompiledLexicalRule(lexicalRule);

            Assert.That(compiledLexicalRule.LexicalRule, Is.SameAs(lexicalRule));
        }

        [Test, Description("Check usage pattern in constructor")]
        public void Constructor_LexicalRule_UsePattern()
        {
            var lexicalRule = MockRepository.GenerateMock<ILexicalRule>();
            lexicalRule
                .Expect(r => r.Pattern).Return("pattern");

            Assert.DoesNotThrow(() => new CompiledLexicalRule(lexicalRule));
            lexicalRule.VerifyAllExpectations();
        }

        [Test, Description("Check usage token factory")]
        public void CreateToken_CustomText_UseTokenFactory()
        {
            const string patternt = "pattern";
            const string text = "a1vd";

            var token = MockRepository.GenerateStub<IToken>();
            var lexicalRule = MockRepository.GenerateStub<ILexicalRule>();
            lexicalRule.Stub(r => r.Pattern).Return(patternt);
            lexicalRule.Stub(r => r.TokenFactory).Return(builder => token);
            
            var compiledLexicalRule = new CompiledLexicalRule(lexicalRule);
            compiledLexicalRule.CreateToken(text);
            lexicalRule.VerifyAllExpectations();
        }

        [Test, Description("Check identifier parsing")]
        public void CreateToken_IdentifierPattern_Identifier()
        {
            const string text = "  a1vd ";

            var token = MockRepository.GenerateStub<IToken>();
            var lexicalRule = MockRepository.GenerateMock<ILexicalRule>();
            lexicalRule.Expect(r => r.Pattern).Return(IdentifierExpression);
            lexicalRule.Expect(r => r.TokenFactory).Return(
                builder =>
                {
                    token.Stub(t => t.Lexeme).Return(builder.Lexeme);
                    token.Stub(t => t.LeftTrivia).Return(builder.LeftTrivia);
                    token.Stub(t => t.RightTrivia).Return(builder.RightTrivia);
                    return token;
                });

            var compiledLexicalRule = new CompiledLexicalRule(lexicalRule);
            var actualToken = compiledLexicalRule.CreateToken(text);

            Assert.That(actualToken, Is.SameAs(token));
            Assert.That(token.Lexeme, Is.EqualTo("a1vd"));
            Assert.That(token.LeftTrivia, Is.EqualTo("  "));
            Assert.That(token.RightTrivia, Is.EqualTo(" "));
            lexicalRule.VerifyAllExpectations();
        }

        [Test, Description("Check right parsing")]
        public void IsMatch_IdentifierAndIdentifierPattern_True()
        {
            const string text = "  a1vd ";

            var lexicalRule = MockRepository.GenerateMock<ILexicalRule>();
            lexicalRule.Expect(r => r.Pattern).Return(IdentifierExpression);
            var compiledLexicalRule = new CompiledLexicalRule(lexicalRule);

            Assert.That(compiledLexicalRule.IsMatch(text), Is.True);
            lexicalRule.VerifyAllExpectations();
        }

        [Test, Description("Check wrong parsing")]
        public void IsMatch_NumberAndIdentifierPattern_False()
        {
            const string text = "  2.7 ";

            var lexicalRule = MockRepository.GenerateMock<ILexicalRule>();
            lexicalRule.Expect(r => r.Pattern).Return(IdentifierExpression);
            var compiledLexicalRule = new CompiledLexicalRule(lexicalRule);

            Assert.That(compiledLexicalRule.IsMatch(text), Is.False);
            lexicalRule.VerifyAllExpectations();
        }

        [Test, Description("Check identifier tail")]
        public void Tail_TwoIdentifierAndIdentifierPattern_LastIdentifier()
        {
            const string text = "  a1vd bu ";

            var lexicalRule = MockRepository.GenerateMock<ILexicalRule>();
            lexicalRule.Expect(r => r.Pattern).Return(IdentifierExpression);
            var compiledLexicalRule = new CompiledLexicalRule(lexicalRule);

            Assert.That(compiledLexicalRule.IsMatch(text), Is.True);
            Assert.That(compiledLexicalRule.Tail(text), Is.EqualTo(" bu "));
            lexicalRule.VerifyAllExpectations();
        }

        [Test, Description("Check non-wrong rule")]
        public void IsWrongRule_IdentifierPattern_False()
        {
            const string text = "  a1vd bu ";

            var lexicalRule = MockRepository.GenerateMock<ILexicalRule>();
            lexicalRule.Expect(r => r.Pattern).Return(IdentifierExpression);
            var compiledLexicalRule = new CompiledLexicalRule(lexicalRule);

            Assert.That(compiledLexicalRule.IsMatch(text), Is.True);
            Assert.That(compiledLexicalRule.IsWrongRule(text), Is.False);
            lexicalRule.VerifyAllExpectations();
        }

        [Test, Description("Check wrong rule")]
        public void IsWrongRule_WrongPattern_True()
        {
            const string pattern = @"^(?<e>[\s\S]*)$";
            const string text = "  a1vd bu ";

            var lexicalRule = MockRepository.GenerateMock<ILexicalRule>();
            lexicalRule.Expect(r => r.Pattern).Return(pattern);
            var compiledLexicalRule = new CompiledLexicalRule(lexicalRule);

            Assert.That(compiledLexicalRule.IsMatch(text), Is.True);
            Assert.That(compiledLexicalRule.IsWrongRule(text), Is.True);
            lexicalRule.VerifyAllExpectations();
        }
    }
}
