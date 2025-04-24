using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DMMAffiDBEntity.Entities.Master
{
    /// <summary>
    /// フロアマスタ
    /// </summary>
    [Table ( "m_floor" )]
    [Comment ( "フロアマスタ" )]
    public class MFloor : ComparableEntityBase
    {
        /// <summary>
        /// フロアマスタID
        /// </summary>
        [Key]
        [Required]
        [Column ( "id" )]
        [Comment ( "フロアマスタID" )]
        [DatabaseGenerated ( DatabaseGeneratedOption.None )]
        public int Id { get; set; }

        /// <summary>
        /// サイトマスタID
        /// </summary>
        [Required]
        [Column ( "m_site_id" )]
        [Comment ( "サイトマスタID:【値例】1" )]
        public int SiteId { get; set; }

        /// <summary>
        /// サービスマスタID
        /// </summary>
        [Required]
        [Column ( "m_service_id" )]
        [Comment ( "サービスマスタID:【値例】1" )]
        public int ServiceId { get; set; }

        /// <summary>
        /// フロアID
        /// </summary>
        [Required]
        [Column ( "floor_id" )]
        [Comment ( "フロアID:【値例】1" )]
        public int FloorId { get; set; }

        /// <summary>
        /// DMM フロア名
        /// </summary>
        [Required]
        [Column ( "floor_name" )]
        [Comment ( "フロア名:【値例】" )]
        [StringLength ( 128 )]
        public string FloorName { get; set; } = string.Empty;

        /// <summary>
        /// DMM フロアコード
        /// </summary>
        [Required]
        [Column ( "floor_code" )]
        [Comment ( "フロアコード:【値例】" )]
        [StringLength ( 128 )]
        public string FloorCode { get; set; } = string.Empty;

        /// <summary>
        /// 論理削除
        /// </summary>
        [Required]
        [Column ( "is_deleted" )]
        [Comment ( "論理削除:【値例】false：未削除 , true：削除済み" )]
        public bool IsDeleted { get; set; }
    }
}
