using System;

namespace Framework.Application
{
    public class OperationResult
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }

        public OperationResult()
        {
            IsSuccedded = false;
        }

        public async Task<OperationResult> Succedded(string message = "Operation was successfully completed.")
        {
            IsSuccedded = true;
            Message = message;
            return await Task.FromResult(this);
        }

        public async Task<OperationResult> Failed(string message = "Operation was not successful.")
        {
            IsSuccedded = false;
            Message = message;
            return await Task.FromResult(this);
        }

      
    }
}
