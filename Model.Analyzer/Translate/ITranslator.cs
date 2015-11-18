using System.Collections.Generic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;
using AnsiSoft.Calculator.Model.Analyzer.Translate.Rewriter;

namespace AnsiSoft.Calculator.Model.Analyzer.Translate
{
    /// <summary>
    /// Interface for syntactic tree translation
    /// </summary>
    public interface ITranslator
    {
        /// <summary>
        /// Translation rule list (rewriters)
        /// </summary>
        IEnumerable<ISyntaxRewriter> Rules { get; }

        /// <summary>
        /// Translate syntax tree using rules
        /// </summary>
        /// <param name="node">Root node</param>
        /// <returns>Rewritten root node</returns>
        ISyntacticNode Rewrite(ISyntacticNode node);
    }
}