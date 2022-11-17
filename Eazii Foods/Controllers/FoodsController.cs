using Eazii_Foods.Database;
using Eazii_Foods.Helper;
using Eazii_Foods.IHelper;
using Eazii_Foods.Models;
using Eazii_Foods.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Numerics;

namespace Eazii_Foods.Controllers
{
    public class FoodsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserHelper _userHelper;

        public FoodsController(ApplicationDbContext context, IUserHelper userHelper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _userHelper = userHelper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = _userManager.FindByEmailAsync(User.Identity.Name).Result;
            var roleCheck = _userManager.GetRolesAsync(user).Result;
            var allfoods = _userHelper.GetLisstOfFood();
            if (allfoods != null && allfoods.Count > 0)
            {
                return View(allfoods);
            }
            return View(allfoods);
        }

        [HttpGet]
        public IActionResult GetFood()
        {
            var foods = _userHelper.GetLisstOfFood();
            if (foods != null && foods.Count > 0)
            {
                return View(foods);
            }
            return View(foods);
        }
     
        [HttpPost]
        public JsonResult AddFood(string foodDetails, string base64)
        {
            if (foodDetails != null && base64 != null)
            {
                var foodViewModel = JsonConvert.DeserializeObject<FoodViewModel>(foodDetails);
                if (foodViewModel != null)
                {
                    var addFood = _userHelper.AddFood(foodViewModel, base64);
                    if (addFood)
                    {
                        return Json(new { isError = false, msg = "Food created Successfully" });
                    }
                    return Json(new { isError = true, msg = "Unable to create food" });
                }
            }
            return Json(new { isError = true, msg = "Error ocurred" });
        }

        [HttpPost]
        public JsonResult EditFood(FoodViewModel foodViewModel)
        {
            if (foodViewModel != null)
            {
                var editFood = _userHelper.EditFood(foodViewModel);
                if (editFood != null)
                {
                    return Json(new { isError = false, msg = "Food Edited Successfully" });
                }
                return Json(new { isError = true, msg = "Unable To Edit Food" });
            }
            return Json(new { isError = true, msg = "Error occured" });
        }    
      
        [HttpPost]
        public JsonResult DeleteFood(int id)
        {
            if (id != 0)
            {
                var deleteFood = _userHelper.DeleteFood(id);
                if (deleteFood != null)
                {
                    return Json(new { isError = false, msg = "Food Delete Successfully" });
                }
                return Json(new { isError = true, msg = "Unable To Delete Food" });

            }
            return Json(new { isError = true, msg = "Error Occured" });
        }

        //public string UploadedFile(Doctor filesSender)
        //{
        //    string uniqueFileName = string.Empty;

        //    if (filesSender.ImageUrl != null)
        //    {
        //        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "doctorUploads");
        //        string pathString = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "doctorUploads");
        //        if (!Directory.Exists(pathString))
        //        {
        //            Directory.CreateDirectory(pathString);
        //        }
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + filesSender.ImageUrl.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            // filesSender.ImageUrl.CopyTo(fileStream);
        //        }
        //    }
        //    var generatedPictureFilePath = "/doctorUploads/" + uniqueFileName;
        //    return generatedPictureFilePath;
        //}

    }
}
