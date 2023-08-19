using Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Contract
{
    public class EditCustometDto:RegisterAccountDto
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int Id { get; set; }
    }
}
