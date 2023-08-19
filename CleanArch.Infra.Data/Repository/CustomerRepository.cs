using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddCustomer(Customer customer)
        {
           await _context.Customers.AddAsync(customer);
        }

        public async Task DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public bool ExistsCustomer(Expression<Func<Customer, bool>> expression)
        {

            return  _context.Set<Customer>().Any(expression);
        }

        public async Task<Customer> GetCustomerById(int CustomerId)
        {

           
              var result=  await _context.Customers.Where(x => x.Id == CustomerId).SingleOrDefaultAsync();
            return result;
           
        }

        public  async Task<IEnumerable<Customer>> GetCustomers()
        {
         return await _context.Customers.ToListAsync();
        }

        public async Task  SaveChanges()
        {
          await  _context.SaveChangesAsync();
        }

        
    }
}
