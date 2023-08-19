using CleanArch.Application.Query;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using Framwork.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.QueryHandler
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {

                var result = await _customerRepository.GetCustomerById(request.CustomerId);
                if (result == null)
                {
                    throw new AppException(ApiResultStatusCode.NotFound, $"Customer not found", System.Net.HttpStatusCode.NotFound);
                }
                return result;
           
        }
    }
}
