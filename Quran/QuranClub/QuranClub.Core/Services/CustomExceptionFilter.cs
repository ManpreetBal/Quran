using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using QuranClub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static QuranClub.Core.Services.MyAppException;
using Newtonsoft.Json;

namespace QuranClub.Core.Services
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = String.Empty;

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = "Unauthorized Access";
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                message = "A server error occurred.";
                status = HttpStatusCode.NotImplemented;
            }
            else if (exceptionType == typeof(MyAppException))
            {
                message = context.Exception.Message;
                status = HttpStatusCode.InternalServerError;
            }
            else
            {
                message = context.Exception.Message;
                status = HttpStatusCode.NotFound;
            }
            HttpResponse response = context.HttpContext.Response;

            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            //var err = message + " " + context.Exception.StackTrace;
            List<MyAppException> p = new List<MyAppException>();

            p.Add(new MyAppException { Title = message });
            ReturnJson r = new ReturnJson()
            {
                error = p
            };

           var err = JsonConvert.SerializeObject(r , Formatting.Indented);

            response.WriteAsync(err);
        }

    }
}
