using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Services;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models.AccountViewModels;

namespace WebApp.Controllers
{
	[Route("[controller]/[action]")]
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		 

		public AccountController(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager
			 )
		{
			_userManager = userManager;
			_signInManager = signInManager;
			 
		}

		// GET: /Account/SignIn 
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> SignIn(string returnUrl = null)
		{
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			ViewData["ReturnUrl"] = returnUrl;
			if (!String.IsNullOrEmpty(returnUrl) &&
				returnUrl.ToLower().Contains("checkout"))
			{
				ViewData["ReturnUrl"] = "/Basket/Index";
			}

			return View();
		}

		// POST: /Account/SignIn
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> SignIn(LoginViewModel model, string returnUrl = null)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			ViewData["ReturnUrl"] = returnUrl;

			var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
			if (result.Succeeded)
			{
				string anonymousUserId = Request.Cookies[Constants.WebApp_COOKIENAME];
				if (!String.IsNullOrEmpty(anonymousUserId))
				{
					Response.Cookies.Delete(Constants.WebApp_COOKIENAME);
				}
				return RedirectToLocal(returnUrl);
			}
			ModelState.AddModelError(string.Empty, "Invalid login attempt.");
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();

			return RedirectToAction(nameof(HomeController.Index), "Home");
		}

		[AllowAnonymous]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToLocal(returnUrl);
				}
				AddErrors(result);
			}
			// If we got this far, something failed, redisplay form
			return View(model);
		}

		private IActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
		}

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}
		}
	}
}