using Eazii_Foods.Database;
using Eazii_Foods.Helper;
using Eazii_Foods.IHelper;
using Eazii_Foods.Models;
using Eazii_Foods.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Eazii_Foods.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserHelper _userHelper;

        public AccountController(ApplicationDbContext context,IUserHelper userHelper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _userHelper = userHelper;
        }
        //GET -- REGISTER
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.State = _userHelper.GetState().Result;
            return View();
        }
        //POST-- REGISTER
        [HttpPost]
        public IActionResult  Register(ApplicationUserViewModel applicationUserViewModel)
        {
            ViewBag.State = _userHelper.GetState().Result;
            if (ModelState.IsValid)
            {
                if (applicationUserViewModel.FirstName == null)
                {
                    TempData["error"] = "Please Enter Your FistName";
                    return View(applicationUserViewModel);

                }
                if (applicationUserViewModel.MiddleName == null)
                {
                    TempData["error"] = "Please Enter Your MiddleName";
                    return View(applicationUserViewModel);

                }
                if (applicationUserViewModel.LastName == null)
                {
                    TempData["error"] = "Please Enter Your LastName";
                    return View(applicationUserViewModel);

                }
                if (applicationUserViewModel.Email == null)
                {
                    TempData["error"] = "Please Enter Your Email";
                    return View(applicationUserViewModel);

                }
                if (applicationUserViewModel.Address == null)
                {
                    TempData["error"] = "Please Enter Your Address";
                    return View(applicationUserViewModel);

                }
                if (applicationUserViewModel.Password == null || applicationUserViewModel.ConfirmPassword == null)
                {
                    TempData["error"] = "Please Enter Your password & ConfirmPassword";
                    return View(applicationUserViewModel);

                }
                if (applicationUserViewModel.Password != applicationUserViewModel.ConfirmPassword)
                {
                    TempData["error"] = "Please Enter Your Password & Confirmpassword";
                    return View(applicationUserViewModel);
                }
                if (applicationUserViewModel.StateId == null)
                {
                    TempData["error"] = "Please Enter Your State";
                    return View(applicationUserViewModel);

                }
                if (applicationUserViewModel.Gender == null)
                {
                    TempData["error"] = "Please Enter Your Gender";
                    return View(applicationUserViewModel);

                }
                if (applicationUserViewModel.Department == null)
                {
                    TempData["error"] = "Please Enter Your Department";
                    return View(applicationUserViewModel);

                }
                if (applicationUserViewModel.Branchoffice == null)
                {
                    TempData["error"] = "Please Enter Your Branchoffice";
                    return View(applicationUserViewModel);

                }
                var validateEmail =  _userHelper.FindByEmail(applicationUserViewModel.Email);
                if (validateEmail != null)
                {
                    TempData["error"] = "A user with this email already exist";
                    return View(applicationUserViewModel);
                }

                var createChef = _userHelper.ChefsRegistertion(applicationUserViewModel).Result;
                if (createChef != null)
                {
                    TempData["SMS"] = "Register Successfully";
                    return RedirectToAction("Login");
                }

            } 

            return View();
        }
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        //GET -- LOGIN
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //POST-- LOGIN
        [HttpPost]
        public IActionResult Login(LoginViewModel obj)
        {
            if (obj != null)
            {
                if (obj.UserName == null)
                {
                    TempData["errors"] = "please input username";
                    return View(obj);
                }
                if (obj.Password == null)
                {
                    TempData["error"] = "Please put password";
                    return View(obj);
                }

                var existing = _userManager.Users.Where(u => u.UserName == obj.UserName).FirstOrDefault();

                
                if (existing != null)

                {
                    var PasswordSigin = _signInManager.PasswordSignInAsync(obj.UserName, obj.Password, true, false).Result;
                    if (PasswordSigin.Succeeded)
                    {
                       
                        var use3er = User.Identity.IsAuthenticated;
                            TempData["success"] = "Successfully!";
                            return RedirectToAction("Index", "Home");
                        
                    }
                }
                else
                {
                    TempData["error"] = "Username does not Exist!";
                    return View(obj);
                }
            }
            TempData["error"] = "Login was Failed!";
            return View(obj);
        }

    }
}
