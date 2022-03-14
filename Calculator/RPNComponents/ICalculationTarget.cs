using Calculator.RPNException;

namespace Calculator.RPNComponents
{
    /// <summary>
    /// 逆ポーランド計算用のスタックに積むことができるクラスに実装するインターフェース
    /// </summary>
    internal interface ICalculationTarget
    {
        bool IsDefinitionInstance { get; set; }

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

        /// <summary>
        /// 与えられた式が自分と同じものか判定し、同じなら自分をインスタンス化して返す
        /// 異なる場合は、nullを返す
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        bool TryParse(string token, out ICalculationTarget? result);
    }

    /// <summary>
    /// 加減乗除の基本的な演算を扱う抽象クラス
    /// </summary>
    internal abstract class BasicOperator : ICalculationTarget
    {
        /// <summary>
        /// 定義のみを扱うインスタンスか、実際に計算を実行するインスタンスかを判別する
        /// </summary>
        public bool IsDefinitionInstance { get; set; } = false;

        /// <summary>
        /// 指定したスタックから2つ値を取り出し、
        /// </summary>
        /// <param name="calculationTargets"></param>
        /// <param name="calcFunc"></param>
        /// <exception cref="Exception"></exception>
        public void Execute(Stack<ICalculationTarget> calculationTargets, Func<NumberTarget, NumberTarget, NumberModel> calcFunc)
        {
            if (IsDefinitionInstance) throw new RuntimeException("式が不正です");

            var numberTarget1 = GetTwoNumberFromStack(calculationTargets);
            var numberTarget2 = GetTwoNumberFromStack(calculationTargets);

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

        protected static NumberTarget GetTwoNumberFromStack(Stack<ICalculationTarget> calculationTargets)
        {
            var arg1 = calculationTargets.Pop();
            if (arg1 is not NumberTarget numberTarget1)
            {
                arg1.Execute(calculationTargets);

                arg1 = calculationTargets.Pop();

                if (arg1 is not NumberTarget)
                    throw new RuntimeException("式が不正です");

                numberTarget1 = (NumberTarget)arg1;
            }

            return numberTarget1;
        }

        public abstract string Display();

        public abstract void Execute(Stack<ICalculationTarget> calculationTargets);

        public abstract bool TryParse(string token, out ICalculationTarget? result);

        public class NumberModel
        {
            internal double Numerator { get; set; }

            internal double Denominator { get; set; }
        }
    }
}