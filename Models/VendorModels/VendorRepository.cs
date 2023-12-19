using NorSalStaff_0._1.Models.VendorModels.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.VendorModels
{
    public class VendorRepository
    {
        private readonly AppDbContext context;
        public VendorRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Vendor AddVendor(Vendor vendor)
        {
            context.Vendors.Add(vendor);
            context.SaveChanges();
            return (vendor);
        }
        public Vendor DeleteVendor(int id)
        {
            Vendor vendor = context.Vendors.Find(id);
            if (vendor != null)
            {
                context.Vendors.Remove(vendor);
                context.SaveChanges();
            }
            return (vendor);
        }
        public Vendor UpdateVendor(Vendor vendorChanges)
        {
            var vendor = context.Vendors.Attach(vendorChanges);
            vendor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return (vendorChanges);
        }
        public Vendor GetVendor(int id)
        {
            return context.Vendors.Find(id);
        }
        public IEnumerable<Vendor> GetAllCVendors(int id)
        {
            VendorCompany vendorCompany = context.VendorCompanies.Find(id);
            return vendorCompany.Vendor;
        }
        public IEnumerable<Vendor> GetAllVendors()
        {
            return context.Vendors;
        }
        public VendorCompany AddVendorCompany(VendorCompany vendorCompany)
        {
            context.VendorCompanies.Add(vendorCompany);
            context.SaveChanges();
            return (vendorCompany);
        }
        public VendorCompany DeleteVendorCompany(int id)
        {
            VendorCompany vendorCompany = context.VendorCompanies.Find(id);
            if (vendorCompany != null)
            {
                context.VendorCompanies.Remove(vendorCompany);
                context.SaveChanges();
            }
            return (vendorCompany);
        }
        public VendorCompany UpdateVendorCompany(VendorCompany vendorCompanyChanges)
        {
            var vendorCompany = context.VendorCompanies.Attach(vendorCompanyChanges);
            vendorCompany.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return (vendorCompanyChanges);
        }
        public VendorCompany GetVendorCompany(int id)
        {
            return context.VendorCompanies.Find(id);
        }
        public VendorCompany GetCompanybyVendor(int id)
        {
            Vendor vendor = context.Vendors.Find(id);
            return context.VendorCompanies.Find(vendor);
        }
        public IEnumerable<VendorCompany> GetAllCCompanys()
        {
            return context.VendorCompanies;
        }
    }
}
