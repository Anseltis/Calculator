using System.Collections.Generic;
using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;
using AnsiSoft.Calculator.Model.Analyzer.Translate;
using AnsiSoft.Calculator.Model.Analyzer.Translate.Rewriter;
using NUnit.Framework;
using Rhino.Mocks;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Translate
{
    [TestFixture]
    public class TranslatorTest
    {
        [Test]
        public void Rules_Null_Null()
        {
            var translator = new Translator(null);
            Assert.That(translator.Rules, Is.Null);
        }

        [Test]
        public void Rules_Empty_Empty()
        {
            var rules = Enumerable.Empty<ISyntaxRewriter>();
            var translator = new Translator(rules);
            Assert.That(translator.Rules, Is.SameAs(rules));
        }

        [Test]
        public void Rules_SomeList_Same()
        {
            var rules = new[]
            {
                MockRepository.GenerateStub<ISyntaxRewriter>(),
                MockRepository.GenerateStub<ISyntaxRewriter>()
            };
            var translator = new Translator(rules);
            Assert.That(translator.Rules, Is.SameAs(rules));
        }

        [Test]
        public void Rewriter_OneTrueRules_RuleResult()
        {
            var emptyNodes = Enumerable.Empty<ISyntacticNode>();
            var tree = MockRepository.GenerateStub<ISyntacticNode>();
            tree.Stub(t => t.Nodes).Return(emptyNodes);

            var tree1 = MockRepository.GenerateStub<ISyntacticNode>();

            var rule1 = MockRepository.GenerateStub<ISyntaxRewriter>();
            rule1.Stub(r => r.Filter(tree)).Return(true);
            rule1.Stub(r => r.Visit(Arg<ISyntacticNode>.Is.Anything, 
                Arg<IEnumerable<ISyntacticNode>>.Is.Anything)).Return(tree1);

            var translator = new Translator(new[] {rule1});
            Assert.That(translator.Rewrite(tree), Is.SameAs(tree1));
        }

        [Test]
        public void Rewriter_OneFalseRules_RuleResult()
        {
            var emptyNodes = Enumerable.Empty<ISyntacticNode>();
            var tree = MockRepository.GenerateStub<ISyntacticNode>();
            tree.Stub(t => t.Nodes).Return(emptyNodes);
            tree.Stub(t => t.Rewrite(Arg<IEnumerable<ISyntacticNode>>.Is.Anything))
                .Return(tree);

            var tree1 = MockRepository.GenerateStub<ISyntacticNode>();

            var rule1 = MockRepository.GenerateStub<ISyntaxRewriter>();
            rule1.Stub(r => r.Filter(tree)).Return(false);
            rule1.Stub(r => r.Visit(Arg<ISyntacticNode>.Is.Anything,
                Arg<IEnumerable<ISyntacticNode>>.Is.Anything)).Return(tree1);

            var translator = new Translator(new[] { rule1 });
            Assert.That(translator.Rewrite(tree), Is.SameAs(tree));
        }

        [Test]
        public void Rewriter_TwoTrueRules_LastRuleResult()
        {
            var tree = MockRepository.GenerateStub<ISyntacticNode>();
            tree.Stub(t => t.Nodes).Return(Enumerable.Empty<ISyntacticNode>());
            tree.Stub(t => t.Rewrite(Arg<IEnumerable<ISyntacticNode>>.Is.Anything))
                .Return(tree);

            var tree1 = MockRepository.GenerateStub<ISyntacticNode>();
            tree1.Stub(t => t.Nodes).Return(Enumerable.Empty<ISyntacticNode>());
            tree1.Stub(t => t.Rewrite(Arg<IEnumerable<ISyntacticNode>>.Is.Anything))
                .Return(tree1);

            var rule1 = MockRepository.GenerateStub<ISyntaxRewriter>();
            rule1.Stub(r => r.Filter(tree)).Return(true);
            rule1.Stub(r => r.Visit(Arg<ISyntacticNode>.Is.Anything,
                Arg<IEnumerable<ISyntacticNode>>.Is.Anything)).Return(tree1);

            var tree2 = MockRepository.GenerateStub<ISyntacticNode>();

            var rule2 = MockRepository.GenerateStub<ISyntaxRewriter>();
            rule2.Stub(r => r.Filter(tree1)).Return(true);
            rule2.Stub(r => r.Visit(Arg<ISyntacticNode>.Is.Anything,
                Arg<IEnumerable<ISyntacticNode>>.Is.Anything)).Return(tree2);

            var translator = new Translator(new[] { rule1, rule2 });
            Assert.That(translator.Rewrite(tree), Is.SameAs(tree2));
        }

    }
}
