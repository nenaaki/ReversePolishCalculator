using Calculator.RPNComponents;

namespace Calculator
{
    /// <summary>
    /// 計算の補助に使うメソッドの集合
    /// </summary>
    internal static class CalculationHelper
    {
        /// <summary>
        /// 指定した2つの数値の最大公約数を求める
        /// </summary>
        /// <param name="target1">数値1</param>
        /// <param name="target2">数値2</param>
        /// <returns></returns>
        internal static double CalcGreatestCommonDivisor(double target1, double target2)
        {
            if (target1 < target2)
            {
                var temp = target1;
                target1 = target2;
                target2 = temp;
            }

            var r = target1 % target2;
            while (r != 0)
            {
                target1 = target2;
                target2 = r;
                r = target1 % target2;
            }

            return target2;
        }

        /// <summary>
        /// スタックから次を取り出し、文字列と同じものかのチェック及びインスタンス化を行う
        /// </summary>
        /// <param name="token"></param>
        /// <param name="calculationTargets"></param>
        /// <returns></returns>
        internal static ICalculationTarget IsNetxPopedItself(string token, Stack<ICalculationTarget> calculationTargets)
        {
            var popedTarget = calculationTargets.Pop();

            var target = popedTarget.IsItself(token, calculationTargets);

            calculationTargets.Push(popedTarget);

            return target;
        }
    }
}