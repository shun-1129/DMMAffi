using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace DMMAffiDBEntity.Entities.Master
{
    /// <summary>
    /// フロアマスタモデルクラス
    /// </summary>
    [Table ( "m_floor" )]
    [Comment ( "フロアマスタ" )]
    public class MFloor : BaseEntityColumn
    {
        /// <summary>
        /// フロアマスタID
        /// </summary>
        [Key]
        [Required]
        [Column ( "id" )]
        [Comment ( "フロアマスタID:【値例】1" )]
        [DatabaseGenerated ( DatabaseGeneratedOption.None )]
        public int Id { get; set; }

        /// <summary>
        /// DMM サイト名
        /// </summary>
        [Required]
        [Column ( "dmm_site_name" )]
        [Comment ( "DMM サイト名" )]
        [StringLength ( 128 )]
        public string DMMSiteName { get; set; } = string.Empty;

        /// <summary>
        /// DMM サイトコード
        /// </summary>
        [Required]
        [Column ( "dmm_site_code" )]
        [Comment ( "DMM サイトコード" )]
        [StringLength ( 128 )]
        public string DMMSiteCode { get; set; } = string.Empty;

        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        [Column ( "content" , TypeName = "jsonb" )]
        [Comment ( "コンテンツ:【値例】" )]
        public JsonDocument Content { get; set; } = JsonDocument.Parse ( "{}" );

        /// <summary>
        /// 論理削除
        /// </summary>
        [Required]
        [Column ( "is_deleted" )]
        [Comment ( "論理削除:【値例】false：未削除 , true：削除済み" )]
        public bool IsDeleted { get; set; }
    }
}
