namespace DMMAffiDBEntity
{
    /// <summary>
    /// マスタデータストア
    /// </summary>
    public class MasterDataStore
    {
        /// <summary>
        /// マスタデータ
        /// </summary>
        private Dictionary<Type , object> _masterData = new Dictionary<Type, object> ();

        /// <summary>
        /// データセット
        /// </summary>
        /// <typeparam name="T">セットするデータクラス</typeparam>
        /// <param name="data">セットするデータ</param>
        public void Set<T> ( T data )
        {
            _masterData[typeof ( T )] = data!;
        }

        /// <summary>
        /// データ取得
        /// </summary>
        /// <typeparam name="T">取得するデータクラス</typeparam>
        /// <returns>データ</returns>
        public T? Get<T> ()
        {
            return _masterData.TryGetValue ( typeof ( T ), out var data ) ? ( T ) data : default;
        }
    }
}
