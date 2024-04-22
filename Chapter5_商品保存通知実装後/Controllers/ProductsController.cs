using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Waigaya3.Controllers.Request.Product;
using Waigaya3.Controllers.Response.Product;
using Waigaya3.Data;
using Waigaya3.Models;

namespace Waigaya3.Controllers
{
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly WaigayaDbContext _context;

        public ProductsController(WaigayaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 商品マスタ全件表示
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var list = _context.Products.Include(p => p.Category).Where(p => p.DeleteAt == null).ToList();
            return View("productlist", list);
        }

        /// <summary>
        /// 商品マスタ 登録
        /// </summary>
        /// <param name="id">修正の場合、設定</param>
        /// <returns></returns>
        [Route("product_entry")]
        [Route("product_entry/{id}")]
        public IActionResult Entry(int? id)
        {
            Product? p = (id != null) 
                ? _context.Products.FirstOrDefault(x => x.Id == id)
                : null;

            var response = new EntryResponse
            {
                Product = p,
                Categories = _context.Categories.ToList(),
            };

            return View("Views/Products/ProductEntry.cshtml", response);
        }

        /// <summary>
        /// 商品マスタ保存
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("upsert")]
        public IActionResult Upsert([FromForm] SaveRequest request)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == request.Id);

            if (product == null)
            {
                _context.Products.Add(new Product
                {
                    Name = request.Name,
                    Description = request.Description ?? "",
                    Price = request.Price,
                    CategoryId = request.CategoryId
                });
            }
            else
            {
                product.Name = request.Name;
                product.Description = request.Description ?? "";
                product.Price = request.Price;
                product.CategoryId = request.CategoryId;
            }
            _context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// 商品マスタ削除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("delete")]
        public IActionResult Delete([FromForm] DeleteRequest request)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == request.Id);

            if (product != null)
            {
                product.DeleteAt = DateTime.Now;

                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
