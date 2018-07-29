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
                //context.Result = new BadRequestObjectResult(context.ModelState);

                context.Result = new BadRequestObjectResult(new
                {
                    Data = from kvp in context.ModelState
                           from err in kvp.Value.Errors
                           let k = kvp.Key
                           select new ValidationError(ValidationError.ErrorType.Input, (HttpStatusCode)422, k, string.IsNullOrEmpty(err.ErrorMessage) ? "Invalid Input" : err.ErrorMessage),
                    Status = new
                    {
                        Code = 422,
                        Message = "Validation error."
                    }
                });
            }            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
