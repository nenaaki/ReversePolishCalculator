namespace Calculator.RPNException
{
    /// <summary>
    /// 実行時に計算不可な部分があった場合に使用 (ex. 0割り)
    /// </summary>
    internal class RuntimeException : Exception
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        public RuntimeException(string? message) : base(message)
        {
        }
    }
}