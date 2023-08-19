using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.ViewModels
{
    public class CustomerViewModel
    {
        public Task<IEnumerable<Customer>> Customers { get; set; }
        public Customer Customer { get; set; }
    }
}
