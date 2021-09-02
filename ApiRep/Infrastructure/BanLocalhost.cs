
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiRep.Infrastructure
{
    public class BanLocalhost: IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Host.Host!="localhost")
            {
                filterContext.Result= new ConflictObjectResult("");
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext){}
    }
}
