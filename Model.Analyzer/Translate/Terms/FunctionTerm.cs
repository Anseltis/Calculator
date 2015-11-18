namespace AnsiSoft.Calculator.Model.Analyzer.Translate.Terms
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class FunctionTerm : ITerm
    {
        public string Function { get; }

        public FunctionTerm(string function)
        {
            Function = function;
        }
    }
}
