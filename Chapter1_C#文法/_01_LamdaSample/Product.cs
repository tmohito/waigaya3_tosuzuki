using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaSample
{
    internal class Product
    {
        internal enum CategoryEnum 
        {
            食品,
            家電,
            掃除用品,
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public CategoryEnum Category { get; set; }

        public override string ToString()
        {
            return $"商品名: {Name} 金額: {Price} 種類: {Category.ToString()}";
        }
    }
}
