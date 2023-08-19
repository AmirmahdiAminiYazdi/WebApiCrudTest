using Framework.Application;

using System.ComponentModel.DataAnnotations;


namespace CleanArch.Application.Contract
{
    public class EditCustometDtos:RegisterAccountDtos
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int Id { get; set; }
    }
}
