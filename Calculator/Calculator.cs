using Calculator.RPNComponents;
using Calculator.RPNComponents.Operator;

namespace Calculator
{
    /// <summary>
    /// RPN計算機の統合クラス
    /// </summary>
    public class Calculator
    {
        private Stack<ICalculationTarget> _targetStack { get; set; } = new();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="formula"></param>
        public Calculator(string formula)
        {
            _targetStack.Push(new NumberTarget(null, null));
            _targetStack.Push(new Addition());
            _targetStack.Push(new Multiplication());
            _targetStack.Push(new Subtraction());
            _targetStack.Push(new Divison());

            foreach (var token in ReversePolishNotationParser.ParseReversePolishNotation(formula))
            {
                _targetStack.Push(_targetStack.Pop().IsItself(token, _targetStack));
            }
        }

        /// <summary>
        /// スタックの状態を表示する
        /// </summary>
        /// <returns></returns>
        public string DisplayStack()
            => String.Join(" ", _targetStack.ToArray().Select(t => t.Display()));

        /// <summary>
        /// スタックから最初の式を取り出して計算を開始する
        /// </summary>
        public void Run()
            => _targetStack.Pop().Execute();
    }
}