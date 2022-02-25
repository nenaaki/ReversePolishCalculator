namespace Calculator.RPNComponents.Operator
{
    /// <summary>
    /// 乗算を扱うクラス
    /// </summary>
    internal class Multiplication : BasicOperator
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Multiplication()
        { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="isDefinitionInstance"></param>
        public Multiplication(bool isDefinitionInstance) => IsDefinitionInstance = isDefinitionInstance;

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
                Denominator = (double)(numberTarget1.Denominator * numberTarget2.Denominator),
                Numerator = (double)(numberTarget1.Numerator * numberTarget2.Numerator),
            };

        /// <summary>
        /// 実際の画面に表示する形式「*」を返す
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string Display() => (IsDefinitionInstance) ? "" : "*";

        /// <summary>
        /// tokenが「*」かどうかを識別し、正ならば自身を返す
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override ICalculationTarget? IsItself(string token)
            => (token == "*") ? new Multiplication() : null;
    }
}