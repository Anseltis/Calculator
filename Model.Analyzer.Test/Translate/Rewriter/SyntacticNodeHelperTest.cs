using System.Collections.Generic;
using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Blocks;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;
using AnsiSoft.Calculator.Model.Analyzer.Translate.Rewriter;
using NUnit.Framework;
using Rhino.Mocks;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Translate.Rewriter
{
    [TestFixture]
    public class SyntacticNodeHelperTest
    {
        [Test]
        public void IsBlockOf_TokenNode_False()
        {
            var token = MockRepository.GenerateStub<IToken>();
            var tokenNode = new TokenSyntacticNode(token);
            Assert.That(tokenNode.IsBlockOf("some block"), Is.False);
        }

        [Test]
        public void IsBlockOf_BlockNodeWithAnotherName_False()
        {
            var block = MockRepository.GenerateStub<IBlock>();
            block.Stub(b => b.Name).Return("block1");
            var blockNode = new BlockSyntacticNode(block, Enumerable.Empty<ISyntacticNode>());
            Assert.That(blockNode.IsBlockOf("block2"), Is.False);
        }

        [Test]
        public void IsBlockOf_BlockNodeWithSameName_True()
        {
            var block = MockRepository.GenerateStub<IBlock>();
            block.Stub(b => b.Name).Return("block1");
            var blockNode = new BlockSyntacticNode(block, Enumerable.Empty<ISyntacticNode>());
            Assert.That(blockNode.IsBlockOf("block1"), Is.True);
        }

        [Test]
        public void Rewrite_SomeNode_RightRewriterBehavior()
        {
            var node = MockRepository.GenerateStub<ISyntacticNode>();
            node.Stub(nd => nd.Nodes).Return(Enumerable.Empty<ISyntacticNode>());
            node.Stub(nd => nd.Rewrite(Arg<IEnumerable<ISyntacticNode>>.Is.Anything))
                .Return(node);

            var rewriter = MockRepository.GenerateMock<ISyntaxRewriter>();
            rewriter.Expect(nd => nd.Filter(Arg<ISyntacticNode>.Is.Anything))
                .Return(true);
            rewriter.Expect(r => r.Visit(Arg<ISyntacticNode>.Is.Anything,
                Arg<IEnumerable<ISyntacticNode>>.Is.Anything)).Return(node);

            node.Rewrite(rewriter);
            rewriter.VerifyAllExpectations();
        }

        [Test]
        public void Rewrite_SomeNodeInFilter_RightNodeBehavior()
        {
            var node = MockRepository.GenerateMock<ISyntacticNode>();
            node.Expect(nd => nd.Nodes).Return(Enumerable.Empty<ISyntacticNode>());

            var rewriter = MockRepository.GenerateStub<ISyntaxRewriter>();
            rewriter.Stub(nd => nd.Filter(Arg<ISyntacticNode>.Is.Anything))
                .Return(true);
            rewriter.Stub(r => r.Visit(Arg<ISyntacticNode>.Is.Anything,
                Arg<IEnumerable<ISyntacticNode>>.Is.Anything)).Return(node);

            node.Rewrite(rewriter);
            node.VerifyAllExpectations();
        }

        [Test]
        public void Rewrite_SomeNodeOutOfFilter_RightNodeBehavior()
        {
            var node = MockRepository.GenerateMock<ISyntacticNode>();
            node.Expect(nd => nd.Nodes).Return(Enumerable.Empty<ISyntacticNode>());
            node.Expect(nd => nd.Rewrite(Arg<IEnumerable<ISyntacticNode>>.Is.Anything)).Return(node);

            var rewriter = MockRepository.GenerateStub<ISyntaxRewriter>();
            rewriter.Stub(nd => nd.Filter(Arg<ISyntacticNode>.Is.Anything))
                .Return(false);
            rewriter.Stub(r => r.Visit(Arg<ISyntacticNode>.Is.Anything,
                Arg<IEnumerable<ISyntacticNode>>.Is.Anything)).Return(node);

            node.Rewrite(rewriter);
            node.VerifyAllExpectations();
        }

    }


}
