namespace Calculator.RPNComponents.Operator
{
    /// <summary>
    /// 乗算を扱うクラス
    /// </summary>
    internal class Multiplication : BasicOperator
    {
        private static readonly string NAME = "*";

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

        /// <summary>
        /// 実際の画面に表示する形式「*」を返す
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string Display() => NAME;

        /// <summary>
        /// tokenが「*」かどうかを識別し、正ならば自身を返す
        /// </summary>
        /// <param name="token"></param>
        /// <param name="calculationTargets"></param>
        /// <returns></returns>
        public override ICalculationTarget IsItself(string token, Stack<ICalculationTarget> calculationTargets)
        {
            return (token == NAME) ? this : calculationTargets.Pop().IsItself(token, calculationTargets);
        }
    }
}