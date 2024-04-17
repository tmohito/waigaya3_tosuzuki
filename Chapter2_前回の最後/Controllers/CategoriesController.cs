using Microsoft.AspNetCore.Mvc;
using Waigaya3.Controllers.Request.Category;
using Waigaya3.Data;
using Waigaya3.Models;

namespace Waigaya3.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly WaigayaDbContext _context;

        public CategoriesController(WaigayaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// カテゴリ追加
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert([FromBody] SaveRequest request)
        {
            //Insertしかしないけど、念のため確認
            var product = _context.Categories.FirstOrDefault(x => x.Id == request.Id);

            if (product == null)
            {
                _context.Categories.Add(new Category
                {
                    Title = request.Title,
                    CreatedAt = DateTime.Now,
                });
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
