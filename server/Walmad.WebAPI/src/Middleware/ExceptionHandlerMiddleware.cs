
using Walmad.Business.src.Shared;

namespace Walmad.WebAPI.src.Middleware;

public class ExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context); //to pass the request to next handler
        }
        catch (CustomExeption e)
        {
            context.Response.StatusCode = e.StatusCode;
            await context.Response.WriteAsync(e.Message);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(e.Message);
        }
    }
}
