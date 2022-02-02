namespace Calculator
{
    /// <summary>
    /// 除算を扱うクラス
    /// </summary>
    internal class Divison : BasicOperator
    {
        /// <summary>
        /// 指定したスタックから値を2つ取り出し、除算を行ってスタックに返す
        /// </summary>
        /// <param name="calculationTargets">操作するスタック</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Execute(Stack<ICalculationTarget> calculationTargets)
            => Execute(calculationTargets, ExecuteDivision);

        private NumberModel ExecuteDivision(NumberTarget numberTarget1, NumberTarget numberTarget2)
        {
            if (numberTarget2.Numerator == 0) throw new Exception();

            return new NumberModel
            {
                Denominator = numberTarget1.Denominator * numberTarget2.Numerator,
                Numerator = numberTarget1.Numerator * numberTarget2.Denominator
            };
        }
    }
}