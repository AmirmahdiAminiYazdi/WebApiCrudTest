using CleanArch.Application.Contract;
using CleanArch.Domain.Models;
using Framework.Application;


namespace CleanArch.Application.Services
{
    public interface ICustomerService
    {
   
        bool CheckPhoneNumber(string PhoneNumber);
        bool IsValidEmail(string email);
        bool IsValidBankAccountNumber(string bankAccountNumber);

    }
}
