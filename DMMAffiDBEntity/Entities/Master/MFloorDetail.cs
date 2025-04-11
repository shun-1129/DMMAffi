using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DMMAffiDBEntity.Entities.Master
{
    /// <summary>
    /// フロア詳細マスタ
    /// </summary>
    [Table ( "m_floor_detail" )]
    [Comment ( "フロア詳細マスタ" )]
    public class MFloorDetail : BaseEntityColumn
    {
        /// <summary>
        /// フロアマスタID
        /// </summary>
        [Key]
        [Required]
        [Column ( "m_floor_id" )]
        [Comment ( "フロアマスタID" )]
        [DatabaseGenerated ( DatabaseGeneratedOption.None )]
        public int FloorId { get; set; }

        /// <summary>
        /// DMM フロアID
        /// </summary>
        [Key]
        [Required]
        [Column ( "dmm_floor_id" )]
        [Comment ( "DMM フロアID" )]
        [DatabaseGenerated ( DatabaseGeneratedOption.None )]
        public int DMMFloorId { get; set; }

        /// <summary>
        /// DMM サービス名
        /// </summary>
        [Key]
        [Required]
        [Column ( "dmm_service_name" )]
        [Comment ( "DMM サービス名" )]
        [StringLength ( 128 )]
        public string DMMServiceName { get; set; } = string.Empty;

        /// <summary>
        /// DMM サービスコード
        /// </summary>
        [Required]
        [Column ( "dmm_service_code" )]
        [Comment ( "DMM サービスコード" )]
        [StringLength ( 128 )]
        public string DMMServiceCode { get; set; } = string.Empty;

        /// <summary>
        /// DMM フロア名
        /// </summary>
        [Key]
        [Required]
        [Column ( "dmm_floor_name" )]
        [Comment ( "DMM フロア名" )]
        [StringLength ( 128 )]
        public string DMMFloorName { get; set; } = string.Empty;

        /// <summary>
        /// DMM フロアコード
        /// </summary>
        [Required]
        [Column ( "dmm_floor_code" )]
        [Comment ( "DMM フロアコード" )]
        [StringLength ( 128 )]
        public string DMMFloorCode { get; set; } = string.Empty;

        /// <summary>
        /// 論理削除
        /// </summary>
        [Required]
        [Column ( "is_deleted" )]
        [Comment ( "論理削除:【値例】false：未削除 , true：削除済み" )]
        public bool IsDeleted { get; set; }
    }
}
