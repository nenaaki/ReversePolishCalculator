namespace Calculator
{
    /// <summary>
    /// 加算を扱うクラス
    /// </summary>
    internal class Addition : BasicOperator
    {
        /// <summary>
        /// 指定したスタックから2つ値を取り出し、加算した値をスタックに返す
        /// </summary>
        /// <param name="calculationTargets">操作するスタック</param>
        /// <exception cref="Exception"></exception>
        public override void Execute(Stack<ICalculationTarget> calculationTargets)
            => Execute(calculationTargets, ExecuteAddition);

        private NumberModel ExecuteAddition(NumberTarget numberTarget1, NumberTarget numberTarget2)
            => new()
            {
                Denominator = numberTarget1.Denominator * numberTarget2.Denominator,
                Numerator = (numberTarget1.Numerator * numberTarget2.Denominator) +
                    (numberTarget2.Numerator * numberTarget2.Denominator),
            };
    }
}