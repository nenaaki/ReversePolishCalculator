using Calculator.RPNComponents;
using Calculator.RPNComponents.Operator;
using Calculator.RPNException;

namespace Calculator
{
    internal static class ReversePolishNotationParser
    {
        /// <summary>
        /// RPN式を個々の要素にパースする
        /// </summary>
        /// <param name="formula">RPN文字列式</param>
        internal static List<ICalculationTarget> ParseReversePolishNotation(string formula)
        {
            var componentsString = formula.Split(' ');

            var RPNComponents = new List<ICalculationTarget>();

            foreach (var componentString in componentsString)
            {
                var component = DistinguishRPNComponent(componentString);
                RPNComponents.Add(component);
            }

            return RPNComponents;
        }

        /// <summary>
        /// 個々のRPN式の要素を判別して、型に割り当てる
        /// </summary>
        /// <param name="component"></param>
        /// <returns>RPN要素</returns>
        private static ICalculationTarget DistinguishRPNComponent(string component)
        {
            if (int.TryParse(component, out var result))
                return new NumberTarget(1, result);

            switch (component)
            {
                case "+":
                    return new Addition();

                case "-":
                    return new Subtraction();

                case "*":
                    return new Multiplication();

                case "/":
                    return new Divison();
            }

            throw new SyntaxException($"不正な式が含まれています:{component}");
        }
    }
}