using Microsoft.AspNetCore.Mvc;
using pushistin.Models;
using pushistin.Core.Repositories;
using pushistin.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Printing;
using pushistin.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using pushistin.Repositories;
using pushistin.Pages.Admin;

namespace pushistin.Controllers
{

    public class OrderController : Controller {
        private IOrderRepository _repository;
        private Cart _cart;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public OrderController(IOrderRepository repoService, Cart cartService, IUnitOfWork unitOfWork, SignInManager<ApplicationUser> signInManager) {
            _repository = repoService;
            _cart = cartService;
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
        }

        //public ViewResult Checkout() => View(new Order());
        public ViewResult Checkout()
        {
            ApplicationUser user = _unitOfWork.User.GetUser(_signInManager.UserManager.GetUserId(User));
            if (user != null)
            {
                return View(new Order
                {
                    Name = user.Name,
                    Phone = user.PhoneNumber,
                    City = user.City,
                    Street = user.Street,
                    Home = user.Home,
                    FrontDoor = user.FrontDoor,
                    Apartment = user.Apartament,


            });
            }
            
            return View(new Order
            {
                StatusMessage = "Войдите или создайте аккаунт, чтобы сохранить личные данные для будущих заказов и просматривать статус заказа в личном кабинете"

            });
        }
        [HttpPost]
        public IActionResult Checkout(Order order) {
            if (_cart.Lines.Count() == 0) {
                ModelState.AddModelError("", "Извините, ваша корзина пуста");
            }
            if (ModelState.IsValid) {
                order.Lines = _cart.Lines.ToArray();
                order.Created = DateTime.Now;
                order.Updated = DateTime.Now;
                if(order.PaymentWay == "Картой онлайн")
                {
                    order.Paid = false;
                }
                if(_cart.ComputePriceValue() > 40)
                {
                    order.Price = _cart.ComputePriceValue();
                }
                else
                {
                    order.Price = _cart.ComputePriceValue() + 10;
                }


                ApplicationUser user = _unitOfWork.User.GetUser(_signInManager.UserManager.GetUserId(User));
                if(user != null)
                {
                    order.UserID = user.Id;
                }
                _repository.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Completed", new { orderId = order.OrderID });
            } else {
                return View();
            }
        }
    }
}
