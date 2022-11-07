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
    public class ChefsController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IUserHelper _userHelper;


        public ChefsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserHelper userHelper)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _userHelper = userHelper;

        }
        public IActionResult Index()
        {
            var objList = _userHelper.ListOfChefs();
            if (objList.Count > 0)
            {
                return View(objList);
            }
           
            return View(objList);
        }
        //GET -- CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST-- CREATE
        [HttpPost]
        public IActionResult Create(ChefsViewModel obj)
        {
            if (ModelState.IsValid)
            {

                if (obj.NameOfChefs == null)
                {
                    TempData["error"] = "Please Enter Your NameOfChefs";
                    return View(obj);

                }
                if (obj.TypeOfFood == null)
                {
                    TempData["error"] = "Please Enter Your TypeOfFood";
                    return View(obj);

                }
                if (obj.Amount == null)
                {
                    TempData["error"] = "Please Enter Your Amount";
                    return View(obj);

                }
                if (obj.FoodImageUrl == null)
                {
                    TempData["error"] = "Please Enter Your Inage";
                    return View(obj);

                }
                var myFood = _userHelper.FoodCreate(obj);
                if(myFood != null)
                {
                    if (myFood.Contains("Successfully"))
                    {
                        TempData["success"] = "Created Successfully";
                        return RedirectToAction("Index");
                    }
                    if (myFood.Contains("Fail"))
                    {
                        TempData["error"] = "Unable to Create food";
                        return View(obj);
                    }
                }
            }
            return View(obj);
        }

        //GET -- EDIT
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Chefs.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST-- EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Chefs obj)
        {
            if (ModelState.IsValid)
            {

                _context.Chefs.Update(obj);
                _context.SaveChanges();
         
                return RedirectToAction("Index");
            }
          
            return View(obj);
        }

        //GET -- DETELE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.Chefs.Find(id);
            if (obj == null)
            {

                return NotFound();
            }
            return View(obj);
        }

        //POST-- DETELE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _context.Chefs.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Chefs.Remove(obj);
            _context.SaveChanges();
            ViewBag.Message = "One row deleted successfully";
            return RedirectToAction("Index");
        }

        //GET CHEFS FOOD THAT IS IN THE DATABASE//
        //[HttpGet]
        //public IActionResult GetLisstOfFood(int? id)
        //{
        //    if(id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var obj = _context.Chefs.Find(id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(obj);
        //}

    }
}
