using BlazorHtmx.Components;
using BlazorHtmx.Components.Htmx;
using BlazorHtmx.Components.Shared;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services
    .AddSingleton<HtmxCounter.HtmxCounterState>();

builder.Services.AddControllers();

builder.Services.AddScoped<HtmxContext>();
builder.Services.AddScoped<IHtmxContext>(sp => sp.GetRequiredService<HtmxContext>());

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
app.UseMiddleware<HtmxContext>();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();

app.MapPost("/count",
    (HtmxCounter.HtmxCounterState value) =>
    {
        value.Value++;
        return new RazorComponentResult<HtmxCounter>(
            new { State = value }
        );
    });


app.Run();