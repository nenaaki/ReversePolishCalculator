namespace Calculator
{
    /// <summary>
    /// 数値全般を表すクラス
    /// </summary>
    internal class NumberTarget : ICalculationTarget
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="denominator">分母</param>
        /// <param name="numerator">分子</param>
        public NumberTarget(int denominator, int numerator)
        {
            Denominator = denominator;
            Numerator = numerator;
        }

        /// <summary>
        /// 分母
        /// </summary>
        public int Denominator { get; }

        /// <summary>
        /// 分子
        /// </summary>
        public int Numerator { get; }

        /// <summary>
        /// 指定したスタックにこのクラスのインスタンスをプッシュする
        /// </summary>
        /// <param name="stackTarget">操作するスタック</param>
        public void Execute(Stack<ICalculationTarget> stackTarget)
            => stackTarget.Push(this);
    }
}