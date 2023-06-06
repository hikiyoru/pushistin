// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using pushistin.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pushistin.Areas.Identity.Pages.Account.Manage
{
    public class PersDataModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public PersDataModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "Введите имя")]
            public string? Name { get; set; }

            [Required(ErrorMessage = "Введите номер телефона")]
            [Phone(ErrorMessage = "Неверный формат телефона")]
            public string? Phone { get; set; }
            [Required(ErrorMessage = "Введите город")]
            public string? City { get; set; }

            [Required(ErrorMessage = "Введите улицу")]
            public string? Street { get; set; }

            [Required(ErrorMessage = "Введите номер дома")]
            public int? Home { get; set; }
            public int? FrontDoor { get; set; }
            public int? Apartment { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user); TODO: CustomUserManager!???
            var name = user.Name;
            var phoneNumber = user.PhoneNumber;
            var city = user.City;
            var street = user.Street;
            var home = user.Home;
            var frontDoor = user.FrontDoor;
            var apartament = user.Apartament;

            Username = userName;

            Input = new InputModel
            {
                Name = name,
                Phone = phoneNumber,
                City = city,
                Street = street,
                Home = home,
                FrontDoor = frontDoor,
                Apartment = apartament
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var name = user.Name;
            var city = user.City;
            var street = user.Street;
            var home = user.Home;
            var frontDoor = user.FrontDoor;
            var apartament = user.Apartament;

            if (Input.Name != name)
            {
                user.Name = Input.Name;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Phone != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.Phone);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            if (Input.City != city)
            {
                user.City = Input.City;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Street != street)
            {
                user.Street = Input.Street;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Home != home)
            {
                user.Home = Input.Home;
                await _userManager.UpdateAsync(user);
            }
            if (Input.FrontDoor != frontDoor)
            {
                user.FrontDoor = Input.FrontDoor;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Apartment != apartament)
            {
                user.Apartament = Input.Apartment;
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Личные данные сохранены";
            return RedirectToPage();
        }
    }
}
