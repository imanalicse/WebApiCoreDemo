using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApiCoreDemo.Core
{
    public class ValidationError
    {
        #region Constants
        public static class ErrorType
        {
            public static string Input = "input";
            public static string Domain = "domain";
        }
        #endregion

        #region Properties
        public string Type { get; set; }
        public HttpStatusCode Code { get; set; }
        public object Source { get; set; }
        public string Message { get; set; }
        #endregion

        #region Constructor
        public ValidationError()
        {
        }

        public ValidationError(string type, HttpStatusCode code, object source, string message)
        {
            Type = type;
            Code = code;
            Source = source;
            Message = message;
        }
        #endregion
    }
}
