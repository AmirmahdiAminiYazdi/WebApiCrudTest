using CleanArch.Application.Command;
using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using Framework.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.CommandHandler
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, OperationResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteAccountCommandHandler(ICustomerRepository customerRepository,IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
           
            _unitOfWork = unitOfWork;

        }
        public async Task<OperationResult> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var customer =await _customerRepository.GetCustomerById(request.CustomerId);
            if (customer == null)
                return await operation.Failed(ApplicationMessages.RecordNotFound);
            await _customerRepository.DeleteCustomer(customer);
            await _unitOfWork.CommitAsync();
            return await operation.Succedded(ApplicationMessages.UserDeleting);
        }
    }
}
