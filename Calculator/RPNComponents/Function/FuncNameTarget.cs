using System.Diagnostics.CodeAnalysis;

namespace Calculator.RPNComponents.Function
{
    internal class FuncNameTarget : ICalculationTarget
    {
        public bool IsDefinitionInstance { get; set; } = false;

        private string Name { get; set; } = "";

        public FuncNameTarget(bool isDefinitionInstance)
        {
            IsDefinitionInstance = isDefinitionInstance;
        }

        public FuncNameTarget(string name) => Name = name;

        public string Display() => IsDefinitionInstance ? "" : Name;

        public void Execute(IRPNStack calculationTargets)
        {
            //TODO
        }

        public bool TryParse(string token, [NotNullWhen(true)] out ICalculationTarget result)
        {
            result = new FuncNameTarget(token);
            return true;
        }
    }
}