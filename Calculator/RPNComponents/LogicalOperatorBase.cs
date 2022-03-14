using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNComponents
{
    internal abstract class LogicalOperatorBase : BasicOperator
    {
        protected abstract string Name { get; }

        public override bool TryParse(string token, out ICalculationTarget? result)
        {
            result = token == Name ? Create() : null;
            return result is not null;
        }

        protected abstract ICalculationTarget Create();
    }
}
