using System.Text.Json.Serialization;

namespace DMMLibrary.Models.Data
{
    /// <summary>
    /// フロアモデルクラス
    /// </summary>
    public class Floor
    {
        /// <summary>
        /// フロアID
        /// </summary>
        [JsonConverter ( typeof ( FlexibleIntConverter ) )]
        public int id { get; set; }

        /// <summary>
        /// フロア名
        /// </summary>
        public string name { get; set; } = string.Empty;

        /// <summary>
        /// フロアコード
        /// </summary>
        public string code { get; set; } = string.Empty;
    }
}
