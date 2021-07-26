using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class StatusMiddleware
    {
        private readonly RequestDelegate _next;

        public StatusMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value.Contains("ping"))
            {
                context.Response.ContentType = "text/plain";
                var value = Encoding.ASCII.GetBytes("pong");
                await context.Response.Body.WriteAsync(value);
                return;
            }
            await _next(context);
        }
    }
}