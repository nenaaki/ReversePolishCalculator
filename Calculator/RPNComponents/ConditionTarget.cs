﻿namespace Calculator.RPNComponents
{
    /// <summary>
    /// 条件式を扱うクラス
    /// </summary>
    internal class ConditionTarget : ICalculationTarget
    {
        public bool IsDefinitionInstance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Display()
        {
            throw new NotImplementedException();
        }

        public void Execute(Stack<ICalculationTarget> calculationTargets)
        {
            throw new NotImplementedException();
        }

        public ICalculationTarget? IsItself(string token)
        {
            throw new NotImplementedException();
        }
    }
}