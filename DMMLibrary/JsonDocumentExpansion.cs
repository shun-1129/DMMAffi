using System.Text.Json;

namespace DMMLibrary
{
    /// <summary>
    /// JsonDocument拡張クラス
    /// </summary>
    public static class JsonDocumentExpansion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static JsonDocument ConvertModelToJsonDocument<T> ( T model )
        {
            string jsonString = JsonSerializer.Serialize(model);
            return JsonDocument.Parse ( jsonString );
        }

        /// <summary>
        /// JsonDocument から モデルクラス T に変換する
        /// </summary>
        public static T? ConvertJsonDocumentToModel<T> ( JsonDocument doc )
        {
            // JsonDocument → JsonElement → JSON文字列 → T にデシリアライズ
            string json = JsonSerializer.Serialize(doc.RootElement, new JsonSerializerOptions { WriteIndented = true });
            return JsonSerializer.Deserialize<T> ( json );
        }
    }
}
