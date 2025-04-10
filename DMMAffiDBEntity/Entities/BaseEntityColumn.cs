using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMAffiDBEntity.Entities
{
    /// <summary>
    /// 共通カラムモデルクラス
    /// </summary>
    public class BaseEntityColumn
    {
        /// <summary>
        /// 作成日時
        /// </summary>
        [Required]
        [Column ( "created_date" )]
        [Comment ( "作成日時:【値例】2025/01/01 00:00:00")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 作成者
        /// </summary>
        [Column ( "create_user" )]
        [Comment ( "作成者:【値例】System")]
        [StringLength ( 128 )]
        public string? CreateUser { get; set; }

        /// <summary>
        /// 作成プログラム
        /// </summary>
        [Required]
        [Column ( "create_program")]
        [Comment ( "作成プログラム:【値例】System" )]
        [StringLength ( 128 )]
        public string CreateProgram { get; set; } = string.Empty;

        /// <summary>
        /// 更新日時
        /// </summary>
        [Required]
        [Column ( "update_date" )]
        [Comment ( "更新日時:【値例】2025/01/01 00:00:00" )]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        [Column ( "update_user" )]
        [Comment ( "更新者:【値例】System" )]
        [StringLength ( 128 )]
        public string? UpdateUser { get; set; }

        /// <summary>
        /// 更新プログラム
        /// </summary>
        [Required]
        [Column ( "update_program" )]
        [Comment ( "更新プログラム:【値例】System" )]
        [StringLength ( 128 )]
        public string UpdateProgram { get; set; } = string.Empty;
    }
}
