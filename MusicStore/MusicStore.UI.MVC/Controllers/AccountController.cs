using MusicStore.BLL.Abstract;
using MusicStore.MODEL.Entities;
using MusicStore.UI.MVC.Models;
using MusicStore.UI.MVC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MusicStore.UI.MVC.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Login()
        {
            // web.config'e ekleme yapılacak
            if (User.Identity.IsAuthenticated)   
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                User currentUser = _userService.GetUserByLogin(user.Username, user.Password);

                if (currentUser != null && currentUser.IsActive)
                {
                    FormsAuthentication.SetAuthCookie(currentUser.UserName, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Error = "Kullanıcı Bulunamadı";                
            }
            return View();
           
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            user.ActivationCode = Guid.NewGuid();
            _userService.Insert(user);

            bool result = MailHelper.AktivasyonKoduGonder(user.UserName, user.Email, user.ActivationCode);

            if (result)
            {
                TempData["Mesaj"] = $"{user.Email} adresli mail kutunuzu kontrol ediniz";
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "Aktivasyon maili gönderilemedi.");
                return View();
            }
        }
        public ActionResult ActivationUser(Guid id)
        {

            User confirmUser = _userService.GetUserByActivation(id);
            if (confirmUser != null)
            {
                confirmUser.IsActive = true;
            }
            _userService.Update(confirmUser);

            return RedirectToAction("Login");
        }
    }
}