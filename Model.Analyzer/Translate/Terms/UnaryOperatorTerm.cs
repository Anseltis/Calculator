using AnsiSoft.Calculator.Model.Analyzer.Translate.Operators;

namespace AnsiSoft.Calculator.Model.Analyzer.Translate.Terms
{
    public sealed class UnaryOperatorTerm : ITerm
    {
        public IUnaryOperator Operator { get; }

        public UnaryOperatorTerm(IUnaryOperator op)
        {
            Operator = op;
        }
    }
}
