namespace Calculator
{
    /// <summary>
    /// RPN計算機のインターフェース
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// 式をパースして、スタックに挿入する
        /// </summary>
        /// <param name="formula"></param>
        void Push(string formula);

        /// <summary>
        /// スタックの状態を表示する
        /// </summary>
        /// <returns></returns>
        string DisplayStack();

        /// <summary>
        /// スタックから1つ値を取り出す
        /// </summary>
        /// <returns></returns>
        string Pop();

        /// <summary>
        /// 定義済みの値以外をすべてスタックから削除します
        /// </summary>
        /// <returns></returns>
        string Clean();

        /// <summary>
        /// スタックから式を取り出して計算を開始する
        /// </summary>
        void Run();

        /// <summary>
        /// コマンド一覧を取得する
        /// </summary>
        /// <returns></returns>
        string[] GetAllCommand();

        /// <summary>
        /// 文字列に一致するコマンドを実行する
        /// </summary>
        /// <param name="command"></param>
        void CallCommand(string command);

        /// <summary>
        /// スタックに積まれている式の数を取得する
        /// </summary>
        /// <returns></returns>
        int GetStackCount();
    }
}