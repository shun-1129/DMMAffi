using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace DMMAffiDBEntity.Entities.Transaction
{
    /// <summary>
    /// 商品テーブル
    /// </summary>
    [Table ( "t_product" )]
    [Comment ( "商品テーブル" )]
    public class TProduct : BaseEntityColumn
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        [Key]
        [Required]
        [Column ( "id" )]
        [Comment ( "商品ID:【値例】1" )]
        [DatabaseGenerated ( DatabaseGeneratedOption.None )]
        public long Id { get; set; }

        /// <summary>
        /// 商品内容
        /// </summary>
        [Required]
        [Column ( "product_content" )]
        [Comment ( "商品内容:【値例】" )]
        public JsonDocument ProductContent { get; set; } = JsonDocument.Parse ( "{}" );
    }
}
