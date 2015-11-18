using System.Collections.Generic;
using System.Linq;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;
using AnsiSoft.Calculator.Model.Analyzer.Translate.Rewriter;

namespace AnsiSoft.Calculator.Model.Analyzer.Translate
{
    /// <summary>
    /// Interface for sytactic tree translation 
    /// </summary>
    public sealed class Translator : ITranslator
    {
        #region implement ITranslator
        public IEnumerable<ISyntaxRewriter> Rules { get; }
        public ISyntacticNode Rewrite(ISyntacticNode node) => 
            Rules.Aggregate(node, (current, rewriter) => current.Rewrite(rewriter));
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Translator"/> class.
        /// </summary>
        /// <param name="rules">Translation rule list</param>
        public Translator(IEnumerable<ISyntaxRewriter> rules)
        {
            Rules = rules;
        }
    }
}
