using DMMLibrary.Models.Data;
using System.Text.Json;

namespace DMMLibrary
{
    /// <summary>
    /// DMM APIクラス
    /// </summary>
    public class DMMAPI
    {
        /// <summary>
        /// 共通処理クラス
        /// </summary>
        private Common _common;

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <param name="apiId">API ID</param>
        /// <param name="affiliateId">アフィリエイトID</param>
        public DMMAPI ( string apiId, string affiliateId )
        {
            _common = new Common ( apiId, affiliateId );
        }

        /// <summary>
        /// フロア検索
        /// </summary>
        /// <param name="keywordDict">キーワード</param>
        /// <returns>検索結果</returns>
        public async Task<List<Site>> SearchFloor ( Dictionary<string , string>? keywordDict = null )
        {
            const string END_POINT = "/FloorList";
            APIResult apiResult = await _common.APIRequest ( END_POINT , keywordDict ?? new Dictionary<string, string> () );
            return apiResult.result.site;
        }
    }
}
