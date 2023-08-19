using CleanArch.Application.Contract;
using Framework.Application;
using MediatR;


namespace CleanArch.Application.Command
{
    public class EditAccountCommand: IRequest<OperationResult>
    {
        public OperationResult OperationResult { get; set; }
        public EditCustometDtos EditCustometDto { get; set; }
    }
}
