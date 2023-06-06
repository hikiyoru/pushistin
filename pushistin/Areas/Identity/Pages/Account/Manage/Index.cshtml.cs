// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using pushistin.Areas.Identity.Data;
using pushistin.Core.Repositories;
using pushistin.Core.ViewModels;
using pushistin.Models;
using pushistin.Pages.Order;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pushistin.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IOrderRepository _repository;
        public IEnumerable<Order> _orders { get; set; }
           = Enumerable.Empty<Order>();
        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEnumerable<Order> orders,
            IOrderRepository repository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _orders = orders;
            _repository = repository;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            _orders = _repository.Orders.Where(o => o.UserID == user.Id).OrderByDescending(o => o.OrderID);
            return Page();
        }
    }
}
