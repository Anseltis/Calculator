using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;
using NUnit.Framework;
using Rhino.Mocks;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Syntactic.Nodes
{
    [TestFixture]
    public class TokenSyntacticNodeTest
    {
        [Test]
        public void Nodes_DoNothing_IsEmpty()
        {
            var token = MockRepository.GenerateStub<IToken>();
            var tokenNode = new TokenSyntacticNode(token);
            Assert.That(tokenNode.Nodes.Any(),Is.EqualTo(false));
        }

        [Test]
        public void Rewriter_SomeList_IsEmpty()
        {
            var token = MockRepository.GenerateStub<IToken>();
            var tokenNode = new TokenSyntacticNode(token);
            var rewriteNodes = new[]
            {
                MockRepository.GenerateStub<ISyntacticNode>(),
                MockRepository.GenerateStub<ISyntacticNode>()
            };
            var rewriteTokenNode = tokenNode.Rewrite(rewriteNodes);
            Assert.That(rewriteTokenNode.Nodes.Any(), Is.EqualTo(false));
        }

    }
}
