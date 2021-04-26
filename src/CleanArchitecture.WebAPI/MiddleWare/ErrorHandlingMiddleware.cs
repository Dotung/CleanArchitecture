using CleanArchitecture.Application.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.WebAPI.MiddleWare
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = System.Net.HttpStatusCode.InternalServerError; // 500 if unexpected

            var result = new ResultData()
            {
                error_code = "400",
                error_message = "Xảy ra lỗi",
                error_detail = "Xảy ra lỗi :" + ex.Message
            };

            //var dataLog = "Error: \n" + ex.Message;
            //dataLog += "\nChi tiết: \n" + ex.StackTrace;
            
            var jsonResult = JsonConvert.SerializeObject(result);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(jsonResult);
        }
    }
}
