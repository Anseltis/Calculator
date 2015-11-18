using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;
using AnsiSoft.Calculator.Model.Analyzer.Syntactic.Blocks;

namespace AnsiSoft.Calculator.Model.Analyzer.Syntactic.NodeTypes
{
    /// <summary>
    /// Helper class for usability writing of syntactic grammar
    /// </summary>
    public static class SyntacticNodeTypeHelper
    {
        /// <summary>
        /// Create terminal symbol of context-free grammar.
        /// </summary>
        /// <typeparam name="T">Lexical token</typeparam>
        /// <returns>Instance of <see cref="TokenSyntacticNodeType{T}"/> class.</returns>
        public static TokenSyntacticNodeType<T> TokenOf<T>() where T : IToken
        {
            return new TokenSyntacticNodeType<T>();
        }

        /// <summary>
        /// Create non-terminal symbol of context-free grammar.
        /// </summary>
        /// <typeparam name="T">Syntactic block</typeparam>
        /// <returns>Instance of <see cref="BlockSyntacticNodeType{T}"/> class.</returns>
        public static BlockSyntacticNodeType<T> BlockOf<T>() where T : IBlock
        {
            return new BlockSyntacticNodeType<T>();
        }
    }
}
