using Htmx;

namespace BlazorHtmx.Components.Htmx;

public class HtmxContext : IHtmxContext, IMiddleware
{
    public bool IsHtmx { get; private set; }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        IsHtmx = context.Request.IsHtmx();
        await next(context);
    }
}