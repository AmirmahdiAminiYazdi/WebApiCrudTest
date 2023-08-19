using CleanArch.Application.Contract;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Framework.Application;


namespace CleanArch.Application.Services
{
    public interface ICustomerService
    {
      //  CustomerViewModel GetCustomers();
        //CustomerViewModel GetCustomerById(int CustomerId);
        bool CheckPhoneNumber(string PhoneNumber);
        bool IsValidEmail(string email);
        bool IsValidBankAccountNumber(string bankAccountNumber);
        //OperationResult Register (RegisterAccountDto registerAccountDto);
        //OperationResult Edit(EditCustometDto editCustometDto);
        //OperationResult Delete(int CustomerId);
       
    }
}
