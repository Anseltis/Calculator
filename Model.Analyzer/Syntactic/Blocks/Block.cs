using System.Collections.Generic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic.Blocks
{
    /// <summary>
    /// Base class for innernal node of syntactic tree
    /// </summary>
    public abstract class Block : IBlock
    {
        #region implement IBlock
        public IEnumerable<ISyntacticNodeType> Rule { get; }
        public string Name { get; }
        #endregion

        /// <summary>
        ///  Initializes a new instance of the <see cref="Block"/> class.
        /// </summary>
        /// <param name="name">Unique string rule indentifier</param>
        /// <param name="rule">Symblol sequence of context-free grammar</param>
        protected Block(string name, IEnumerable<ISyntacticNodeType> rule)
        {
            Name = name;
            Rule = rule;
        }
    }
}
