using System.Collections.Generic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic.Blocks
{
    /// <summary>
    /// Interface for innernal node of syntactic tree
    /// </summary>
    public interface IBlock
    {
        /// <summary>
        /// Symblol sequence of context-free grammar
        /// </summary>
        IEnumerable<ISyntacticNodeType> Rule { get; }

        /// <summary>
        /// Unique string rule indentifier
        /// </summary>
        string Name { get; }

    }
}
