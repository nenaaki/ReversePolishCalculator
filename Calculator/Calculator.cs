using Calculator.RPNComponents;
using Calculator.RPNComponents.Operator;
using Calculator.RPNException;

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
        public Calculator()
        {
            TargetStack.Push(new NumberTarget(true));
            TargetStack.Push(new Addition(true));
            TargetStack.Push(new Multiplication(true));
            TargetStack.Push(new Subtraction(true));
            TargetStack.Push(new Divison(true));
        }

        /// <summary>
        /// 式をパースして、スタックに挿入する
        /// </summary>
        /// <param name="formula"></param>
        /// <exception cref="SyntaxException"></exception>
        public void Push(string formula)
        {
            foreach (var token in ReversePolishNotationParser.ParseReversePolishNotation(formula))
            {
                var flag = false;
                foreach (var target in TargetStack.ToArray())
                {
                    var parseResult = target.IsItself(token);
                    if (parseResult is null) continue;

                    TargetStack.Push(parseResult);
                    flag = true;
                    break;
                }

                if (!flag) throw new SyntaxException("不正な式が入力されています");
            }
        }

        /// <summary>
        /// スタックの状態を表示する
        /// </summary>
        /// <returns></returns>
        public string DisplayStack()
            => string.Join(" ", TargetStack.ToArray().Select(t => t.Display()));

        /// <summary>
        /// スタックから1つ値を取り出す
        /// </summary>
        /// <returns></returns>
        /// <exception cref="RuntimeException"></exception>
        public string Pop()
        {
            if (TargetStack.Any() && TargetStack.FirstOrDefault().IsDefinitionInstance)
                throw new RuntimeException("取り出そうとしたスタックの値が組み込み定義型のため、取り出せません");

            return TargetStack.Pop().Display();
        }

        /// <summary>
        /// 定義済みの値以外をすべてスタックから削除します
        /// </summary>
        /// <returns></returns>
        public string Clean()
        {
            while (TargetStack.Any() && !TargetStack.FirstOrDefault().IsDefinitionInstance)
            {
                TargetStack.Pop();
            }

            return DisplayStack();
        }

        /// <summary>
        /// スタックから最初の式を取り出して計算を開始する
        /// </summary>
        public void Run()
            => TargetStack.Pop().Execute(TargetStack);
    }
}