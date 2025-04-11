using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMAffiDBEntity.Entities.Transaction
{
    /// <summary>
    /// 商品詳細テーブル
    /// </summary>
    [Table ( "t_product_detail" )]
    [Comment ( "商品詳細テーブル" )]
    public class TProductDetail : BaseEntityColumn
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        [Key]
        [Required]
        [Column ( "t_product_id" )]
        [Comment ( "商品ID:【値例】1" )]
        [DatabaseGenerated ( DatabaseGeneratedOption.None )]
        public long ProductId { get; set; }

        /// <summary>
        /// DMM 商品ID
        /// </summary>
        [Required]
        [Column ( "dmm_content_id" )]
        [Comment ( "DMM 商品ID:【値例】15dss00145" )]
        [StringLength ( 128 )]
        public string DMMContentId { get; set; } = string.Empty;

        /// <summary>
        /// DMM 品番ID
        /// </summary>
        [Required]
        [Column ( "dmm_product_id" )]
        [Comment ( "DMM 品番ID:【値例】15dss00145dl" )]
        [StringLength ( 128 )]
        public string DMMProductId { get; set; } = string.Empty;

        /// <summary>
        /// タイトル
        /// </summary>
        [Required]
        [Column ( "title" )]
        [Comment ( "タイトル:【値例】タイトル" )]
        [StringLength ( 1024 )]
        public string Title { get; set; } =string.Empty;
    }
}
