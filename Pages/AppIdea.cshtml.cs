using CodexAppSuggestion.Data.Model;
using CodexAppSuggestion.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodexAppSuggestion.Pages
{
    public class AddAppIdeaModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Title { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Category { get; set; }
        [BindProperty(SupportsGet = true)]
        public string AppIdea { get; set; }
        [BindProperty(SupportsGet = true)]
        public IFormFile ImageFile { get; set; }
        [BindProperty]
        public string ImageIdea { get; private set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostAsync()
        {

            var userIdea = new Db();
            var user = new Idea
            {
                Title = Title,
                Category = Category,
                IdeaDescription = AppIdea,
                Email = Email,
            };
            userIdea.CreateIdea(user);
            return Redirect($"/DashBoard/{Email}");
        }
    }
}
