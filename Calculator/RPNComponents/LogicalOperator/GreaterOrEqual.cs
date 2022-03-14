using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNComponents.LogicalOperator
{
    internal class GreaterOrEqual : LogicalOperatorBase
    {
        public static ICalculationTarget DefinitionInstance = new GreaterOrEqual { IsDefinitionInstance = true };

        protected override string Name => "<";

        public override void Execute(Stack<ICalculationTarget> calculationTargets)
        {
            throw new NotImplementedException();
        }

        protected override ICalculationTarget Create() => new GreaterOrEqual();
    }
}
