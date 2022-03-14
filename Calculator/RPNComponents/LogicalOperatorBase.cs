using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNComponents
{
    internal abstract class LogicalOperatorBase : BasicOperator
    {
        public override string Display() => IsDefinitionInstance ? string.Empty : Name;

        [NotNull]
        protected abstract string Name { get; }

        public override bool TryParse(string token, [NotNullWhen(true)] out ICalculationTarget result)
        {
            if(token == Name)
            {
                result = Create();
                return true;
            }
            result = null!;
            return false;
        }

        public override void Execute(IRPNStack calculationTargets)
        {
            var value1 = GetTwoNumberFromStack(calculationTargets);
            var value2 = GetTwoNumberFromStack(calculationTargets);

            calculationTargets.Push(Compare(value1, value2));
        }

        public abstract ICalculationTarget Compare(NumberTarget value1, NumberTarget value2);

        protected NumberTarget ToNumberTarget(bool value) => value ? new NumberTarget(1, 1) : new NumberTarget(1, 0);

        protected abstract ICalculationTarget Create();
    }
}
