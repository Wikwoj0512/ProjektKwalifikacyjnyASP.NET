using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektKwalifikacyjny.Models;

namespace ProjektKwalifikacyjny.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    [BindProperty] public string url { get; set; }
    public void OnGet()
    {
    }
    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            return RedirectToPage("/Result", new {url});
        }
        return Page();
    }
}