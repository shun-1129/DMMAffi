namespace DMMLibrary.Models.Data
{
    internal class APIResult
    {
        /// <summary>
        /// 要求
        /// </summary>
        public Request request { get; set; } = new Request ();
        /// <summary>
        /// 結果
        /// </summary>
        public Result result { get; set; } = new Result ();
    }
}
