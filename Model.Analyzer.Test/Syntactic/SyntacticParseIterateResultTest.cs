using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes;
using NUnit.Framework;
using Rhino.Mocks;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Syntactic
{
    [TestFixture]
    public class SyntacticParseIterateResultTest
    {
        [Test]
        public void NodesAndNodeTypesAndTokenNodes_Stub_Same()
        {
            var nodes = new[]
            {
                MockRepository.GenerateStub<ISyntacticNode>(),
                MockRepository.GenerateStub<ISyntacticNode>()
            };
            var nodeTypes = new[]
            {
                MockRepository.GenerateStub<ISyntacticNodeType>(),
                MockRepository.GenerateStub<ISyntacticNodeType>()
            };
            var tokenNodes = new[]
            {
                new TokenSyntacticNode(MockRepository.GenerateStub<IToken>()),
                new TokenSyntacticNode(MockRepository.GenerateStub<IToken>())
            };

            var iterate = new SyntacticParseIterateResult(nodes, nodeTypes, tokenNodes);

            Assert.That(iterate.Nodes,Is.SameAs(nodes));
            Assert.That(iterate.NodeTypes, Is.SameAs(nodeTypes));
            Assert.That(iterate.TokenNodes, Is.SameAs(tokenNodes));
        }

    }
}
