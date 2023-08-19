using Framework.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Command
{
    public class DeleteAccountCommand:IRequest<OperationResult>
    {
        public OperationResult OperationResult { get; set; }
        public int CustomerId { get; set; }
    }
}
