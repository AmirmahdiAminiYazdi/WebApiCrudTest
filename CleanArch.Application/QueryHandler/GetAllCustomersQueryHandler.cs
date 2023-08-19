using CleanArch.Application.Query;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;


namespace CleanArch.Application.QueryHandler
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return _customerRepository.GetCustomers();
        }
    }
}
