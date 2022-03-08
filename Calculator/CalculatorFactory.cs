namespace Calculator
{
    /// <summary>
    /// Calculatorのファクトリクラス
    /// </summary>
    public class CalculatorFactory
    {
        /// <summary>
        /// Calculatorを作成する
        /// </summary>
        /// <returns></returns>
        public static ICalculator CreateCalculator()
            => new Calculator();
    }
}