using Eazii_Foods.Database;
using Eazii_Foods.Helper;
using Eazii_Foods.IHelper;
using Eazii_Foods.Models;
using Eazii_Foods.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eazii_Foods.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IUserHelper _userHelper;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserHelper userHelper)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _userHelper = userHelper;
        }

        public IActionResult Index()
        {
            ViewBag.State = _userHelper.GetState().Result;
            ViewBag.Layout = _userHelper.GetRoleLayout(User.Identity.Name);
            var showAllChefs = _userHelper.ListOfChefs();
            if (showAllChefs.Count() > 0)
            {
                return View(showAllChefs);
            }

            return View();
        }

        //[HttpGet]
        public IActionResult AvailableChefs()
        {
            var chef = _userHelper.GetAllChefs();
            return View(chef);

        }

    }
}
