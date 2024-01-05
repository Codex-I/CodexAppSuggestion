using CodexAppSuggestion.Data;
using CodexAppSuggestion.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodexAppSuggestion.Pages
{
    public class ViewFullIdeaModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public string Id { get; set; }
        [BindProperty(SupportsGet =true)]
        public Idea ShowIdea { get; set; }
        public void OnGet()
        {
            var getIdea = new Db();
            var getById = getIdea.GetIdea(Id);
            ShowIdea = getById;

        }
    }
}
