namespace AnsiSoft.Calculator.Model.Analyzer.Translate.Terms
{
    public sealed class NumberTerm : ITerm
    {
        public double Number { get; }

        public NumberTerm(double number)
        {
            Number = number;
        }
    }
}
