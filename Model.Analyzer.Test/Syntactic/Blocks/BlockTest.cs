using System.Collections.Generic;
using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Blocks;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes;
using NUnit.Framework;
using Rhino.Mocks;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Syntactic.Blocks
{
    [TestFixture]
    public class BlockTest
    {
        /// <summary>
        /// Base class for innernal node of syntactic tree
        /// </summary>
        private class BlockStub : Block
        {
            /// <summary>
            ///  Initializes a new instance of the <see cref="BlockStub"/> class.
            /// </summary>
            /// <param name="name">Unique string rule indentifier</param>
            /// <param name="rule">Symblol sequence of context-free grammar</param>
            public BlockStub(string name, IEnumerable<ISyntacticNodeType> rule) : base(name, rule)
            {
            }
        }

        [Test]
        public void Rule_Null_Null()
        {
            var block = new BlockStub("", null);
            Assert.That(block.Rule, Is.Null);
        }

        [Test]
        public void Rule_Empty_Same()
        {
            var rule = Enumerable.Empty<ISyntacticNodeType>();
            var block = new BlockStub("", rule);
            Assert.That(block.Rule, Is.SameAs(rule));
        }

        [Test]
        public void Rule_SomeElement_Same()
        {
            var rule = new[]
            {
                MockRepository.GenerateStub<ISyntacticNodeType>(),
                MockRepository.GenerateStub<ISyntacticNodeType>(),
                MockRepository.GenerateStub<ISyntacticNodeType>()
            };
            var block = new BlockStub("", rule);
            Assert.That(block.Rule, Is.SameAs(rule));
        }

        [Test]
        public void Name_SomeValue_Same()
        {
            const string name = "SomeName";
            var rule = Enumerable.Empty<ISyntacticNodeType>();
            var block = new BlockStub(name, rule);
            Assert.That(block.Name, Is.EqualTo(name));
        }
    }

 
}
