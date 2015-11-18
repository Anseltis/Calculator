using System.Collections.Generic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic.Blocks
{
    /// <summary>
    /// Syntactic block of custom expression
    /// </summary>
    public sealed class ExpressionBlock : Block
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="ExpressionBlock"/> class.
        /// </summary>
        /// <param name="name">Unique string rule indentifier</param>
        /// <param name="rule">Symblol sequence of context-free grammar</param>
        public ExpressionBlock(string name, IEnumerable<ISyntacticNodeType> rule) : base(name, rule)
        {
        }
    }
}
