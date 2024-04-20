using System.ComponentModel.DataAnnotations.Schema;

namespace Waigaya3.Models
{
    public class Category
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("id")]
        public int Id { get; set; }
        /// <summary>
        /// タイトル
        /// </summary>
        [Column("title")]
        public required string Title { get; set; }
        /// <summary>
        /// 作成日
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }= DateTime.Now;

        //ナビゲーションプロパティ
        public ICollection<Product>? Products { get; set;}
    }
}
