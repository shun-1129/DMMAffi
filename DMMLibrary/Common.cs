using DMMLibrary.Models.Data;
using System.Text;
using System.Text.Json;

namespace DMMLibrary
{
    /// <summary>
    /// 共通処理クラス
    /// </summary>
    public class Common
    {
        /// <summary>
        /// API ID
        /// </summary>
        private string _apiId;
        /// <summary>
        /// アフィリエイトID
        /// </summary>
        private string _affiliateId;

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <param name="apiId">API ID</param>
        /// <param name="affiliateId">アフィリエイトID</param>
        public Common ( string apiId, string affiliateId )
        {
            _apiId = apiId;
            _affiliateId = affiliateId;
        }

        /// <summary>
        /// API要求
        /// </summary>
        /// <param name="endPoint">エンドポイント</param>
        /// <param name="keywordDict">キーワード</param>
        /// <returns>検索結果</returns>
        /// <exception cref="InvalidOperationException">
        /// 検索をした結果がnullだった場合にスローされます。
        /// </exception>
        public async Task<APIResult> APIRequest ( string endPoint , Dictionary<string , string> keywordDict )
        {
            const string API_URL = "https://api.dmm.com/affiliate/v3";
            string url = API_URL + endPoint;

            // 基本クエリパラメータを設定
            var query = new Dictionary<string, string>
            {
                { "api_id", _apiId },
                { "affiliate_id", _affiliateId },
                { "output", "json" }
            };

            // 引数として受け取ったパラメータを追加
            foreach ( var param in keywordDict )
            {
                query[param.Key] = param.Value;
            }

            string uri = BuildQueryString ( url, query );
            APIResult? result = null;
            // HttpClientを使ってリクエストを送信
            using ( HttpClient client = new HttpClient () )
            {
                HttpResponseMessage response = await client.GetAsync ( uri );

                if ( response.IsSuccessStatusCode )
                {
                    // レスポンスの内容を文字列として取得
                    string content = await response.Content.ReadAsStringAsync();

                    result = JsonSerializer.Deserialize<APIResult> ( content );
                }
            }

            if ( result == null )
            {
                throw new InvalidOperationException ( "The processing result is null. Expected result was not obtained." );
            }

            return result;
        }

        /// <summary>
        /// クエリパラメータを手動で組み立て
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private string BuildQueryString ( string url , Dictionary<string , string> parameters )
        {
            StringBuilder query = new StringBuilder ( url );
            query.Append ( "?" );

            foreach ( var param in parameters )
            {
                query.Append ( Uri.EscapeDataString ( param.Key ) + "=" + Uri.EscapeDataString ( param.Value ) + "&" );
            }

            // 最後の & を削除
            if ( query.Length > 0 )
                query.Length--;

            return query.ToString ();
        }

        /// <summary>
        /// Jsonから値を取得
        /// </summary>
        /// <param name="document"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static JsonDocument? GetValue ( JsonDocument document , string key )
        {
            if ( document.RootElement.TryGetProperty ( key , out JsonElement element ) )
            {
                string? value = element.ToString ();
                if ( string.IsNullOrEmpty ( value ) )
                {
                    return null;
                }

                return JsonDocument.Parse ( value );
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Jsonから値を取得
        /// </summary>
        /// <param name="document"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<JsonDocument> GetValues ( JsonDocument document , string key )
        {
            List<JsonDocument> values = new List<JsonDocument> ();
            if ( document.RootElement.TryGetProperty ( key , out JsonElement element ) )
            {
                if ( element.ValueKind == JsonValueKind.Array )
                {
                    foreach ( JsonElement jsonElement in element.EnumerateArray () )
                    {
                        string? value = jsonElement.ToString ();
                        if ( string.IsNullOrEmpty ( value ) )
                        {
                            continue;
                        }

                        values.Add ( JsonDocument.Parse ( value ) );
                    }
                }

                return values;
            }
            else
            {
                return new List<JsonDocument> ();
            }
        }
    }
}
