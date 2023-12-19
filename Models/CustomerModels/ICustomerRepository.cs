using NorSalStaff_0._1.Models.CustomerModels.CModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.CustomerModels
{
    public interface ICustomerRepository
    {
        Customer AddCustomer(Customer customer);
        Customer DeleteCustomer(int id);
        Customer UpdateCustomer(Customer customerChanges);
        Customer GetCustomer(int id);
        IEnumerable<Customer> GetAllCCustomers(int id);
        IEnumerable<Customer> GetAllCustomers();
        CustomerCompany AddCustomerCompany(CustomerCompany customerCompany);
        CustomerCompany DeleteCustomerCompany(int id);
        CustomerCompany UpdateCustomerCompany(CustomerCompany customerCompanyChanges);
        CustomerCompany GetCustomerCompany(int id);
        CustomerCompany GetCompanybyCustomer(int id);
        IEnumerable<CustomerCompany> GetAllCCompanys();
    }
}
