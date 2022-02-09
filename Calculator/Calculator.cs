using Calculator.RPNComponents;

namespace Calculator
{
    /// <summary>
    /// RPN計算機の統合クラス
    /// </summary>
    public class Calculator
    {
        private List<ICalculationTarget> _RPNComponents { get; set; } = new();

        private Stack<ICalculationTarget> _targetStack { get; set; } = new();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="formula"></param>
        public Calculator(string formula)
        {
            _RPNComponents = ReversePolishNotationParser.ParseReversePolishNotation(formula);
        }

        /// <summary>
        /// スタックの状態を表示する
        /// </summary>
        /// <returns></returns>
        public string DisplayStack()
            => String.Join(" ", _targetStack.ToArray().Select(t => t.Display()));

        /// <summary>
        /// 計算式を1つ実行する
        /// </summary>
        /// <returns></returns>
        public bool DoCalc()
        {
            if (!_RPNComponents.Any()) return false;

            _RPNComponents[0].Execute(_targetStack);
            _RPNComponents.RemoveAt(0);

#if DEBUG
            Console.WriteLine(DisplayStack());
#endif

            return true;
        }
    }
}