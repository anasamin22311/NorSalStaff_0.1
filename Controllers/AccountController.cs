using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NorSalStaff_0._1.Models.UserModels;
using NorSalStaff_0._1.ViewModels;
using NorSalStaff_0._1.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
                                 SignInManager<ApplicationUser> signInManager, IWebHostEnvironment webHostEnvironment)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (Url.IsLocalUrl(ViewBag.ReturnUrl))
                {
                    return Redirect(ViewBag.ReturnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {

            ViewBag.ReturnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UseName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(ViewBag.ReturnUrl) && Url.IsLocalUrl(ViewBag.ReturnUrl))
                    {
                        return Redirect(ViewBag.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid Login Attempt");
            }
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Index()
        {
            IEnumerable<ApplicationUser> users = userManager.Users;
            return View(users);
        }

        public async Task<IActionResult> Details(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            List<string> Roles = new List<string>();
            IEnumerable<IdentityRole> roles = roleManager.Roles;
            if (roles.Any())
            {
                foreach (var role in roles.ToList())
                {
                    if (userManager.IsInRoleAsync(user, role.Name).Result)
                    {
                        Roles.Add(role.Name);
                    }
                };
            }
            else
            {
                Roles = null;
            }
            UsersViewModel usersViewModel = new UsersViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                BirthDate = user.BirthDate,
                SWWU = user.SWWU,
                Salary = user.Salary,
                Target = user.Target,
                Achieved = user.Achieved,
                Image = user.Image,
                Roles = Roles
            };
            return View(usersViewModel);
        }

        [AcceptVerbs("Get", "Post")]
        [Authorize]
        public async Task<IActionResult> IsEmailInUse(string Email)
        {
            var email = await userManager.FindByEmailAsync(Email);
            if (!(email == null))
            {
                return Json($"Email '{Email}' is already taken");
            }
            else
            {
                return Json(true);
            }
        }
        [AcceptVerbs("Get", "Post")]
        [Authorize]
        public async Task<IActionResult> IsUserNameInUse(string UserName)
        {
            var userName = await userManager.FindByNameAsync(UserName);
            if (!(userName == null))
            {
                return Json($"Usernname '{UserName}' is already taken");
            }
            else
            {
                return Json(true);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Image != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img", "Users");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                else
                {
                    uniqueFileName = "Default.png";
                }
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    BirthDate = model.BirthDate,
                    SWWU = model.SWWU,
                    Salary = model.Salary,
                    Image = uniqueFileName
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Account");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            EditViewModel model = new EditViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                BirthDate = user.BirthDate,
                SWWU = user.SWWU,
                Salary = user.Salary,
                Target = user.Target,
                Achieved = user.Achieved,
                SImage = user.Image
            };
            IEnumerable<IdentityRole> roles = roleManager.Roles;
            foreach(var role in roles.ToList())
            {
                if(userManager.IsInRoleAsync(user, role.Name).Result)
                {
                    RoleUserViewModel roleUserViewModel = new RoleUserViewModel()
                    {
                        Id = role.Id,
                        RoleName = role.Name,
                        IsChecked = true
                    };
                    model.Roles.Add(roleUserViewModel);
                }
                else
                {
                    RoleUserViewModel roleUserViewModel = new RoleUserViewModel()
                    {
                        Id = role.Id,
                        RoleName = role.Name,
                        IsChecked = false
                    };
                    model.Roles.Add(roleUserViewModel);
                }
            };
            //string uniqueFileName = null;
            //if (model.Image != null)
            //{
            //    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img", "Users");
            //    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
            //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
            //}
            //var result = await userManager.UpdateAsync(user);
            //if (result.Succeeded)
            //{
            //    return RedirectToAction("Details", "Account", id);
            //}
            //foreach (var err in result.Errors)
            //{
            //    ModelState.AddModelError("", err.Description);
            //}
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.Id);
                string uniqueFileName = null;
                if (model.Image != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img", "Users");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    user.Image = uniqueFileName;
                }
                user.UserName = model.UserName;
                user.PhoneNumber = model.PhoneNumber;
                user.BirthDate = model.BirthDate;
                user.SWWU = model.SWWU;
                user.Salary = model.Salary;
                user.Target = model.Target;
                user.Achieved = model.Achieved;
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    foreach (var roleModel in model.Roles)
                    {
                        IdentityRole role = await roleManager.FindByIdAsync(roleModel.Id);
                        IdentityResult userResult = null;
                        if (roleModel.IsChecked && !(await userManager.IsInRoleAsync(user, role.Name)))
                        {
                            userResult = userManager.AddToRoleAsync(user, role.Name).Result;
                        }
                        else if (!roleModel.IsChecked && await userManager.IsInRoleAsync(user, role.Name))
                        {
                            userResult = userManager.RemoveFromRoleAsync(user, role.Name).Result;
                        }
                        else
                        {
                            continue;
                        }
                        if (userResult.Succeeded)
                        {
                            continue;
                        }
                        else
                        {
                            foreach (var err in userResult.Errors)
                            {
                                ModelState.AddModelError("", err.Description);
                            }
                        }
                    }
                    return RedirectToAction("Details", "Account", new { id = user.Id });
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
                //EditViewModel model = new EditViewModel()
                //{
                //    Id = user.Id,
                //    UserName = user.UserName,
                //    PhoneNumber = user.PhoneNumber,
                //    BirthDate = user.BirthDate,
                //    SWWU = user.SWWU,
                //    Salary = user.Salary,
                //    Target = user.Target,
                //    Achieved = user.Achieved,
                //    SImage = user.Image
                //};
                return View(model);
            };
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Delete(string Id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(Id);
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Account");
            }
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
            return View();
        }
    }
}
