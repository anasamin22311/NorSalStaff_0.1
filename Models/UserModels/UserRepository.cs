using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.UserModels
{
    public class UserRepository : IUserRepository
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UserRepository(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            return roleManager.Roles;
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return userManager.Users;
        }
        public async Task<Dictionary<ApplicationUser, bool>> GetAllUsersRoleREL(IEnumerable<ApplicationUser> users, string roleName)
        {
            var results = new Dictionary<ApplicationUser, bool>();
            foreach(var user in users.ToList())
            {
                //var check = ;
                if (await userManager.IsInRoleAsync(user, roleName))
                {
                    results[user] = true;
                }
                else
                {
                    results[user] = false;
                }
            };
            //foreach (var user in users)
            //{
            //}
            return (results);
        }
    }
}
