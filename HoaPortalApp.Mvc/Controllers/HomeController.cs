using HoaPortalApp.Api.Routing;
using HoaPortalApp.Application.Contracts.Identity;
using HoaPortalApp.Application.Features.Auth.Requests.Commands;
using HoaPortalApp.Mvc.Models;
using Microsoft.AspNetCore.Authentication;
using static System.Net.Mime.MediaTypeNames;
using HoaPortalApp.Application.Features.Users.Results;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using HoaPortalApp.Domain.AppMetaData;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Tls;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;

namespace HoaPortalApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public HomeController(IHttpContextAccessor httpContextAccessor, ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [AllowAnonymous]
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

                try
                {
                    // Send a POST request to the AuthController
                    var response = await _httpClient.PostAsJsonAsync(AuthRouting.Actions.Login, loginCommand);



                    if (response.IsSuccessStatusCode)
                    {
                        var token = await response.Content.ReadAsStringAsync();
                        var userModel = JsonSerializer.Deserialize<LoginResponse>(token);

                        // Set the JWT token as a cookie
                        _httpContextAccessor.HttpContext.Response.Cookies.Append("JwtToken", userModel.data.token, new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = false,
                            SameSite = SameSiteMode.Strict,
                            Expires = DateTime.UtcNow.AddDays(7),  // Set expiration based on your requirements
                            IsEssential = true
                        });

                        var jsonToken = new JwtSecurityTokenHandler().ReadToken(userModel.data.token) as JwtSecurityToken;
                        var username = jsonToken?.Claims?.FirstOrDefault().Value;


                        // Redirect to the ReturnUrl or default to Index
                        return Redirect(string.IsNullOrEmpty(model.ReturnUrl) ? Url.Action("Index", "Home") : model.ReturnUrl);
                    }
                    else
                    {
                        // Handle error response
                        var errorResponse = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, "Invalid login attempt: " + errorResponse);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            // If we got this far, something failed, redisplay the form
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["Message"] = "You have successfully logged out.";
            return RedirectToAction("Login", "Home");
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult PaymentModal()
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult AutopayModal()
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ConfirmDeleteModal()
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Payments()
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ContactInfo()
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult MyItems()
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CalendarAndEvents()
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Directory()
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Documents()
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)][Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Index()
        {
 
            var userId = User.Claims.Where(x => x.Type == CustomClaimTypes.Uid).Select(x => x.Value).First();
            var queryString = $"{Router.UserRouting.Actions.GetUserSummary}?userId={userId}";
            Console.WriteLine(_httpClient.BaseAddress + queryString);

            var response = await _httpClient.GetAsync(queryString);
            
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var userModel = JsonSerializer.Deserialize<UserSummaryResult>(responseContent);
                return View(userModel);
            }
            else
            {
                // Handle error response
                var errorResponse = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, "Something happened: " + errorResponse);
            }

            return RedirectToAction("Login", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
