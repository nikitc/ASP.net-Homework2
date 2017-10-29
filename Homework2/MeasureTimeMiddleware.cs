using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Http;

namespace Homework2
{
    public class MeasureTimeMiddleware
    {
        private readonly RequestDelegate _next;

        public MeasureTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var timer = new Timer();
            timer.Start();
            var token = context.Request.Query["token"];
            timer.Stop();
            await context.Response.WriteAsync($"Class MiddleWare {timer.Interval}\n");
            await _next.Invoke(context);
        }
    }
}
