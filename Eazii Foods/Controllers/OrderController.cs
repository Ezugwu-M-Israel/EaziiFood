using Eazii_Foods.Database;
using Eazii_Foods.IHelper;
using Eazii_Foods.Models;
using Eazii_Foods.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace Eazii_Foods.Controllers
{
    public class OrderController : Controller
    {

        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IUserHelper _userHelper;


        public OrderController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserHelper userHelper)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _userHelper = userHelper;
        }

        [HttpGet]
        public IActionResult PlaceOrder(int foodId)
        {
            if (foodId != 0 )
            {
                ViewBag.State = _userHelper.GetState().Result;
                var newViewModel = new PlaceOrderViewModel();
                newViewModel.FoodId = foodId;
                return View(newViewModel);
            }
            return RedirectToAction("PlaceOrder");
        }

        [HttpPost]
        public IActionResult PlaceOrder(PlaceOrderViewModel placeOrder)
        {
           if(placeOrder != null)
            {
                /*var user = _userManager.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();*/

                var newOredr = new PlaceOrder()
                {
                 /*   UserId = user.Id,*/
                    Name = placeOrder.Name,
                    OrderDate = DateTime.Now,
                    Email = placeOrder.Email,
                    Comment = placeOrder.Comment,
                    PhoneNumber = placeOrder.PhoneNumber,
                    StateId = placeOrder.StateId,
                    FoodId = placeOrder.FoodId,


                };
                _context.PlaceOrders.Add(newOredr);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();  
        }


    }

}
