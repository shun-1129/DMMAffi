namespace DMMLibrary.Models.Data
{
    /// <summary>
    /// サイトモデルクラス
    /// </summary>
    public class Site
    {
        /// <summary>
        /// サイト名
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// サイトコード
        /// </summary>
        public string code { get; set; } = string.Empty;

        /// <summary>
        /// サービスリスト
        /// </summary>
        public List<Service> service { get; set; } = new List<Service> ();
    }
}
