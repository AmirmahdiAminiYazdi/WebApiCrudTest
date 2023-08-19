using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using CleanArch.Application.Contract;

namespace CleanArch.Application.Command
{
    public class CreateAccountCommand:IRequest<OperationResult>
    {
        public OperationResult OperationResult { get;set; }
        public RegisterAccountDtos RegisterAccountDto { get; set; }
    }
}
