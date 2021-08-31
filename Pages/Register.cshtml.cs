using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginRegistration.Pages.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginRegistration.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly SignInManager<IdentityUser> _signinmanager;
        public Register Model { get; set; }

        public RegisterModel(UserManager<IdentityUser> usermanager, SignInManager<IdentityUser> signinmanager)
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = Model.Email,
                    Email = Model.Email,

                };

                var result = await _usermanager.CreateAsync(user, Model.Password);

                if (result.Succeeded)
                {
                    await _signinmanager.SignInAsync(user, false);
                    return RedirectToPage("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return Page();

        }
    }
}