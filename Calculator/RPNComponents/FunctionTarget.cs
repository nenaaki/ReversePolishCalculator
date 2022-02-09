namespace Calculator.RPNComponents
{
    /// <summary>
    /// ユーザーが自作した関数を扱うクラス
    /// </summary>
    internal class FunctionTarget : ICalculationTarget
    {
        public string Display()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 指定したスタックに対して、関数を実行して結果をスタックに返す
        /// </summary>
        /// <param name="calculationTargets">操作するスタック</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Execute(Stack<ICalculationTarget> calculationTargets)
        {
            throw new NotImplementedException();
        }
    }
}