namespace DMMLibrary.Models.Data
{
    /// <summary>
    /// APIリザルト
    /// </summary>
    public class APIResult
    {
        #region 内部クラス
        /// <summary>
        /// 要求
        /// </summary>
        public class Request
        {
            /// <summary>
            /// パラメータ
            /// </summary>
            public class Parameters
            {
                /// <summary>
                /// API ID
                /// </summary>
                public string api_id { get; set; } = string.Empty;
                /// <summary>
                /// アフィリエイトID
                /// </summary>
                public string affiliate_id { get; set; } = string.Empty;
                /// <summary>
                /// 出力形式
                /// </summary>
                public string output { get; set; } = string.Empty;
                /// <summary>
                /// コールバック
                /// </summary>
                public string callback { get; set; } = string.Empty;
            }

            /// <summary>
            /// パラメータ
            /// </summary>
            public Parameters parameters { get; set; } = new Parameters ();
        }
        /// <summary>
        /// 結果
        /// </summary>
        public class Result
        {
            /// <summary>
            /// サイト
            /// </summary>
            public List<Site> site { get; set; } = new List<Site> ();
        }
        #endregion

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
