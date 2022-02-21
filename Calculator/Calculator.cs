using Calculator.RPNComponents;
using Calculator.RPNComponents.Operator;

namespace Calculator
{
    /// <summary>
    /// RPN計算機の統合クラス
    /// </summary>
    public class Calculator
    {
        private Stack<ICalculationTarget> TargetStack { get; set; } = new();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="formula"></param>
        public Calculator(string formula)
        {
            TargetStack.Push(new NumberTarget(null, null));
            TargetStack.Push(new Addition(true));
            TargetStack.Push(new Multiplication(true));
            TargetStack.Push(new Subtraction(true));
            TargetStack.Push(new Divison(true));

            foreach (var token in ReversePolishNotationParser.ParseReversePolishNotation(formula))
            {
                TargetStack.Push(TargetStack.Pop().IsItself(token, TargetStack));
            }
        }

        /// <summary>
        /// スタックの状態を表示する
        /// </summary>
        /// <returns></returns>
        public string DisplayStack()
            => String.Join(" ", TargetStack.ToArray().Select(t => t.Display()));

        /// <summary>
        /// スタックから最初の式を取り出して計算を開始する
        /// </summary>
        public void Run()
            => TargetStack.Pop().Execute(TargetStack);
    }
}