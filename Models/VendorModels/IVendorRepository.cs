using NorSalStaff_0._1.Models.VendorModels.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.VendorModels
{
    public interface IVendorRepository
    {
        Vendor AddVendor(Vendor vendor);
        Vendor DeleteVendor(int id);
        Vendor UpdateVendor(Vendor vendorChanges);
        Vendor GetVendor(int id);
        IEnumerable<Vendor> GetAllCVendors(int id);
        IEnumerable<Vendor> GetAllVendors();
        VendorCompany AddVendorCompany(VendorCompany vendorCompany);
        VendorCompany DeleteVendorCompany(int id);
        VendorCompany UpdateVendorCompany(VendorCompany vendorCompanyChanges);
        VendorCompany GetVendorCompany(int id);
        VendorCompany GetCompanybyVendor(int id);
        IEnumerable<VendorCompany> GetAllVCompanys();
    }
}
