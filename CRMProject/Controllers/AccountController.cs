using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using CRMProject.BLL.Interfaces;
using Microsoft.Owin.Security;
using CRMProject.Models.ViewModels;
using CRMProject.BLL.DTO;
using System.Security.Claims;

namespace CRMProject.Controllers
{
    public class AccountController : Controller
    {
        private IAccount service;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(IAccount accountService)
        {
            service = accountService;
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                LoginDTO login = new LoginDTO() { Login = model.Login, Password = model.Password };
                ClaimsIdentity claim = await service.SignIn(login);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Wrong login or password");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties()
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        [Authorize]
        public ActionResult SignOut()
        {
            Session.Abandon();
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}