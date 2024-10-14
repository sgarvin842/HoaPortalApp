using HoaPortalApp.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HoaPortalApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult PaymentModal()
        {
            return View();
        }
        public IActionResult AutopayModal()
        {
            return View();
        }
        public IActionResult ConfirmDeleteModal()
        {
            return View();
        }
        public IActionResult Payments()
        {
            return View();
        }
        public IActionResult ContactInfo()
        {
            return View();
        }
        public IActionResult MyItems()
        {
            return View();
        }
        public IActionResult CalendarAndEvents()
        {
            return View();
        }
        public IActionResult Directory()
        {
            return View();
        }
        public IActionResult Documents()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
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
