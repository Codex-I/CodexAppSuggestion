using CodexAppSuggestion.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodexAppSuggestion.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public string? Email { get; set; }
        [BindProperty]
        public string? Password { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var checkDetails = new Db();
            var detailResult = checkDetails.GetUser(Email);
           if (detailResult.Email == Email &&  detailResult.Password == Password)
           {
               return RedirectToPage("DashBoard", new {Email});
           }
            ModelState.AddModelError("", "Please Input the correct login details");
            return Page();

        }
    }
}