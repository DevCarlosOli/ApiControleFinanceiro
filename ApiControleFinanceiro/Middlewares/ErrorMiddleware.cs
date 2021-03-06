using ApiControleFinanceiro.ApiControleFinanceiro.Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiControleFinanceiro.ApiControleFinanceiro.Domain.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //TODO: Gravar log de erro 500.

            ErrorModel errorModel;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ||
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Qa")
            {
                errorModel = new ErrorModel("erro_validacao", "O 'ID' da categoria não é editável/filtravel, precisa selecionar por 'nome' da categoria!");
            }
            else
            {
                errorModel = new ErrorModel(HttpStatusCode.InternalServerError.ToString(), "An internal server error has occurred.");
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(errorModel);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
