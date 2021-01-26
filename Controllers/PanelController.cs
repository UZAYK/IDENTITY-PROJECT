using IdentityProject.Context;
using IdentityProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProject.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public PanelController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }
        public async Task<IActionResult> UpdateUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel
            {
                Email = user.Email,
                Name = user.Name,
                SurName = user.SurName,
                PhoneNumber = user.PhoneNumber,
                PictureUrl = user.PictureUrl
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (model.Picture != null)
                {
                    var uygulamanınCalistigiYer = Directory.GetCurrentDirectory();
                    var uzanti = Path.GetExtension(model.Picture.FileName);
                    var resimAd = Guid.NewGuid() + uzanti;
                    var kaydedilcekYer = uygulamanınCalistigiYer + "/wwwroot/img/" + resimAd;
                    var stream = new FileStream(kaydedilcekYer, FileMode.Create);

                    await model.Picture.CopyToAsync(stream);
                    user.PictureUrl = resimAd;
                }
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
