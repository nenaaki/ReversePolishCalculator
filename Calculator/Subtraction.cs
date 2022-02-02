namespace Calculator
{
    /// <summary>
    /// 減算を扱うクラス
    /// </summary>
    internal class Subtraction : BasicOperator
    {
        /// <summary>
        /// 指定したスタックから2つの値を取り出し、減算をしてスタックに返す
        /// </summary>
        /// <param name="calculationTargets">操作するスタック</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Execute(Stack<ICalculationTarget> calculationTargets)
            => Execute(calculationTargets, ExecuteSubtraction);

        private NumberModel ExecuteSubtraction(NumberTarget numberTarget1, NumberTarget numberTarget2)
            => new()
            {
                Numerator = (numberTarget1.Numerator * numberTarget2.Denominator) -
                    (numberTarget2.Numerator * numberTarget2.Denominator),
                Denominator = numberTarget1.Denominator * numberTarget2.Denominator,
            };
    }
}