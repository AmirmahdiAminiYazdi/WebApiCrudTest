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
    public class EditAccountCommandHandler : IRequestHandler<EditAccountCommand, OperationResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;
        private readonly IUnitOfWork _unitOfWork;
        public EditAccountCommandHandler(ICustomerRepository customerRepository, ICustomerService customerService, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _customerService = customerService;
            _unitOfWork = unitOfWork;

        }
        public async Task<OperationResult> Handle(EditAccountCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var customer =await _customerRepository.GetCustomerById(request.EditCustometDto.Id);
            
            if (customer == null)
                return await operation.Failed(ApplicationMessages.RecordNotFound);
            if (_customerRepository.ExistsCustomer(x =>
                (x.Email == request.EditCustometDto.Email) && x.Id != request.EditCustometDto.Id))
                return await operation.Failed(ApplicationMessages.DuplicatedRecord);
            if (_customerService.CheckPhoneNumber(request.EditCustometDto.PhoneNumber) != true)
                return await operation.Failed(ApplicationMessages.PhoneNumberValidation);

            if (_customerService.IsValidEmail(request.EditCustometDto.Email) != true)
                return await operation.Failed(ApplicationMessages.EmailValidation);

            if (_customerService.IsValidBankAccountNumber(request.EditCustometDto.BankAccountNumber) != true)
                return await operation.Failed(ApplicationMessages.BankAccountNumberValidation);

            customer.Edit(request.EditCustometDto.Firstname, request.EditCustometDto.Lastname, request.EditCustometDto.PhoneNumber, request.EditCustometDto.Email, request.EditCustometDto.BankAccountNumber);
            await _unitOfWork.CommitAsync();
            return await operation.Succedded();
        }
    }
}
