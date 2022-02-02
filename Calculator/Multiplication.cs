namespace Calculator
{
    /// <summary>
    /// 乗算を扱うクラス
    /// </summary>
    internal class Multiplication : BasicOperator
    {
        /// <summary>
        /// 指定したスタックから2つの値を取り出し、乗算を行ってスタックに返す
        /// </summary>
        /// <param name="calculationTargets">操作するスタック</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Execute(Stack<ICalculationTarget> calculationTargets)
            => Execute(calculationTargets, ExecuteMultiplication);

        private NumberModel ExecuteMultiplication(NumberTarget numberTarget1, NumberTarget numberTarget2)
            => new()
            {
                Denominator = numberTarget1.Denominator * numberTarget2.Denominator,
                Numerator = numberTarget1.Numerator * numberTarget2.Numerator,
            };
    }
}