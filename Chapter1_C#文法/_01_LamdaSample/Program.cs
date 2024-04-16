using LamdaSample;
//ラムダ式は無名の関数（メソッド）を作成するために使用されます。

//①その前に…有名の関数で「掃除用品」のみ抽出する
List<Product> products = new List<Product>();
#region 事前準備 商品をリストに5件追加
products.Add(new Product
{
    Name = "プロテイン",
    Price = 3200,
    Category = Product.CategoryEnum.食品
});
products.Add(new Product
{
    Name = "単4電池",
    Price = 120,
    Category = Product.CategoryEnum.家電
});
products.Add(new Product
{
    Name = "バケツ",
    Price = 500,
    Category = Product.CategoryEnum.掃除用品
});
products.Add(new Product
{
    Name = "雑巾",
    Price = 130,
    Category = Product.CategoryEnum.掃除用品
});
products.Add(new Product
{
    Name = "石鹸",
    Price = 300,
    Category = Product.CategoryEnum.掃除用品
});
#endregion

#region ラムダ式なしで実行
Console.WriteLine("ラムダ式なしで実行する");
List<Product> wkProducts = new List<Product>();
foreach (var item in products) 
{
    if (item.Category == Product.CategoryEnum.掃除用品) 
    {
        wkProducts.Add(item);
    }
}
foreach (var item in wkProducts) 
{
    Console.WriteLine(item.ToString());
}

#endregion

#region ラムダ式ありだと…もっと少ない行数で分かりやすく書ける
Console.WriteLine("ラムダ式ありで実行する");
//パターン１ where文章で抽出後にForEachラムダで出力。
products.Where(x => x.Category == Product.CategoryEnum.掃除用品)
    .ToList().ForEach(x => Console.WriteLine(x.ToString()));

//パターン２　ForEachラムダ内で、抽出と出力を実施。
products.ForEach(x => {
    if (x.Category == Product.CategoryEnum.掃除用品) Console.WriteLine(x.ToString());
});
//【メリット】無名関数を使うので、変に変数を宣言しなくて良かったりすることが多い！
#endregion
