using Newtonsoft.Json;
using System.Diagnostics;
using System.Dynamic;
using System.Text;
using System.Web;

namespace Boss.Auth.WebApi.Middlewares
{
    public class RequestResponseLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLogMiddleware> _logger;
        private readonly Stopwatch _stopwatch;

        public RequestResponseLogMiddleware(RequestDelegate next,
            ILogger<RequestResponseLogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _stopwatch = new Stopwatch();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var api = context.Request.Path.ToString().TrimEnd('/').ToLower();
            // 过滤，只有接口
            if (api.Contains("api"))
            {
                _stopwatch.Restart();
                HttpRequest request = context.Request;
                dynamic requestModel = new ExpandoObject();
                requestModel.API = api;
                requestModel.IP = GetClientIp(context);
                requestModel.BeginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                requestModel.RequestMethod = request.Method;
                requestModel.Agent = request.Headers["User-Agent"].ToString();

                // 获取请求body内容
                if (request.Method.ToLower().Equals("post") || request.Method.ToLower().Equals("put"))
                {
                    request.EnableBuffering();

                    Stream stream = request.Body;
                    byte[] buffer = new byte[request.ContentLength.Value];
                    stream.Read(buffer, 0, buffer.Length);
                    requestModel.RequestData = Encoding.UTF8.GetString(buffer);

                    request.Body.Position = 0;
                }
                else if (request.Method.ToLower().Equals("get") || request.Method.ToLower().Equals("delete"))
                {
                    requestModel.RequestData = HttpUtility.UrlDecode(request.QueryString.ToString(), Encoding.UTF8);
                }

                var originalBodyStream = context.Response.Body;
                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;

                    await _next(context);

                    var responseBodyData = await GetResponse(context.Response);
                    requestModel.ResponseData=responseBodyData;
                    await responseBody.CopyToAsync(originalBodyStream);
                }

                var dt = DateTime.Now;
                context.Response.OnCompleted(() =>
                {
                    _stopwatch.Stop();

                    requestModel.Time = _stopwatch.ElapsedMilliseconds + "ms";
                    var requestInfo = JsonConvert.SerializeObject(requestModel);
  
                    _logger.LogInformation($"Request Log {requestInfo}");
                    return Task.CompletedTask;
                });

            }
            else
            {
                await _next(context);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public async Task<string> GetResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return text;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetClientIp(HttpContext context)
        {
            var ip = context.Request.Headers["X-Forwarded-For"].ToString();
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection.RemoteIpAddress.ToString();
            }
            return ip;
        }
    }
}
