using Waigaya3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Waigaya3.Data;
using Microsoft.EntityFrameworkCore;

namespace Waigaya3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WaigayaDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, WaigayaDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewBag.ConnectionString = dbContext.Database.GetConnectionString();
            ViewBag.IsConnect = dbContext.Database.CanConnect();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
