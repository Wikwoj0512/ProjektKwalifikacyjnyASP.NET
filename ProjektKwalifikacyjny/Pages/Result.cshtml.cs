using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektKwalifikacyjny.Models;

namespace ProjektKwalifikacyjny.Pages;

public class Result : PageModel
{
    [BindProperty(SupportsGet = true)] public string url { get; set; }
    public WebsiteModel website { get; set; }
    public void OnGet()
    {
        if (Request.Query.ContainsKey("url"))
        {
            url = Request.Query["url"];
            // website = new WebsiteModel(url);
            try
            {
                website = new WebsiteModel(url);
            }
            catch (WebException exception)
            {
                website = null;
                Response.Redirect("/Error?exception="+exception.Message, false);
            }

        }
    }

}