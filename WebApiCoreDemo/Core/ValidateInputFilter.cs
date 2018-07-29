using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApiCoreDemo.Core
{
    public class ValidateInputFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public ValidateInputFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ValidateInputFilter>();
        }

       
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
