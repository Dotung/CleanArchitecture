using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.WebAPI.MiddleWare
{
    public class MiddleWareCustomer
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public MiddleWareCustomer(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;

            _logger = logFactory.CreateLogger("MyCustomMiddleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            foreach (var item in httpContext.Request.Query)
            {
                httpContext.Request.Headers[item.Key] = item.Value.ToString();
            }

            //_logger.LogInformation("My Custom Middleware is executing..");

            await _next(httpContext); // calling next middleware
        }
    }
}
