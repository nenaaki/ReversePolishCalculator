using Calculator.RPNException;

namespace Calculator.RPNComponents.Operator
{
    /// <summary>
    /// 除算を扱うクラス
    /// </summary>
    internal class Divison : BasicOperator
    {
        private static readonly string NAME = "/";

        /// <summary>
        /// 指定したスタックから値を2つ取り出し、除算を行ってスタックに返す
        /// </summary>
        /// <param name="calculationTargets">操作するスタック</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Execute(Stack<ICalculationTarget> calculationTargets)
            => Execute(calculationTargets, ExecuteDivision);

        private NumberModel ExecuteDivision(NumberTarget numberTarget1, NumberTarget numberTarget2)
        {
            if (numberTarget2.Numerator == 0) throw new RuntimeException("0で値を割ることはできません");

            return new NumberModel
            {
                Denominator = numberTarget1.Denominator * numberTarget2.Numerator,
                Numerator = numberTarget1.Numerator * numberTarget2.Denominator
            };
        }

        /// <summary>
        /// 実際の画面に表示する形式「/」を返す
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string Display() => NAME;

        /// <summary>
        /// tokenが「/」かどうかを識別し、正ならば自身を返す
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