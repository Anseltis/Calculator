using AnsiSoft.Calculator.Model.Analyzer.Translate.Operators;

namespace AnsiSoft.Calculator.Model.Analyzer.Translate.Terms
{
    public sealed class BinaryOperatorTerm : ITerm
    {
        public IBinaryOperator Operator { get; }

        public BinaryOperatorTerm(IBinaryOperator op)
        {
            Operator = op;
        }
    }
}
