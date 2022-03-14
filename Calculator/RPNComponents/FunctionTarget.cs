using System.Diagnostics.CodeAnalysis;

namespace Calculator.RPNComponents
{
    /// <summary>
    /// ユーザーが自作した関数を扱うクラス
    /// </summary>
    internal class FunctionTarget : ICalculationTarget
    {
        public bool IsDefinitionInstance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Display()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 指定したスタックに対して、関数を実行して結果をスタックに返す
        /// </summary>
        /// <param name="calculationTargets">操作するスタック</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Execute(IRPNStack calculationTargets)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="token"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool TryParse(string token, [NotNullWhen(true)] out ICalculationTarget result)
        {
            throw new NotImplementedException();
        }
    }
}