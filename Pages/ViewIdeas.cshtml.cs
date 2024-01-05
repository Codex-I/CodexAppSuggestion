using CodexAppSuggestion.Data;
using CodexAppSuggestion.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodexAppSuggestion.Pages.Shared
{
    public class ViewIdeasModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool Completed { get; set; }
        [BindProperty(SupportsGet =true)]
        public List<Idea>  GetIdeas { get; set; }

        public void OnGet()
        {
            var userIdeas = new Db();
             GetIdeas = userIdeas.GetListOfIdeas(Email);
            
        }
        public ActionResult OnPost()
        {
            if (Completed)
            {
                var updateIdeaStatus = new Db();
                var updateStatus = new Idea
                {
                    Status = true,
                    DateCompleted = DateTime.Today.AddDays(1),
                };
                updateIdeaStatus.UpdateIdea(updateStatus);
            }
            return Page();
        }
       
    }
}
