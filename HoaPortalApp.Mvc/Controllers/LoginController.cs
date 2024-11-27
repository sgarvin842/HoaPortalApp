using HoaPortalApp.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HoaPortalApp.Api.Routing;
using HoaPortalApp.Application.Features.Auth.Requests.Commands;

namespace HoaPortalApp.Mvc.Controllers
{
    public class LoginController : Controller
    {

        private readonly HttpClient _httpClient;

        public LoginController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a login command object from the model
                var loginCommand = new LoginCommand
                {
                    // Assuming the LoginCommand has properties for username and password
                    Email = model.Email,
                    Password = model.Password
                };

                // Send a POST request to the AuthController
                var response = await _httpClient.PostAsJsonAsync(AuthRouting.Actions.Login, loginCommand);

                if (response.IsSuccessStatusCode)
                {
                    // Handle successful login (set cookies, etc.)
                    // You may need to extract token information or similar from the response
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Handle error response
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, "Invalid login attempt: " + errorResponse);
                }
            }

            // If we got this far, something failed, redisplay the form
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
