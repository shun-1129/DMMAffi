namespace DMMLibrary.Models.Data
{
    /// <summary>
    /// サービスモデルクラス
    /// </summary>
    public class Service
    {
        /// <summary>
        /// サービス名
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// サービスコード
        /// </summary>
        public string code { get; set; } = string.Empty;

        /// <summary>
        /// フロアリスト
        /// </summary>
        public List<Floor> floor { get; set; } = new List<Floor> ();
    }
}
