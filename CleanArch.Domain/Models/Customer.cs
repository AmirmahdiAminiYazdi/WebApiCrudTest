namespace CleanArch.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

        public void Edit (string firstname , string lastname,string phoneNumber)
        {
            if (!string.IsNullOrWhiteSpace(firstname))
                Firstname = firstname;
            if (!string.IsNullOrWhiteSpace(lastname))
                Lastname = lastname;
            if (!string.IsNullOrWhiteSpace(phoneNumber))
                PhoneNumber = ulong.Parse(phoneNumber);

        }
    }
}