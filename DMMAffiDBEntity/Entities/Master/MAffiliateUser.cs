using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMAffiDBEntity.Entities.Master
{
    /// <summary>
    /// アフィリエイトユーザマスタモデルクラス
    /// </summary>
    [Table ( "m_affiliate_user" )]
    [Comment ( "アフィリエイトユーザマスタ" )]
    public class MAffiliateUser : BaseEntityColumn
    {
        /// <summary>
        /// アフィリエイトユーザマスタID
        /// </summary>
        [Key]
        [Column ( "id" )]
        [Comment ( "アフィリエイトユーザマスタID:【値例】1" )]
        [DatabaseGenerated ( DatabaseGeneratedOption.None )]
        public int Id { get; set; }

        /// <summary>
        /// API ID
        /// </summary>
        [Required]
        [Column ( "api_id" )]
        [Comment ( "APIID:【値例】" )]
        [StringLength ( 128 ) ]
        public string AIPId { get; set; } = string.Empty;

        /// <summary>
        /// アフィリエイトID
        /// </summary>
        [Required]
        [Column ( "affiliate_id" )]
        [Comment ( "アフィリエイトID:【値例】" )]
        [StringLength ( 128 )]
        public string AffiliateId { get; set; } = string.Empty;

        /// <summary>
        /// 論理削除
        /// </summary>
        [Required]
        [Column ( "is_deleted" )]
        [Comment ( "論理削除:【値例】false：未削除 , true：削除済み")]
        public bool IsDeleted { get; set; }
    }
}
