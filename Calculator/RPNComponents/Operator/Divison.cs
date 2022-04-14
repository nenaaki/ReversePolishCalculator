using Calculator.RPNException;
using System.Diagnostics.CodeAnalysis;

namespace Calculator.RPNComponents.Operator
{
    /// <summary>
    /// 除算を扱うクラス
    /// </summary>
    internal class Divison : BasicOperator
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Divison()
        { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="isDefinitionInstance"></param>
        public Divison(bool isDefinitionInstance) => IsDefinitionInstance = isDefinitionInstance;

        internal static Divison DefinitionInstance => new Divison(true);

        /// <summary>
        /// 指定したスタックから値を2つ取り出し、除算を行ってスタックに返す
        /// </summary>
        /// <param name="calculationTargets">操作するスタック</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Execute(IRPNStack calculationTargets)
            => Execute(calculationTargets, ExecuteDivision);

        private NumberModel ExecuteDivision(NumberTarget numberTarget1, NumberTarget numberTarget2)
        {
            if (numberTarget2.Numerator == 0) throw new RuntimeException("0で値を割ることはできません");

            return new NumberModel
            {
                Denominator = (double)(numberTarget1.Denominator * numberTarget2.Numerator),
                Numerator = (double)(numberTarget1.Numerator * numberTarget2.Denominator)
            };
        }

        /// <summary>
        /// 実際の画面に表示する形式「/」を返す
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string Display() => (IsDefinitionInstance) ? "" : "/";

        /// <summary>
        /// tokenが「/」かどうかを識別し、正ならば自身を返す
        /// </summary>
        /// <param name="token"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryParse(string token, [NotNullWhen(true)] out ICalculationTarget result)
        {
            if (token == "/")
            {
                result = new Divison();
                return true;
            }

            result = default!;
            return false;
        }
    }
}