using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NorSalStaff_0._1.Models.UserModels;
using NorSalStaff_0._1.ViewModels.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserRepository userRepository;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IUserRepository userRepository)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.userRepository = userRepository;
        }

        public ActionResult Index()
        {
            IEnumerable<IdentityRole> Roles = roleManager.Roles;
            return View(Roles);
        }

        public ActionResult Details(string id)
        {
            IdentityRole role = roleManager.FindByIdAsync(id).Result;
            IEnumerable<ApplicationUser> users = userManager.Users;
            List<ApplicationUser> RoleUser = new List<ApplicationUser>();
            if (users.Any())
            {
                foreach (var user in users.ToList())
                {
                    if(userManager.IsInRoleAsync(user, role.Name).Result)
                    {
                        RoleUser.Add(user);
                    }
                };
            }
            else
            {
                RoleUser = null;
            }
            DetailRoleViewModel model = new DetailRoleViewModel()
            {
                Id = id,
                Role = role,
                Users = RoleUser
            };
            return View(model);
        }

        [AcceptVerbs("Get", "Post")]
        [Authorize]
        public async Task<IActionResult> DoesRoleExist(string RoleName)
        {
            var roleName = await roleManager.FindByNameAsync(RoleName);
            if (!(roleName == null))
            {
                return Json($"The role '{RoleName}' already exists");
            }
            else
            {
                return Json(true);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateRoleViewModel model = new CreateRoleViewModel();
            var users = userManager.Users;
            foreach(var user in users)
            {
                UserRoleViewModel userRoleModel = new UserRoleViewModel()
                {
                    UserId = user.Id,
                    User = user,
                    IsChecked = false
                };
                model.Users.Add(userRoleModel);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = model.RoleName
                };
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    foreach (var userMod in model.Users)
                    {
                        ApplicationUser user = await userManager.FindByIdAsync(userMod.UserId);
                        IdentityResult userResult = null;
                        if (userMod.IsChecked && !(await userManager.IsInRoleAsync(user, role.Name)))
                        {
                            userResult = userManager.AddToRoleAsync(user, role.Name).Result;
                        }
                        else if (!userMod.IsChecked && await userManager.IsInRoleAsync(user, role.Name))
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
                    return RedirectToAction("Details", "Administration", new { id = role.Id });
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(model);
        }

        // GET: AdministrationController/Edit/5
        public ActionResult Edit(string id)
        {
            var users = userManager.Users;
            var role = roleManager.FindByIdAsync(id).Result;
            ViewBag.role = role;
            var userRoleRel = userRepository.GetAllUsersRoleREL(users, role.Name).Result;
            List<EditRoleViewModel> model = new List<EditRoleViewModel>();
            foreach(var userData in userRoleRel)
            {
                EditRoleViewModel userRoleViewModel = new EditRoleViewModel()
                {
                    UserId = userData.Key.Id,
                    User = userManager.FindByIdAsync(userData.Key.Id).Result,
                    IsChecked = userData.Value
                };
                model.Add(userRoleViewModel);
            };
            //IdentityRole role = await roleManager.FindByIdAsync(id);
            //ViewBag.RoleId = id;
            //List<EditRoleViewModel> model = new List<EditRoleViewModel>();
            //foreach(ApplicationUser user in userManager.Users)
            //{
            //    EditRoleViewModel editRoleViewModel = new EditRoleViewModel()
            //    {
            //        UserId = user.Id,
            //        UserName = user.UserName
            //    };

            //    //if(await userManager.IsInRoleAsync(user, role.Name))
            //    //{
            //    //    editRoleViewModel.IsChecked = true;
            //    //}
            //    //else
            //    //{
            //    //    editRoleViewModel.IsChecked = false;
            //    //}
            //    model.Add(editRoleViewModel);
            //};
            return View(model);
        }

        // POST: AdministrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(List<EditRoleViewModel> model, string roleId, string roleName)
        {
            if (ModelState.IsValid)
            {
                IdentityRole Role = await roleManager.FindByIdAsync(roleId);
                Role.Name = roleName;
                var result = roleManager.UpdateAsync(Role).Result;
                if (result.Succeeded)
                {
                    foreach (var userMod in model)
                    {
                        ApplicationUser user = await userManager.FindByIdAsync(userMod.UserId);
                        IdentityResult userResult = null;
                        if (userMod.IsChecked && !(await userManager.IsInRoleAsync(user, Role.Name)))
                        {
                            userResult = userManager.AddToRoleAsync(user, Role.Name).Result;
                        }
                        else if (!userMod.IsChecked && await userManager.IsInRoleAsync(user, Role.Name))
                        {
                            userResult = userManager.RemoveFromRoleAsync(user, Role.Name).Result;
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
                    return RedirectToAction("Details", "Administration", new { id = Role.Id });
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
                return View();
            }
            return View();
        }

        // GET: AdministrationController/Delete/5
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Delete(string Id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(Id);
            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Administration");
            }
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
            return View();
        }
    }
}
