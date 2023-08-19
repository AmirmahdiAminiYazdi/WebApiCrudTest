using Framework.Application;
using CleanArch.Application.Contract;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using Framework.Application;
using PhoneNumbers;


namespace CleanArch.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool CheckPhoneNumber(string PhoneNumber)
        {
            var phoneUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
            bool isValidNumber = true;
            try
            {
                
              var phoneNumberParse = phoneUtil.Parse(PhoneNumber, null);

              isValidNumber = phoneUtil.IsValidNumber(phoneNumberParse); // returns true for valid number    

            }
            catch (NumberParseException ex)
            {
                Console.WriteLine("Error parsing the phone number: " + ex.Message);
                return false;
            }

            return isValidNumber;
        }

        public Customer GetCustomerById(int CustomerId)
        {
            var customer = _customerRepository.GetCustomerById(CustomerId);
            return customer;
        }

        public CustomerViewModel GetCustomers()
        {
           return new CustomerViewModel { Customers = _customerRepository.GetCustomers() };
              
        }

        public bool IsValidBankAccountNumber(string bankAccountNumber)
        {
            return !string.IsNullOrEmpty(bankAccountNumber) && bankAccountNumber.Length >= 10;
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public OperationResult Register(RegisterAccountDto registerAccountDto)
        {
            var operation = new OperationResult();

            if (_customerRepository.ExistsCustomer(x => x.Firstname == registerAccountDto.Firstname || x.Lastname == registerAccountDto.Lastname ||
            x.DateOfBirth == registerAccountDto.DateOfBirth ||x.Email == registerAccountDto.Email ))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            if (CheckPhoneNumber(registerAccountDto.PhoneNumber) != true)
                return operation.Failed(ApplicationMessages.PhoneNumberValidation);

            if (IsValidEmail(registerAccountDto.Email) != true)
                return operation.Failed(ApplicationMessages.EmailValidation);
            if (IsValidBankAccountNumber(registerAccountDto.BankAccountNumber) != true)
                return operation.Failed(ApplicationMessages.BankAccountNumberValidation);

            _customerRepository.AddCustomer(new Customer
            {
                Firstname = registerAccountDto.Firstname,
                Lastname = registerAccountDto.Lastname,
                DateOfBirth = registerAccountDto.DateOfBirth,
                Email = registerAccountDto.Email,
                BankAccountNumber = registerAccountDto.BankAccountNumber,
                PhoneNumber = ulong.Parse( registerAccountDto.PhoneNumber),
            });
            _customerRepository.SaveChanges();
            return operation.Succedded();

        }
    }
}
