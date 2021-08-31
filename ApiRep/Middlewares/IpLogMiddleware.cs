using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRep.Middlewares
{
    public class IpLogMiddleware: MiddlewareBase
    {
        private readonly ILogger _logger;

        public IpLogMiddleware(RequestDelegate next, ILoggerFactory logFactory) : base(next) 
        {
            _logger = logFactory.CreateLogger<IpLogMiddleware>();
        }
        
        public override async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            finally
            {
                _logger.LogInformation(
                    "Request {ip} {method} {url} => {statusCode}",
                    context.Request?.Host.Host,
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response?.StatusCode);
            }
        }
    }
}
