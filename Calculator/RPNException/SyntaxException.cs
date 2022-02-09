namespace Calculator.RPNException
{
    /// <summary>
    /// RPN式として入力された文字列がRPN式のルールに基づいていなかった場合に使用
    /// </summary>
    internal class SyntaxException : Exception
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        public SyntaxException(string? message) : base(message)
        {
        }
    }
}