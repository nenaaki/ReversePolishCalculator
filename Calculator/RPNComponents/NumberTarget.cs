namespace Calculator.RPNComponents
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
        public NumberTarget(double? denominator, double? numerator)
        {
            Denominator = denominator;
            Numerator = numerator;
        }

        /// <summary>
        /// 分母
        /// </summary>
        public double? Denominator { get; }

        /// <summary>
        /// 分子
        /// </summary>
        public double? Numerator { get; }

        /// <summary>
        /// 指定したスタックにこのクラスのインスタンスをプッシュする
        /// </summary>
        /// <param name="stackTarget">操作するスタック</param>
        public void Execute(Stack<ICalculationTarget> stackTarget)
            => stackTarget.Push(this);

        /// <summary>
        /// 少数点表示で数値の文字列を表示する
        /// </summary>
        /// <returns></returns>
        public string DisplayWithDecimalShape()
            => (Numerator / Denominator).ToString();

        /// <summary>
        /// 分数表示で数値の文字列を表示する
        /// </summary>
        /// <returns></returns>
        public string DisplayWithFractionShape()
            => (Denominator == 1) ? Numerator.ToString() : $"{Numerator}/{Denominator}";

        /// <summary>
        /// 実際の画面に表示する形式を出力する
        /// </summary>
        /// <returns></returns>
        public string Display()
            => DisplayWithFractionShape();
    }
}