using ApiRep.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRep.Middlewares
{
    public class ErrorHandlerMiddleware:MiddlewareBase
    {

        private readonly ILogger _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILoggerFactory logFactory) : base(next) 
        {
            _logger = logFactory.CreateLogger<IpLogMiddleware>();
        }

        public override async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch(Exception error)
            {
                context.Response.StatusCode = (error is LogicException)?((LogicException)error).Code:500;
                await context.Response.WriteAsync(error.Message);
                _logger.LogTrace(error.StackTrace);
            }
        }
    }
}
