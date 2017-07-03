using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace NumberAPICore.Filters
{
    public class LogMeAll : ActionFilterAttribute
    {
        private readonly ILogger iLog;
        public LogMeAll(ILoggerFactory iLogf)
        {
            this.iLog = iLogf.CreateLogger<LogMeAll>();
        }
        public override void  OnActionExecuted(ActionExecutedContext context)
        {
          
            iLog.LogError(new EventId().Id, context.HttpContext.Request.ToString());
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            iLog.LogError(new EventId().Id, context.HttpContext.Request.ToString());
        }
    }
}
