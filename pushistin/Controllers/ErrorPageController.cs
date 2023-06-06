using pushistin.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace pushistin.Controllers
{
    [Route("ErrorPage/{statuscode}")]
    public class ErrorPageController : Controller
    {
        public IActionResult Index(int statuscode)
        {
            switch(statuscode)
            {
                case 404:
                    ViewData["Error"] = "Извините, такая страница не найдена";
                    ViewData["Code"] = "404";
                    break;
                default:
                    break;
            }
            return View("ErrorPage");
        }
    }
}