namespace Calculator.RPNComponents.Operator
{
    /// <summary>
    /// 加算を扱うクラス
    /// </summary>
    internal class Addition : BasicOperator
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Addition()
        { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="isDefinitionInstance"></param>
        public Addition(bool isDefinitionInstance) => IsDefinitionInstance = isDefinitionInstance;

        /// <summary>
        /// 指定したスタックから2つ値を取り出し、加算した値をスタックに返す
        /// </summary>
        /// <param name="calculationTargets">操作するスタック</param>
        /// <exception cref="Exception"></exception>
        public override void Execute(Stack<ICalculationTarget> calculationTargets)
            => Execute(calculationTargets, ExecuteAddition);

        private NumberModel ExecuteAddition(NumberTarget numberTarget1, NumberTarget numberTarget2)
            => new()
            {
                Denominator = (double)(numberTarget1.Denominator * numberTarget2.Denominator),
                Numerator = (double)(numberTarget1.Numerator * numberTarget2.Denominator +
                    numberTarget2.Numerator * numberTarget2.Denominator),
            };

        /// <summary>
        /// 実際の画面に表示する形式「+」を返す
        /// </summary>
        /// <returns></returns>
        public override string Display() => (IsDefinitionInstance) ? "" : "+";

        /// <summary>
        /// tokenが「+」かどうかを識別し、正ならば自身を返す
        /// </summary>
        /// <param name="token"></param>
        /// <param name="calculationTargets"></param>
        /// <returns></returns>
        public override ICalculationTarget IsItself(string token, Stack<ICalculationTarget> calculationTargets)
            => (token == "+") ? new Addition() :
                CalculationHelper.IsNetxPopedItself(token, calculationTargets);
    }
}