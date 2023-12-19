using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NorSalStaff_0._1.Models.CustomerModels.CModels;
using NorSalStaff_0._1.Models.ItemModels.IModels;
using NorSalStaff_0._1.Models.OrderModels.OModels;
using NorSalStaff_0._1.Models.VendorModels.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorSalStaff_0._1.ViewModels;
using NorSalStaff_0._1.ViewModels.Account;
using NorSalStaff_0._1.ViewModels.Administration;

namespace NorSalStaff_0._1.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCompany> CustomerCompanies { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorCompany> VendorCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<NorSalStaff_0._1.ViewModels.RegisterViewModel> RegisterViewModel { get; set; }

        public DbSet<NorSalStaff_0._1.ViewModels.Account.LoginViewModel> LoginViewModel { get; set; }

        public DbSet<NorSalStaff_0._1.ViewModels.Administration.CreateRoleViewModel> CreateRoleViewModel { get; set; }

        public DbSet<NorSalStaff_0._1.ViewModels.Account.UsersViewModel> UsersViewModel { get; set; }

        public DbSet<NorSalStaff_0._1.ViewModels.Account.EditViewModel> EditViewModel { get; set; }

        public DbSet<NorSalStaff_0._1.ViewModels.Administration.EditRoleViewModel> EditRoleViewModel { get; set; }
    }
}
