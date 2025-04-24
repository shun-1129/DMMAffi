using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMAffiDBEntity.Entities.Master
{
    /// <summary>
    /// サイトマスタ
    /// </summary>
    [Table ( "m_site" )]
    [Comment ( "サイトマスタ" )]
    public class MSite : ComparableEntityBase
    {
        /// <summary>
        /// サイトマスタID
        /// </summary>
        [Key]
        [Required]
        [Column ( "id" )]
        [Comment ( "サイトマスタID:【値例】1" )]
        [DatabaseGenerated ( DatabaseGeneratedOption.None )]
        public int Id { get; set; }

        /// <summary>
        /// サイト名
        /// </summary>
        [Required]
        [Column ( "site_name" )]
        [Comment ( "サイト名称" )]
        [StringLength ( 128 )]
        public string SiteName { get; set; } = string.Empty;

        /// <summary>
        /// サイトコード
        /// </summary>
        [Required]
        [Column ( "site_code" )]
        [Comment ( "サイトコード" )]
        [StringLength ( 128 )]
        public string SiteCode { get; set; } = string.Empty;

        /// <summary>
        /// 論理削除
        /// </summary>
        [Required]
        [Column ( "is_deleted" )]
        [Comment ( "論理削除:【値例】false：未削除 , true：削除済み" )]
        public bool IsDeleted { get; set; }
    }
}
