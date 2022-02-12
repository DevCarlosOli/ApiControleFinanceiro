using System;
using System.Collections.Generic;

namespace ApiControleFinanceiro.ApiControleFinanceiro.Domain.Models
{
    public class ErrorModel
    {
        public ErrorModel()
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetails>();
        }

        public ErrorModel(string code, string message)
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetails>();
            AddError(code, message);
        }

        public string TraceId { get; private set; }
        public List<ErrorDetails> Errors { get; private set; }

        public class ErrorDetails
        {
            public ErrorDetails(string code, string message)
            {
                Code = code.ToString();
                Message = message;
            }

            public string Code { get; private set; }

            public string Message { get; private set; }
        }

        public void AddError(string code, string message)
        {
            Errors.Add(new ErrorDetails(code, message));
        }
    }
}
