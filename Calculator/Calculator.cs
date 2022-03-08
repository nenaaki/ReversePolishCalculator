using Calculator.RPNComponents;
using Calculator.RPNComponents.Operator;
using Calculator.RPNException;

namespace Calculator
{
    /// <summary>
    /// RPN計算機の統合クラス
    /// </summary>
    public class Calculator : ICalculator
    {
        private Stack<ICalculationTarget> TargetStack { get; set; } = new();

        /// <summary>
        /// スタックが変更された場合に、ViewModelに変更を通知する
        /// </summary>
        public event EventHandler<string[]> StackChanged;

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
        [Command("push", Description = "式を入力して、スタックにプッシュすることができます。")]
        public void Push(string formula)
        {
            foreach (var token in RPNLexicalAnalyzer.Analyze(formula))
            {
                var flag = false;
                foreach (var target in TargetStack.ToArray())
                {
                    var result = target.TryParse(token, out var parseResult);
                    if (!result) continue;

                    TargetStack.Push(parseResult);
                    StackChanged?.Invoke(this, TargetStack.Select(t => t.Display()).ToArray());
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
        [Command("display", Description = "スタックの状態を表示します。")]
        public string DisplayStack()
            => string.Join(" ", TargetStack.Select(t => t.Display()));

        /// <summary>
        /// スタックから1つ値を取り出す
        /// </summary>
        /// <returns></returns>
        /// <exception cref="RuntimeException"></exception>
        [Command("pop", Description = "スタックから式を1つ取り出します。")]
        public string Pop()
        {
            if (TargetStack.Any() && TargetStack.FirstOrDefault().IsDefinitionInstance)
                throw new RuntimeException("取り出そうとしたスタックの値が組み込み定義型のため、取り出せません");

            StackChanged?.Invoke(this, TargetStack.Select(t => t.Display()).ToArray());
            return TargetStack.Pop().Display();
        }

        /// <summary>
        /// 定義済みの値以外をすべてスタックから削除します
        /// </summary>
        /// <returns></returns>
        [Command("clear", Description = "スタック内の式をすべて削除します。")]
        public string Clean()
        {
            while (TargetStack.Any() && !TargetStack.FirstOrDefault().IsDefinitionInstance)
            {
                TargetStack.Pop();
            }

            StackChanged?.Invoke(this, TargetStack.Select(t => t.Display()).ToArray());
            return DisplayStack();
        }

        /// <summary>
        /// スタックから式を取り出して計算を開始する
        /// </summary>
        [Command("run", Description = "スタック上の式を計算します。")]
        public void Run()
        {
            TargetStack.Pop().Execute(TargetStack);
            StackChanged?.Invoke(this, TargetStack.Select(t => t.Display()).ToArray());
        }

        /// <summary>
        /// コマンド一覧を取得する
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [Command("commandList", Description = "コマンド一覧を取得します。")]
        public string[] GetAllCommand()
        {
            throw new NotImplementedException();
        }
    }
}