using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMAffiDBEntity.Entities.Transaction
{
    /// <summary>
    /// マスタ管理テーブル
    /// </summary>
    [Table ( "t_master_management" )]
    [Comment ( "マスタ管理テーブル" )]
    public class TMasterManagement : BaseEntityColumn
    {
        /// <summary>
        /// マスタ管理ID
        /// </summary>
        [Key]
        [Required]
        [Column ( "id" )]
        [Comment ( "マスタ管理ID:【値例】1" )]
        [DatabaseGenerated ( DatabaseGeneratedOption.None )]
        public int Id { get; set; }

        /// <summary>
        /// マスタ更新日時
        /// </summary>
        [Required]
        [Column ( "master_change_date" )]
        [Comment ( "マスタ更新日時:【値例】2025/04/01 00:00:00" )]
        public DateTime MasterChangeDate { get; set; }
    }
}
