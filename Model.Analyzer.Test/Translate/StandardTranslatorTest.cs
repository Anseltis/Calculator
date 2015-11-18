using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Facade;
using AnsiSoft.Calculator.Model.Analyzer.Lexical;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Blocks;
using AnsiSoft.Calculator.Model.Analyzer.Translate;
using NUnit.Framework;
using static AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes.SyntacticNodeTypeHelper;

namespace AnsiSoft.Calculator.Model.Analyzer.Test.Translate
{
    [TestFixture]
    public class StandardTranslatorTest
    {

        [Test]
        [TestCase("func(1,2,3)")]
        [TestCase("2*(1+4)")]
        [TestCase("(1)")]
        [TestCase("1+2")]
        public void Rewrite_Expressiion_DoesNotThrow(string text)
        {
            var lexical = new LexicalAnalyzer(AnalyzerFacade.LexicalRules);
            var syntactic = new SyntacticAnalyzer(AnalyzerFacade.SyntacticRules);
            var translator = new Translator(AnalyzerFacade.TranslateRules);
            Assert.DoesNotThrow(
                () =>
                {
                    var tokens = lexical.Parse(text);
                    var tree = syntactic.Parse(tokens, BlockOf<ExpressionBlock>());
                    translator.Rewrite(tree);
                });
        }

        [Test]
        public void Rewrite_SpecialExpression1_TargetNodeCount()
        {
            var lexical = new LexicalAnalyzer(AnalyzerFacade.LexicalRules);
            var syntactic = new SyntacticAnalyzer(AnalyzerFacade.SyntacticRules);
            var translator = new Translator(AnalyzerFacade.TranslateRules);
            const string text = "func(1,2,3)";
            var tokens = lexical.Parse(text);
            var tree = syntactic.Parse(tokens, BlockOf<ExpressionBlock>());
            var root = translator.Rewrite(tree);
            Assert.That(root.Nodes.Count(), Is.EqualTo(3));
        }

        [Test]
        public void Rewrite_SpecialExpression2_TargetNodeCount()
        {
            var lexical = new LexicalAnalyzer(AnalyzerFacade.LexicalRules);
            var syntactic = new SyntacticAnalyzer(AnalyzerFacade.SyntacticRules);
            var translator = new Translator(AnalyzerFacade.TranslateRules);
            const string text = "(((-1+1+3+pi)))";
            var tokens = lexical.Parse(text);
            var tree = syntactic.Parse(tokens, BlockOf<ExpressionBlock>());
            var root = translator.Rewrite(tree);
            Assert.That(root.Nodes.Count(), Is.EqualTo(2));
        }
    }
}
