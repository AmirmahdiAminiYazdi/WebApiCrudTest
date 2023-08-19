using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        bool ExistsCustomer(Expression<Func<Customer, bool>> expression);
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(int CustomerId);
        void DeleteCustomer(Customer customer);
        void SaveChanges();
    }
}
