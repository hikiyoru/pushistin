using pushistin.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using pushistin.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace pushistin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStoreRepository repository;

        public HomeController(ILogger<HomeController> logger, IStoreRepository repo)
        {
            _logger = logger;
            repository = repo;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var cat = await repository.Products.Select(p => p.Category).ToListAsync();
            ViewBag.Categorys = cat;
            
            return View(await repository.Products.ToListAsync());
            //return Redirect("/Store");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}