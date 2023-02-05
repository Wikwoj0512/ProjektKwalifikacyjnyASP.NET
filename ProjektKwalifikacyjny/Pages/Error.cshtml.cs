
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektKwalifikacyjny.Models;

namespace ProjektKwalifikacyjny.Pages;

public class ErrorModel : PageModel
{
    
    [BindProperty(SupportsGet = true)] public string exception { get; set; }
    public void OnGet()
    {
        if (Request.Query.ContainsKey("exception"))
        {
            exception = Request.Query["exception"];
        }
    }
}

