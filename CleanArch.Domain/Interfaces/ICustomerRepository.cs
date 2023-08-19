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
        Task AddCustomer(Customer customer);
       bool ExistsCustomer(Expression<Func<Customer, bool>> expression);
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int CustomerId);
        Task DeleteCustomer(Customer customer);
        Task SaveChanges();
    }
}
