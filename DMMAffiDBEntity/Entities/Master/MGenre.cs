using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMAffiDBEntity.Entities.Master
{
    /// <summary>
    /// 
    /// </summary>
    [Table ( "m_genre" )]
    [Comment ( "ジャンルマスタ" )]
    public class MGenre : ComparableEntityBase
    {
        /// <summary>
        /// ジャンルマスタID
        /// </summary>
        [Key]
        [Required]
        [Column ( "id" )]
        [Comment ( "ジャンルマスタID:【値例】1" )]
        [DatabaseGenerated ( DatabaseGeneratedOption.None )]
        public int Id { get; set; }

        /// <summary>
        /// フロアマスタID
        /// </summary>
        [Required]
        [Column ( "m_floor_id" )]
        [Comment ( "フロアマスタID:【値例】1" )]
        public int FloorId { get; set; }

        /// <summary>
        /// ジャンルID
        /// </summary>
        [Required]
        [Column ( "genre_id" )]
        [Comment ( "ジャンルID" )]
        public int GenreId { get; set; }

        /// <summary>
        /// ジャンル名称
        /// </summary>
        [Required]
        [Column ( "name" )]
        [Comment ( "ジャンル名称" )]
        [StringLength ( 128 )]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// ジャンル名称(読み仮名)
        /// </summary>
        [Required]
        [Column ( "ruby" )]
        [Comment ( "ジャンル名称(読み仮名)" )]
        [StringLength ( 128 )]
        public string Ruby { get; set; } = string.Empty;

        /// <summary>
        /// リストページURL
        /// </summary>
        [Required]
        [Column ( "list_url" )]
        [Comment ( "リストページURL:アフィリエイトID付き" )]
        [StringLength ( 1024 )]
        public string ListUrl { get; set; } = string.Empty;

        /// <summary>
        /// 論理削除
        /// </summary>
        [Required]
        [Column ( "is_deleted" )]
        [Comment ( "論理削除:【値例】false：未削除 , true：削除済み" )]
        public bool IsDeleted { get; set; }
    }
}
