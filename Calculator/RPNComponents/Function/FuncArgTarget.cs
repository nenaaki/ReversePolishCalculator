using Calculator.RPNException;
using System.Diagnostics.CodeAnalysis;

namespace Calculator.RPNComponents.Function
{
    internal class FuncArgTarget : ICalculationTarget
    {
        public bool IsDefinitionInstance { get; set; } = false;

        private readonly int ArgumentNumber;

        public FuncArgTarget(int argumentNumber) => ArgumentNumber = argumentNumber;

        public FuncArgTarget(bool isDefinitionInstance)
        {
            IsDefinitionInstance = isDefinitionInstance;
        }

        public string Display() => IsDefinitionInstance ? "" : "$" + ArgumentNumber;

        public void Execute(IRPNStack calculationTargets)
            => throw new RuntimeException("式を実行できません");

        public bool TryParse(string token, [NotNullWhen(true)] out ICalculationTarget result)
        {
            result = default!;

            if (Calculator.Mode == ParseMode.Regular) return false;

            if (token.StartsWith("$") && int.TryParse(token[1..token.Length], out var parseResult))
            {
                result = new FuncArgTarget(parseResult);
                return true;
            }

            return false;
        }
    }
}