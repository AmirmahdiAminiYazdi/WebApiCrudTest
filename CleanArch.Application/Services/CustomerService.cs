
using PhoneNumbers;


namespace CleanArch.Application.Services
{
    public class CustomerService : ICustomerService
    {
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
        
    }
}
