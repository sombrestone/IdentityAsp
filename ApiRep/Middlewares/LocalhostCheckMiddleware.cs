using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRep.Middlewares
{
    public class LocalhostCheckMiddleware: MiddlewareBase
    {
        public LocalhostCheckMiddleware(RequestDelegate next):base(next) { }

        public override async Task Invoke(HttpContext context)
        {
            if (context.Request.Host.Host == "localhost")
            {
                await context.Response.WriteAsync("You use localhost.");
            }
            await _next.Invoke(context);
        }
    }
}
