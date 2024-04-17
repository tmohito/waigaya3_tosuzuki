namespace Waigaya3.Controllers.Response.Product
{
    public class EntryResponse
    {
        /// <summary>
        /// 商品マスタ
        /// </summary>
        public Models.Product? Product { get; set; }
        /// <summary>
        /// カテゴリーリスト　コンボボックス表示用
        /// </summary>
        public List<Models.Category> Categories { get; set; }
    }
}
