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

        public NumberTarget(bool isDefinitionInstance) => IsDefinitionInstance = isDefinitionInstance;

        /// <summary>
        /// 分母
        /// nullの場合は定義インスタンスのため、処理は行わない
        /// </summary>
        public double? Denominator { get; }

        /// <summary>
        /// 分子
        /// nullの場合は定義インスタンスのため、処理は行わない
        /// </summary>
        public double? Numerator { get; }

        public bool IsDefinitionInstance { get; set; } = false;

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
            => (Denominator is null || Numerator is null) ? "" : (Numerator / Denominator).ToString();

        /// <summary>
        /// 分数表示で数値の文字列を表示する
        /// </summary>
        /// <returns></returns>
        public string DisplayWithFractionShape()
            => (Denominator is null || Numerator is null) ? "" :
                (Denominator == 1) ? Numerator.ToString() : $"{Numerator}/{Denominator}";

        /// <summary>
        /// 実際の画面に表示する形式を出力する
        /// </summary>
        /// <returns></returns>
        public string Display()
            => DisplayWithFractionShape();

        /// <summary>
        /// 文字列が数値形式の場合は、インスタンスを作成し返す
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ICalculationTarget IsItself(string token)
        {
            if (Double.TryParse(token, out double d))
            {
                return new NumberTarget(1, d);
            }

            var fraction = token.Split("/");
            if (fraction.Length == 2)
            {
                var numeratorTryParseResult = Double.TryParse(fraction[0], out double numerator);
                var denominatorTryParseResult = Double.TryParse(fraction[1], out double denominator);

                if (numeratorTryParseResult && denominatorTryParseResult)
                {
                    return new NumberTarget(numerator, denominator);
                }
            }

            return null;
        }
    }
}