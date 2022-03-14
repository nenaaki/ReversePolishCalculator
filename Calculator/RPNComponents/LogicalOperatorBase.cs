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
        public override string Display() => IsDefinitionInstance ? Name : string.Empty;

        protected abstract string Name { get; }

        public override bool TryParse(string token, out ICalculationTarget? result)
        {
            result = token == Name ? Create() : null;
            return result is not null;
        }

        protected abstract ICalculationTarget Create();
    }
}
