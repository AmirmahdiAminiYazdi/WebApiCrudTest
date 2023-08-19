using CleanArch.Application.Command;
using CleanArch.Application.Contract;
using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using Framework.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Handler
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateAccountCommand,OperationResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, ICustomerService customerService, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _customerService = customerService;
            _unitOfWork = unitOfWork;

        }
        public  async Task<OperationResult> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();


            if (_customerRepository.ExistsCustomer(x => x.Firstname == request.RegisterAccountDto.Firstname ||
            x.Lastname == request.RegisterAccountDto.Lastname ||
            x.DateOfBirth == request.RegisterAccountDto.DateOfBirth || x.Email == request.RegisterAccountDto.Email))
                return await operation.Failed(ApplicationMessages.DuplicatedRecord);

            if (_customerService.CheckPhoneNumber(request.RegisterAccountDto.PhoneNumber) != true)
                return await operation.Failed(ApplicationMessages.PhoneNumberValidation);

            if (_customerService.IsValidEmail(request.RegisterAccountDto.Email) != true)
                return await operation.Failed(ApplicationMessages.EmailValidation);
            if (_customerService.IsValidBankAccountNumber(request.RegisterAccountDto.BankAccountNumber) != true)
                return await operation.Failed(ApplicationMessages.BankAccountNumberValidation);

          await  _customerRepository.AddCustomer(new Customer
            {
                Firstname = request.RegisterAccountDto.Firstname,
                Lastname = request.RegisterAccountDto.Lastname,
                DateOfBirth = request.RegisterAccountDto.DateOfBirth,
                Email = request.RegisterAccountDto.Email,
                BankAccountNumber = request.RegisterAccountDto.BankAccountNumber,
                PhoneNumber = ulong.Parse(request.RegisterAccountDto.PhoneNumber),
            });
          await  _unitOfWork.CommitAsync();
            return await operation.Succedded();
        }
    }
}
