using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.UserModels
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetAllUsers();
        IEnumerable<IdentityRole> GetAllRoles();
        Task<Dictionary<ApplicationUser, bool>> GetAllUsersRoleREL(IEnumerable<ApplicationUser> users, string roleName);

    }
}
