using System.Diagnostics.CodeAnalysis;

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

        internal static Addition DefinitionInstance => new Addition(true);

        /// <summary>
        /// 指定したスタックから2つ値を取り出し、加算した値をスタックに返す
        /// </summary>
        /// <param name="calculationTargets">操作するスタック</param>
        /// <exception cref="Exception"></exception>
        public override void Execute(IRPNStack calculationTargets)
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
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryParse(string token, [NotNullWhen(true)] out ICalculationTarget result)
        {
            if (token == "+")
            {
                result = new Addition();
                return true;
            }

            result = default!;
            return false;
        }
    }
}