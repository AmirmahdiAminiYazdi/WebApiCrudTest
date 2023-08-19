using Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.Contract
{
    public class RegisterAccountDtos
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Lastname { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string BankAccountNumber { get; set; }
    }
   
}