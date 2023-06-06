using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using pushistin.Infrastructure;
using pushistin.Core.ViewModels;
using pushistin.Core.Repositories;

namespace pushistin.Controllers
{

    public class StoreController : Controller
    {
        private readonly IStoreRepository repository;
        public int pageSize = 9;

        public StoreController(IStoreRepository repo)
        {
            repository = repo;
        }
        
        public async Task<IActionResult> Product(long id, string returnUrl)
        {
            var item = repository.Products.First(p => p.ProductID == id);

            ViewBag.ProductID = item.ProductID;
            ViewBag.ByteImage = item.ByteImage;
            ViewBag.Name = item.Name;
            ViewBag.Price = item.Price;
            ViewBag.Description = item.Description;
            ViewBag.IsStock = item.IsStock;
            ViewBag.Weight = item.Weight;
            ViewBag.Brand = item.Brand;
            ViewBag.Pet = item.Pet;
            ViewBag.Category = item.Category;

            //ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        public async Task<IActionResult> Index(string[] brands, string[] categorys, string[] pets, string? searchString, decimal? from, decimal? to, bool? isStock = false, SortState sort = SortState.PriceAsc, int page = 1)
        {
            var items = await repository.Products.Where(p => brands.Length == 0 || brands.Contains(p.Brand))
                                                  .Where(p => categorys.Length == 0 || categorys.Contains(p.Category))
                                                  .Where(p => pets.Length == 0 || pets.Contains(p.Pet))
                                                  .Where(p => p.IsStock == true || p.IsStock == isStock)
                                                  .Where(p => searchString == null || p.Name.Contains(searchString))
                                                  .Where(p => from == null || p.Price >= from)
                                                  .Where(p => to == null || p.Price <= to)
                                                  .ToListAsync();

       

            var count = items.Count();

            ViewBag.count = count;
            ViewBag.brands = brands;
            ViewBag.categorys = categorys;
            ViewBag.pets = pets;
            //ViewBag.from = items.Min(p => p.Price);
            //ViewBag.to = items.Max(p => p.Price);

            items = items.Skip((page - 1) * pageSize)
                         .Take(pageSize)
                         .ToList();
            
            switch (sort)
            {
                case SortState.PriceDesc:
                    items = items.OrderByDescending(p => p.Price).ToList();
                    break;
                default:
                    items = items.OrderBy(p => p.Price).ToList();
                    break;
            }

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                FilterViewModel = new FilterViewModel(await repository.Products.ToListAsync(), from, to, isStock, searchString),
                SortViewModel = new SortViewModel(sort),
                Products = items
            };
            return View(viewModel);
        }
    }
}
