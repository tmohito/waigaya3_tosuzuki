using Waigaya3.Models;

namespace Waigaya3.Controllers.Response
{
    public class ProductEnrtyResponse
    {
        /// <summary>
        /// 商品マスタ
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// カテゴリーリスト　コンボボックス表示用
        /// </summary>
        public List<Category> Categories { get; set; }
    }
}
