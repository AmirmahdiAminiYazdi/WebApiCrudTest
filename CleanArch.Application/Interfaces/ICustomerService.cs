using CleanArch.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public interface ICustomerService
    {
        CustomerViewModel GetCustomers();
    }
}
