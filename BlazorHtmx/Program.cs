using BlazorHtmx.Components;
using BlazorHtmx.Components.Shared;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services
    .AddSingleton<HtmxCounter.HtmxCounterState>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGet("/love-htmx",
    () => new RazorComponentResult<LoveHtmx>(new { Message = "I ❤️ ASP.NET Core" }));


app.MapPost("/count",
    (HtmxCounter.HtmxCounterState value) =>
    {
        value.Value++;
        return new RazorComponentResult<HtmxCounter>(
            new { State = value }
        );
    });


app.Run();