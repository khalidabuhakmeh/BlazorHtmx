using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlazorHtmx.Components.Shared;

public class LoveMbc : ControllerBase
{
    [Route("/love-mbc")]
    public IResult OnGet() => new RazorComponentResult<LoveHtmx>(new { Message = "I ❤️ ASP.NET Core" });
}