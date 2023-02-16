using Boss.Auth.Model.ViewModels.Res;
using Newtonsoft.Json;
using System.Net;

namespace Boss.Auth.WebApi.Middlewares
{
    public class ExceptionLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionLogMiddleware> _logger;
        public ExceptionLogMiddleware(RequestDelegate next, ILogger<ExceptionLogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
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

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            if (ex == null) return;

            if (ex is UnauthorizedAccessException) 
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            else if (ex is Exception) 
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            _logger.LogError(ex,$"系统出现异常:{ex.Message}");

            context.Response.ContentType = "application/json";
            var dto = new ResponseDto<string>();
            dto.Code = ResponseCode.GlobalExption;
            dto.Message = "系统出现异常,请稍后在试";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(dto)).ConfigureAwait(false);
        }
    }
}
