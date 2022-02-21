namespace Calculator.RPNComponents.Operator
{
    /// <summary>
    /// 減算を扱うクラス
    /// </summary>
    internal class Subtraction : BasicOperator
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Subtraction()
        { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="isDefinitionInstance"></param>
        public Subtraction(bool isDefinitionInstance) => IsDefinitionInstance = isDefinitionInstance;

        /// <summary>
        /// 指定したスタックから2つの値を取り出し、減算をしてスタックに返す
        /// </summary>
        /// <param name="calculationTargets">操作するスタック</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Execute(Stack<ICalculationTarget> calculationTargets)
            => Execute(calculationTargets, ExecuteSubtraction);

        private NumberModel ExecuteSubtraction(NumberTarget numberTarget1, NumberTarget numberTarget2)
            => new()
            {
                Numerator = (double)(numberTarget1.Numerator * numberTarget2.Denominator -
                    numberTarget2.Numerator * numberTarget2.Denominator),
                Denominator = (double)(numberTarget1.Denominator * numberTarget2.Denominator),
            };

        /// <summary>
        /// 実際の画面に表示する形式「-」を返す
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string Display() => (IsDefinitionInstance) ? "" : "-";

        /// <summary>
        /// tokenが「-」かどうかを識別し、正ならば自身を返す
        /// </summary>
        /// <param name="token"></param>
        /// <param name="calculationTargets"></param>
        /// <returns></returns>
        public override ICalculationTarget IsItself(string token, Stack<ICalculationTarget> calculationTargets)
            => (token == "-") ? new Subtraction() :
                CalculationHelper.IsNetxPopedItself(token, calculationTargets);
    }
}