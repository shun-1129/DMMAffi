namespace DMMLibrary.Models.Data
{
    /// <summary>
    /// 
    /// </summary>
    internal class Request
    {
        /// <summary>
        /// 
        /// </summary>
        public class Parameters
        {
            /// <summary>
            /// 
            /// </summary>
            public string api_id { get; set; } = string.Empty;
            /// <summary>
            /// 
            /// </summary>
            public string affiliate_id { get; set; } = string.Empty;
            /// <summary>
            /// 
            /// </summary>
            public string output { get; set; } = string.Empty;
            /// <summary>
            /// 
            /// </summary>
            public string callback { get; set; } = string.Empty;
        }

        public Parameters parameters { get; set; } = new Parameters ();
    }
}
