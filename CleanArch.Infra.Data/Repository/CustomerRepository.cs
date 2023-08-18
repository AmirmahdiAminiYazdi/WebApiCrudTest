using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }
    }
}
