using NorSalStaff_0._1.Models.CustomerModels.CModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorSalStaff_0._1.Models.CustomerModels
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;
        public CustomerRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Customer AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return (customer);
        }
        public Customer DeleteCustomer(int id)
        {
            Customer customer = context.Customers.Find(id);
            if(customer != null)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
            return (customer);
        }
        public Customer UpdateCustomer(Customer customerChanges)
        {
            var customer = context.Customers.Attach(customerChanges);
            customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return (customerChanges);
        }
        public Customer GetCustomer(int id)
        {
            return context.Customers.Find(id);
        }
        public IEnumerable<Customer> GetAllCCustomers(int id)
        {
            CustomerCompany customerCompany = context.CustomerCompanies.Find(id);
            return customerCompany.Customer;
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return context.Customers;
        }
        public CustomerCompany AddCustomerCompany(CustomerCompany customerCompany)
        {
            context.CustomerCompanies.Add(customerCompany);
            context.SaveChanges();
            return (customerCompany);
        }
        public CustomerCompany DeleteCustomerCompany(int id)
        {
            CustomerCompany customercompany = context.CustomerCompanies.Find(id);
            if (customercompany != null)
            {
                context.CustomerCompanies.Remove(customercompany);
                context.SaveChanges();
            }
            return (customercompany);
        }
        public CustomerCompany UpdateCustomerCompany(CustomerCompany customerCompanyChanges)
        {
            var customerCompany = context.CustomerCompanies.Attach(customerCompanyChanges);
            customerCompany.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return (customerCompanyChanges);
        }
        public CustomerCompany GetCustomerCompany(int id)
        {
            return context.CustomerCompanies.Find(id);
        }
        public CustomerCompany GetCompanybyCustomer(int id)
        {
            Customer customer = context.Customers.Find(id);
            return context.CustomerCompanies.Find(customer);
        }
        public IEnumerable<CustomerCompany> GetAllCCompanys()
        {
            return context.CustomerCompanies;
        }
    }
}
