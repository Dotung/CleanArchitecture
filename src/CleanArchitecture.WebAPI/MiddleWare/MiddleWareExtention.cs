using CleanArchitecture.WebAPI.MiddleWare;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.WebAPI
{
    public static class MiddleWareExtention
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ErrorHandlingMiddleware>();
            return builder.UseMiddleware<MiddleWareCustomer>();
        }
    }
}
