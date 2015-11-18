using System.Collections.Generic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Nodes;

namespace AnsiSoft.Calculator.Model.Analyzer.Translate.Terms
{
    /// <summary>
    /// 
    /// </summary>
    public class TermSyntacticNode : ISyntacticNode
    {
        #region implement ISyntacticNode
        public IEnumerable<ISyntacticNode> Nodes { get; }
        public ISyntacticNode Rewrite(IEnumerable<ISyntacticNode> nodes) => 
            new TermSyntacticNode(Term, nodes);
        #endregion

        public ITerm Term { get; }
        public TermSyntacticNode(ITerm term, IEnumerable<ISyntacticNode> nodes)
        {
            Term = term;
            Nodes = nodes;
        }
    }
}
