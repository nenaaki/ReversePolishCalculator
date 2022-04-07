using System.Diagnostics.CodeAnalysis;

namespace Calculator.RPNComponents.FlowControl
{
    internal class Loop : BasicOperator
    {
        public static readonly Loop DefinitionInstance = new Loop { IsDefinitionInstance = true };

        public string Name => "loop";

        public override string Display() => IsDefinitionInstance ? "" : Name;

        public override void Execute(IRPNStack calculationTargets)
        {
            var target = calculationTargets.Pop();
            NumberTarget param1;
            if (target is NumberTarget)
                param1 = (NumberTarget)target;
            else
            {
                target.Execute(calculationTargets);
                param1 = (NumberTarget)calculationTargets.Pop();
            }
            var counter = (int)param1.ToDouble();
            // 現在は1つのコマンドを繰り返す仕様。文節や式をまとめる構文（関数）が出来れば、繰り返しにすることができる。
            var command = calculationTargets.Pop();
            for (int index = 0; index < counter; index++)
            {
                command.Execute(calculationTargets);
            }
        }

        public override bool TryParse(string token, [NotNullWhen(true)] out ICalculationTarget result)
        {
            if (token.ToLower() == Name)
            {
                result = new Loop();
                return true;
            }
            result = default!;
            return false;
        }
    }
}
