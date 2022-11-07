using Eazii_Foods.Database;
using Eazii_Foods.IHelper;
using Eazii_Foods.Models;
using Eazii_Foods.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Numerics;

namespace Eazii_Foods.Helper
{
    public class UserHelper: IUserHelper
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserHelper(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ApplicationUser> FindByUserNameAsync(string? username)
        {
            return await _userManager.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
        }

        public ApplicationUser FindByUsername(string? username)
        {
            return _userManager.Users.Where(x => x.UserName == username).FirstOrDefault();
        }


        public string GetUserById(string? username)
        {
            return _userManager.Users.Where(x => x.UserName == username).FirstOrDefaultAsync().Result.Id?.ToString();
        }

        public async Task<ApplicationUser> FindUserByEmail(string? email)
        {
            return await _userManager.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
        public async Task<ApplicationUser> FindUserByIdAsync(string? id)
        {
            return await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public ApplicationUser FindByEmail(string? email)
        {
            return _userManager.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        
        public async Task<ApplicationUser> ChefsRegistertion(ApplicationUserViewModel applicationUserViewModel)
        {
            if (applicationUserViewModel != null)
            {
                var newAppUser = new ApplicationUser();
                {
                    newAppUser.FirstName = applicationUserViewModel.FirstName;
                    newAppUser.MiddleName = applicationUserViewModel.MiddleName;
                    newAppUser.LastName = applicationUserViewModel.LastName;
                    newAppUser.Address = applicationUserViewModel.Address;
                    newAppUser.Gender = applicationUserViewModel.Gender;
                    newAppUser.DateOfBirth = applicationUserViewModel.DateOfBirth;
                    newAppUser.DateRegistered = DateTime.Now;
                    newAppUser.Department = applicationUserViewModel.Department;
                    newAppUser.PhoneNumber = applicationUserViewModel.PhoneNumber;
                    newAppUser.State = applicationUserViewModel.State;
                    newAppUser.UserName = applicationUserViewModel.Email;
                    newAppUser.Email = applicationUserViewModel.Email;
                    newAppUser.Active = true;

                }
                var result = await _userManager.CreateAsync(newAppUser, applicationUserViewModel.Password);
                if (result.Succeeded)
                {
                    return newAppUser;

                }         
            }
            return null;
        }        
         
        public async Task<List<State>> GetState()
       {
            var states = new List<State>();
            var common = new State() 
            {
                Id = 0,
                Name = "__select__"
            };
            var state = await _context.State.Where(u => u.Active && !u.Deleted).OrderBy(c => c.Name).ToListAsync();
            if (state.Count() > 0)
            {
                state.Insert(0,common);
                return state;
            }
            return states;
        }

        public List<FoodViewModel> GetLisstOfFood()
        {
            var allFoods = new List<FoodViewModel>();
            var foods = _context.Food.Where(x => x.Id != 0 && x.Name != null).Select(x => new FoodViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Image = x.Image,

            }).ToList();
            if (foods.Count() > 0 && foods != null)
            {
                return foods;
            }
            return allFoods;
        }

        public FoodViewModel GetFoodByFoodId(int id)
        {
            var food = _context.Food.Where(x => x.Id == id && x.Name != null).FirstOrDefault();
            if (food != null)
            {
                var myFood = new FoodViewModel
                {
                    Id = food.Id,
                    Name = food.Name,
                    Price = food.Price,
                    Image = food.Image,

                };
            }
            return null;
        }

        public bool AddFood(FoodViewModel foodViewModel, string base64)
        {
            if (foodViewModel != null)
            {
                var food = new Food()
                {
                    Name = foodViewModel.Name,
                    Price = foodViewModel.Price,
                    Image = base64,
                    DateCreated = DateTime.Now,
                    Active = true,
                    Deleted = false,
                };
                _context.Food.Add(food);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public string EditFood(FoodViewModel foodViewModel)
        {
            if (foodViewModel != null)
            {
                var Food = _context.Food.Where(x => x.Id == foodViewModel.Id && !x.Deleted).FirstOrDefault();
                if (Food != null)
                {
                    Food.Name = foodViewModel.Name;
                    _context.Food.Update(Food);
                    _context.SaveChanges();
                    return "Food Successfully Updated";
                }
            }
            return "Food failed To Update";
        }

        public string DeleteFood(int? id)
        {
            if (id != 0)
            {
                var food = _context.Food.Where(x => x.Id == id && x.Active == true).FirstOrDefault();
                if (food != null)
                {
                    food.Active = false;
                    food.Deleted = true;
                    _context.Food.Update(food);
                    _context.SaveChanges();
                    return "Food Successfully Deleted";
                }
            }
            return "Food failed To Delete";
        }

        public List<ChefsViewModel> ListOfChefs()
        {
            var listOfChefs = new List<ChefsViewModel>();
            var chef = _context.Chefs.Where(x => x.Id != 0).ToList();
            if (chef.Count > 0)
            {
                foreach (var chefs in chef)
                {
                    var chefsViewModel = new ChefsViewModel()
                    {
                        NameOfChefs = chefs.NameOfChefs,
                        Id = chefs.Id,
                        TypeOfFood = chefs.TypeOfFood,
                        Image = chefs.Image,
                        Amount = chefs.Amount,
                    };
                    listOfChefs.Add(chefsViewModel);
                }
                return listOfChefs;
            }
            return listOfChefs;
        }

        public string FoodCreate(ChefsViewModel foods)
        {
            string foodPixFilePath = string.Empty;

            if (foods.FoodImageUrl != null)
            {
                foodPixFilePath = UploadedFile(foods.FoodImageUrl, "/FoodImage/");
            }
            var newFood = new Chefs
            {
                TypeOfFood = foods.TypeOfFood,
                Amount = foods.Amount,
                Image = foodPixFilePath,
                NameOfChefs = foods.NameOfChefs,
            };

            if (newFood != null)
            {
                _context.Chefs.Add(newFood);
                _context.SaveChanges();
                return ("Food Created Successfully");
            }

            return ("Fail");
        }

        public string UploadedFile(IFormFile filesUrl, string fileLocation)
        {
            string uniqueFileName = string.Empty;

            if (filesUrl != null)
            {
                var upPath = fileLocation.Trim('/');
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, upPath);
                
                string pathString = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", upPath);
                if (!Directory.Exists(pathString))
                {
                    Directory.CreateDirectory(pathString);
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + filesUrl.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    filesUrl.CopyTo(fileStream);
                }
            }
            var generatedPictureFilePath = fileLocation + uniqueFileName;
            return generatedPictureFilePath;
        }

    }
}
