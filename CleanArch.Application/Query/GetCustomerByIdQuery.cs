using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Query
{
    public class GetCustomerByIdQuery: IRequest<Customer>
    {
        public int CustomerId { get; set; }
    }
}
