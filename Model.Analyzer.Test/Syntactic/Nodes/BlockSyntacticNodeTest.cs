using System.ComponentModel;
using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Blocks;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;
using NUnit.Framework;
using Rhino.Mocks;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Syntactic.Nodes
{
    [TestFixture]
    public class BlockSyntacticNodeTest
    {
        [Test]
        public void Nodes_Empty_Empty()
        {
            var block = MockRepository.GenerateStub<IBlock>();
            var nodes = Enumerable.Empty<ISyntacticNode>();
            var blockNode = new BlockSyntacticNode(block, nodes);
            Assert.That(blockNode.Nodes, Is.SameAs(nodes));
        }

        [Test]
        public void Nodes_Null_Null()
        {
            var block = MockRepository.GenerateStub<IBlock>();
            var blockNode = new BlockSyntacticNode(block, null);
            Assert.That(blockNode.Nodes, Is.Null);
        }

        [Test]
        public void Nodes_SomeList_Same()
        {
            var block = MockRepository.GenerateStub<IBlock>();
            var nodes = new[]
            {
                MockRepository.GenerateStub<ISyntacticNode>(),
                MockRepository.GenerateStub<ISyntacticNode>()
            };
            var blockNode = new BlockSyntacticNode(block, nodes);
            Assert.That(blockNode.Nodes, Is.SameAs(nodes));
        }

        [Test]
        public void Block_BlockStub_Same()
        {
            var block = MockRepository.GenerateStub<IBlock>();
            var nodes = Enumerable.Empty<ISyntacticNode>();
            var blockNode = new BlockSyntacticNode(block, nodes);
            Assert.That(blockNode.Block, Is.SameAs(block));
        }

        [Test]
        public void Rewriter_SomeList_Same()
        {
            var block = MockRepository.GenerateStub<IBlock>();
            var nodes = new[]
            {
                MockRepository.GenerateStub<ISyntacticNode>(),
                MockRepository.GenerateStub<ISyntacticNode>()
            };
            var blockNode = new BlockSyntacticNode(block, nodes);
            var rewriteNodes = new[]
            {
                MockRepository.GenerateStub<ISyntacticNode>(),
                MockRepository.GenerateStub<ISyntacticNode>()
            };
            var rewriteBlockNode = blockNode.Rewrite(rewriteNodes);
            Assert.That(rewriteBlockNode.Nodes, Is.SameAs(rewriteNodes));
        }
    }
}
