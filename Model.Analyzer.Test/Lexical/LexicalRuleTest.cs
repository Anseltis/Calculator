using System;
using AnsiSoft.Calculator.Model.Analyzer.Lexical;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using NUnit.Framework;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Lexical
{
    [TestFixture]
    class LexicalRuleTest
    {
        [Test]
        public void PatternAndTokenFactory_Input_Same()
        {
            Func<TokenBuilder, IToken> factory = builder => null;

            var lexicalRule = new LexicalRule("1224", factory);

            Assert.That(lexicalRule.Pattern, Is.EqualTo("1224"));
            Assert.That(lexicalRule.TokenFactory, Is.EqualTo(factory));
        }
    }
}
