namespace Calculator
{
    /// <summary>
    /// RPN計算機のインターフェース
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// スタックが変更された場合に、ViewModelに変更を通知する
        /// </summary>
        event EventHandler<string[]>? StackChanged;

        /// <summary>
        /// 式をパースして、スタックに挿入する
        /// </summary>
        /// <param name="formula"></param>
        void Push(string formula);

        /// <summary>
        /// スタックの状態を表示する
        /// </summary>
        /// <returns></returns>
        [Command("display", Description = "スタックの状態を表示します。")]
        string DisplayStack();

        /// <summary>
        /// スタックから1つ値を取り出す
        /// </summary>
        /// <returns></returns>
        [Command("pop", Description = "スタックから式を1つ取り出します。")]
        string Pop();

        /// <summary>
        /// 定義済みの値以外をすべてスタックから削除します
        /// </summary>
        /// <returns></returns>
        [Command("clear", Description = "スタック内の式をすべて削除します。")]
        string Clean();

        /// <summary>
        /// スタックから式を取り出して計算を開始する
        /// </summary>
        [Command("run", Description = "スタック上の式を計算します。")]
        void Run();

        /// <summary>
        /// コマンド一覧を取得する
        /// </summary>
        /// <returns></returns>
        [Command("commandList", Description = "コマンド一覧を取得します。")]
        string[] GetAllCommand();

        /// <summary>
        /// 文字列に一致するコマンドを実行する
        /// </summary>
        /// <param name="command"></param>
        [Command("call", Description = "文字列でコマンドを実行する")]
        void CallCommand(string command);

        /// <summary>
        /// スタックに積まれている式の数を取得する
        /// </summary>
        /// <returns></returns>
        [Command("stackCount", Description = "スタックに積まれている式の数を取得します。")]
        int GetStackCount();
    }
}