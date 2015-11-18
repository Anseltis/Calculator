using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;
using NUnit.Framework;
using Rhino.Mocks;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Syntactic
{
    [TestFixture]
    public class SyntacticParseResultTest
    {
        [Test]
        public void TokenNodes_Null_Null()
        {
            var node = MockRepository.GenerateStub<ISyntacticNode>();
            var parseResult = new SyntacticParseResult(node,null);
            Assert.That(parseResult.TokenNodes, Is.Null);
        }

        [Test]
        public void TokenNodes_Empty_Empty()
        {
            var node = MockRepository.GenerateStub<ISyntacticNode>();
            var tokenNodes = Enumerable.Empty<TokenSyntacticNode>();
            var parseResult = new SyntacticParseResult(node, tokenNodes);
            Assert.That(parseResult.TokenNodes, Is.SameAs(tokenNodes));
        }

        [Test]
        public void TokenNodes_SomeList_Same()
        {
            var node = MockRepository.GenerateStub<ISyntacticNode>();
            var tokenNodes = new[]
            {
                new TokenSyntacticNode(MockRepository.GenerateStub<IToken>()),
                new TokenSyntacticNode(MockRepository.GenerateStub<IToken>())
            };
            var parseResult = new SyntacticParseResult(node, tokenNodes);
            Assert.That(parseResult.TokenNodes, Is.SameAs(tokenNodes));
        }

        [Test]
        public void Node_NodeStub_Same()
        {
            var node = MockRepository.GenerateStub<ISyntacticNode>();
            var tokenNodes = Enumerable.Empty<TokenSyntacticNode>();
            var parseResult = new SyntacticParseResult(node, tokenNodes);
            Assert.That(parseResult.Node, Is.SameAs(node));
        }

    }
}
