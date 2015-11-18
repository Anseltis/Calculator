using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Blocks;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes;
using NUnit.Framework;
using Rhino.Mocks;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Syntactic
{
    [TestFixture]
    class SyntacticAnalyzerTest
    {
        public void Rules_Null_Null()
        {
            var analyzer = new SyntacticAnalyzer(null);
            Assert.That(analyzer.Rules, Is.Null);
        }

        [Test]
        public void Rules_Empty_Empty()
        {
            var rules = Enumerable.Empty<IBlock>();
            var analyzer = new SyntacticAnalyzer(rules);
            Assert.That(analyzer.Rules, Is.SameAs(rules));
        }

        [Test]
        public void Rules_SomeList_Same()
        {
            var rules = new[]
            {
                MockRepository.GenerateStub<IBlock>(),
                MockRepository.GenerateStub<IBlock>()
            };
            var analyzer = new SyntacticAnalyzer(rules);
            Assert.That(analyzer.Rules, Is.SameAs(rules));
        }

        [Test]
        public void Parse_EmptyNodeTypes_SingleIterate()
        {
            var iterate = new SyntacticParseIterateResult(
                Enumerable.Empty<ISyntacticNode>(),
                Enumerable.Empty<ISyntacticNodeType>(),
                Enumerable.Empty<TokenSyntacticNode>());

            var rules = Enumerable.Empty<IBlock>();
            var analyzer = new SyntacticAnalyzer(rules);
            var result = analyzer.Parse(iterate).ToArray();

            Assert.That(result.Count(),Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo(iterate));
        }
    }
}
