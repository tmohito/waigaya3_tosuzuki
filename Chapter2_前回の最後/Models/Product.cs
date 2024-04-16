using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Waigaya3.Models
{
    public class Product
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("id")]
        public int Id { get; set; }
        /// <summary>
        /// 商品名
        /// </summary>
        [Column("name")]
        public required string Name { get; set; }
        /// <summary>
        /// 説明
        /// </summary>
        [Column("description")]
        public string Description { get; set; } = "";
        /// <summary>
        /// 価格
        /// </summary>
        [Range(0, 9999.99)]
        [Column("price",TypeName ="decimal(8,2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// カテゴリID(外部キー)
        /// </summary>
        [Column ("category_id")]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        /// <summary>
        /// 作成日
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; set;} = DateTime.Now;
        /// <summary>
        /// 削除日
        /// </summary>
        [Column("delete_at")]
        public DateTime? DeleteAt { get; set;}

        //ナビゲーションプロパティ
        public Category? Category { get; set; }
    }
}
