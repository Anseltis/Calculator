using System.Text.RegularExpressions;
using AnsiSoft.Calculator.Model.Analyzer.Lexical.Tokens;

namespace AnsiSoft.Calculator.Model.Analyzer.Lexical
{
    /// <summary>
    /// Class with compiled rules for lexiacl analyzer
    /// </summary>
    public sealed class CompiledLexicalRule
    {
        /// <summary>
        /// Lexical rule for analyzer
        /// </summary>
        public ILexicalRule LexicalRule { get; }

        /// <summary>
        /// Comliled regular expression of lexical rule
        /// </summary>
        private Regex Regex { get; }


        /// <summary>
        ///  Initializes a new instance of the <see cref="CompiledLexicalRule"/> class.
        /// </summary>
        /// <param name="lexicalRule">Lexical Rule</param>
        public CompiledLexicalRule(ILexicalRule lexicalRule)
        {
            LexicalRule = lexicalRule;
            Regex = new Regex(LexicalRule.Pattern);
        }

        /// <summary>
        /// Create token with help of regular expression and replace.
        /// </summary>
        /// <param name="text">Input expression</param>
        /// <returns>Token of this text chunk</returns>
        public IToken CreateToken(string text)
        {
            var builder = new TokenBuilder
            {
                Lexeme = Regex.Replace(text, @"${t}"),
                LeftTrivia = Regex.Replace(text, @"${l}"),
                RightTrivia = Regex.Replace(text, @"${r}")

            };

            return LexicalRule.TokenFactory(builder);
        }

        /// <summary>
        /// Match input text with help of lexical rule.
        /// </summary>
        /// <param name="text">Input expression</param>
        /// <returns>True if success matching input text</returns>
        public bool IsMatch(string text)
        {
            return Regex.IsMatch(text);
        }

        /// <summary>
        /// Get tail part after apply lexixal rule.
        /// </summary>
        /// <param name="text">Input expression</param>
        /// <returns>Tail part after apply lexical rule</returns>
        public string Tail(string text)
        {
            return Regex.Replace(text, @"${e}");
        }

        /// <summary>
        /// Detect wrong lexical rule.
        /// </summary>
        /// <param name="text">Input expression</param>
        /// <returns>True if wrong rule found</returns>
        public bool IsWrongRule(string text)
        {
            var tail = Tail(text);
            return tail.Length >= text.Length;
        }
    }
}
