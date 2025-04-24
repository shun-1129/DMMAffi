using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMAffiDBEntity.Entities.Master
{
    /// <summary>
    /// サービスマスタ
    /// </summary>
    [Table ( "m_service" )]
    [Comment ( "サービスマスタ" )]
    public class MService : ComparableEntityBase
    {
        /// <summary>
        /// サービスマスタID
        /// </summary>
        [Key]
        [Required]
        [Column ( "id" )]
        [Comment ( "サービスマスタID:【値例】1")]
        [DatabaseGenerated ( DatabaseGeneratedOption.None )]
        public int Id { get; set; }

        /// <summary>
        /// サービス名称
        /// </summary>
        [Required]
        [Column ( "service_name" )]
        [Comment ( "サービス名称:【値例】AKBグループ" )]
        [StringLength ( 128 )]
        public string ServiceName { get; set; } = string.Empty;

        /// <summary>
        /// サービスコード
        /// </summary>
        [Required]
        [Column ( "service_code" )]
        [Comment ( "サービスコード:【値例】" )]
        [StringLength ( 128 )]
        public string ServiceCode { get; set; } = string.Empty;

        /// <summary>
        /// 論理削除
        /// </summary>
        [Required]
        [Column ( "is_deleted" )]
        [Comment ( "論理削除:【値例】false：未削除 , true：削除済み" )]
        public bool IsDeleted { get; set; }
    }
}
