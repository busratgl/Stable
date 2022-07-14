using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Stable.Core.Utilities.Results.Concrete;
using System.Net;
using System.Threading.Tasks;

namespace Stable.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.OK;

                var result = new Result(Core.Utilities.Results.ComplexTypes.Enums.ResultStatus.Error, ex.Message);
                var resultAsJsonString = JsonConvert.SerializeObject(result);
                await httpContext.Response.WriteAsync(resultAsJsonString);
            }
        }
    }
}
