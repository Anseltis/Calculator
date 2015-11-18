namespace AnsiSoft.Calculator.Model.Analyzer.Translate.Terms
{
    public sealed class IdentifierTerm : ITerm
    {
        public string Identifier { get; }

        public IdentifierTerm(string identifier)
        {
            Identifier = identifier;
        }
    }
}
