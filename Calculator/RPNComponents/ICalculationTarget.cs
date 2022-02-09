namespace Calculator.RPNComponents
{
    /// <summary>
    /// 逆ポーランド計算用のスタックに積むことができるクラスに実装するインターフェース
    /// </summary>
    internal interface ICalculationTarget
    {
        /// <summary>
        /// 指定したスタックに対して処理を行う
        /// </summary>
        /// <param name="calculationTargets"></param>
        void Execute(Stack<ICalculationTarget> calculationTargets);

        /// <summary>
        /// 画面に実際に表示する値に変換する
        /// </summary>
        /// <returns></returns>
        string Display();
    }

    /// <summary>
    /// 加減乗除の基本的な演算を扱う抽象クラス
    /// </summary>
    internal abstract class BasicOperator : ICalculationTarget
    {
        /// <summary>
        /// 指定したスタックから2つ値を取り出し、
        /// </summary>
        /// <param name="calculationTargets"></param>
        /// <param name="calcFunc"></param>
        /// <exception cref="Exception"></exception>
        public static void Execute(Stack<ICalculationTarget> calculationTargets, Func<NumberTarget, NumberTarget, NumberModel> calcFunc)
        {
            if (!calculationTargets.Any()) return;

            var arg1 = calculationTargets.Pop();
            var arg2 = calculationTargets.Pop();

            if (arg1 is not NumberTarget numberTarget1) throw new Exception();
            if (arg2 is not NumberTarget numberTarget2) throw new Exception();

            var basicCalcResult = calcFunc(numberTarget1, numberTarget2);

            var greatestCommonDivisor = CalculationHelper.CalcGreatestCommonDivisor(
                basicCalcResult.Denominator, basicCalcResult.Numerator);

            if (greatestCommonDivisor != 0)
            {
                basicCalcResult.Denominator /= greatestCommonDivisor;
                basicCalcResult.Numerator /= greatestCommonDivisor;
            }

            calculationTargets.Push(
                new NumberTarget(basicCalcResult.Denominator, basicCalcResult.Numerator));
        }

        public abstract string Display();

        public abstract void Execute(Stack<ICalculationTarget> calculationTargets);

        public class NumberModel
        {
            internal int Numerator { get; set; }

            internal int Denominator { get; set; }
        }
    }
}