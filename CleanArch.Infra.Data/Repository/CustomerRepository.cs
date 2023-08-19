using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CRUDContext _context;
       
        public CustomerRepository(CRUDContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public bool ExistsCustomer(Expression<Func<Customer, bool>> expression)
        {
            return _context.Set<Customer>().Any(expression);
        }

        public Customer GetCustomerById(int CustomerId)
        {
            return _context.Customers.Find(CustomerId);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
