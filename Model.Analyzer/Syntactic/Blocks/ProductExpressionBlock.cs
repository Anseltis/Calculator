using System.Collections.Generic;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic.Blocks
{
    /// <summary>
    /// Syntactic block of expression without plus and minus out of brackets
    /// </summary>
    public sealed class ProductExpressionBlock : Block
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="ProductExpressionBlock"/> class.
        /// </summary>
        /// <param name="name">Unique string rule indentifier</param>
        /// <param name="rule">Symblol sequence of context-free grammar</param>
        public ProductExpressionBlock(string name, IEnumerable<ISyntacticNodeType> rule) : base(name, rule)
        {
        }
    }
}
