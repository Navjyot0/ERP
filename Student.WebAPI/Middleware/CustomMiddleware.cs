namespace Students.WebAPI.Middleware
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custum middleware Incomming request\n");
            await next(context);
            await context.Response.WriteAsync("Custum middleware Incomming response\n");
        }
    }
}
