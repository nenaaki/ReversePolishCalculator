using Calculator.RPNComponents;
using Calculator.RPNComponents.Operator;
using Calculator.RPNException;

namespace Calculator
{
    /// <summary>
    /// RPN計算機の統合クラス
    /// </summary>
    internal class Calculator : ICalculator
    {
        private Stack<ICalculationTarget> TargetStack { get; set; } = new();

        /// <summary>
        /// スタックが変更された場合に、ViewModelに変更を通知する
        /// </summary>
        public event EventHandler<string[]>? StackChanged;

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
        public string DisplayStack()
            => string.Join(" ", TargetStack.Select(t => t.Display()));

        /// <summary>
        /// スタックから1つ値を取り出す
        /// </summary>
        /// <returns></returns>
        /// <exception cref="RuntimeException"></exception>
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
        public void Run()
        {
            TargetStack.Pop().Execute(TargetStack);
            StackChanged?.Invoke(this, TargetStack.Select(t => t.Display()).ToArray());
        }

        /// <summary>
        /// コマンド一覧を取得する
        /// </summary>
        /// <returns></returns>
        public string[] GetAllCommand()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// スタックに積まれている式の数を取得する
        /// </summary>
        /// <returns></returns>
        public int GetStackCount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 文字列に一致するコマンドを実行する
        /// </summary>
        /// <param name="command"></param>
        public void CallCommand(string command)
        {
            throw new NotImplementedException();
        }
    }
}