﻿namespace Framework.Application
{
    public class OperationResult
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }

        public OperationResult()
        {
            IsSuccedded = false;
        }

        public OperationResult Succedded(string message = "Operation was successfully completed")
        {
            IsSuccedded = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message = "The operation was not successfu")
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }
    }
}