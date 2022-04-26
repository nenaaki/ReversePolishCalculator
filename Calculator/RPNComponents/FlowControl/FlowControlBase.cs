using System.Diagnostics.CodeAnalysis;

namespace Calculator.RPNComponents.FlowControl
{
    internal abstract class FlowControlBase<T> : BasicOperator
        where T : class, ICalculationTarget, new()
    {
        static public T DefinitionInstance = new T { IsDefinitionInstance = true };
        /// <summary>
        /// 名称(小文字)
        /// </summary>
        public abstract string Name { get; }

        public sealed override string Display() => IsDefinitionInstance ? "" : Name;


        public sealed override bool TryParse(string token, [NotNullWhen(true)] out ICalculationTarget result)
        {
            if (token.ToLower() == Name)
            {
                result = new T();
                return true;
            }
            result = default!;
            return false;
        }

        protected NumberTarget GetParameter(IRPNStack calculationTargets)
        {
            var target = calculationTargets.Pop();
            NumberTarget param;
            if (target is NumberTarget)
                param = (NumberTarget)target;
            else
            {
                target.Execute(calculationTargets);
                param = (NumberTarget)calculationTargets.Pop();
            }
            return param;
        }
    }
}
