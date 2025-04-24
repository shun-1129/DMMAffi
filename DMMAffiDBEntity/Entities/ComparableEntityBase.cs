using System.Reflection;

namespace DMMAffiDBEntity.Entities
{
    /// <summary>
    /// エンティティ比較クラス
    /// </summary>
    public abstract class ComparableEntityBase : BaseEntityColumn
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="other"></param>
        /// <param name="includeBaseProperties"></param>
        /// <param name="additionalExcludedProperties"></param>
        /// <returns></returns>
        public Dictionary<string , (object? ThisValue, object? OtherValue)> GetDifferences<T> (
            T other ,
            bool includeBaseProperties = false ,
            params string[] additionalExcludedProperties
        ) where T : ComparableEntityBase
        {
            var differences = new Dictionary<string, (object?, object?)>();

            if ( other == null )
            {
                differences["null"] = (this, null);
                return differences;
            }

            var thisType = this.GetType();
            var baseType = typeof(BaseEntityColumn);

            // 比較対象のプロパティ一覧
            var allProps = thisType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // 除外するプロパティ名を収集
            var excluded = new HashSet<string>(additionalExcludedProperties);

            // BaseEntityColumn のプロパティを除外
            if ( !includeBaseProperties && baseType.IsAssignableFrom ( thisType ) )
            {
                var baseProps = baseType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                    .Select(p => p.Name);
                foreach ( var name in baseProps )
                {
                    excluded.Add ( name );
                }
            }

            // 比較処理
            foreach ( var prop in allProps )
            {
                if ( excluded.Contains ( prop.Name ) )
                    continue;

                var thisVal = prop.GetValue(this);
                var otherVal = prop.GetValue(other);

                if ( !Equals ( thisVal , otherVal ) )
                {
                    differences[prop.Name] = (thisVal, otherVal);
                }
            }

            return differences;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="other"></param>
        /// <param name="includeBaseProperties"></param>
        /// <param name="additionalExcludedProperties"></param>
        /// <returns></returns>
        public bool IsEqualTo<T> (
            T other ,
            bool includeBaseProperties = false ,
            params string[] additionalExcludedProperties
        ) where T : ComparableEntityBase
        {
            var diff = GetDifferences(other, includeBaseProperties, additionalExcludedProperties);
            return diff.Count == 0;
        }
    }
}
