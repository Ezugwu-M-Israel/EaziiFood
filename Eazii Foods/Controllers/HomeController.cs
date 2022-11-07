using Eazii_Foods.IHelper;
using Eazii_Foods.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Eazii_Foods.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserHelper _userHelper;


        public HomeController(ILogger<HomeController> logger, IUserHelper userHelper)
        {
            _logger = logger;
            _userHelper = userHelper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.State = _userHelper.GetState().Result;
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