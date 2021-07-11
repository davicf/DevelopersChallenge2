using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Threading.Tasks;
using Xayah.Finances.Api.Shared;
using Xayah.Finances.Domain.Common.Exception;

namespace Xayah.Finances.Api.Configuration.Options
{
    public static class ExceptionHandlerOptionsFactory
    {
        public static ExceptionHandlerOptions Create()
        {
            return new ExceptionHandlerOptions
            {
                ExceptionHandler = Handle,
                ExceptionHandlingPath = null
            };
        }

        private static async Task Handle(this HttpContext context)
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error is ResourceNotFoundException)
            {
                await HandleExceptionAsync(context, exceptionHandlerPathFeature?.Error.Message, HttpStatusCode.NotFound);
            }
            else if (exceptionHandlerPathFeature?.Error is BusinessRuleException)
            {
                await HandleExceptionAsync(context, exceptionHandlerPathFeature?.Error.Message, HttpStatusCode.UnprocessableEntity);
            }
            else if (exceptionHandlerPathFeature?.Error is UnauthorizedAccessException)
            {
                await HandleExceptionAsync(context, exceptionHandlerPathFeature?.Error.Message, HttpStatusCode.Unauthorized);
            }
            else
            {
                await HandleExceptionAsync(context, "Internal server error", HttpStatusCode.InternalServerError);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, string mensage, HttpStatusCode httpStatusCode)
        {
            var err = new ErrorDto { Status = ((int)httpStatusCode).ToString(), Mensage = mensage };
            context.Response.StatusCode = (int)httpStatusCode;
            context.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(err, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            await context.Response.WriteAsync(result).ConfigureAwait(false);
        }
    }
}
