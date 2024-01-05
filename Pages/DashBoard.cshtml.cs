using CodexAppSuggestion.Data;
using CodexAppSuggestion.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;

namespace CodexAppSuggestion.Pages
{
    public class DashBoardModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public string Email { get; set; }
        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }
        [BindProperty(SupportsGet =true)]
        public string GreetingMessage { get; set; }
       
        

        public void OnGet()
        {
            var showUser = new Db();
            var showResult = showUser.GetUser(Email);
            if (showResult != null)
            {
                Email = showResult.Email;
                UserName = showResult.UserName;
                
            }

            var currentTime = DateTime.Now.TimeOfDay;

            if (currentTime < TimeSpan.FromHours(12))
            {
                GreetingMessage = "💻 Good morning";
            }
            else if (currentTime < TimeSpan.FromHours(17))
            {
                GreetingMessage = "🎮 Good afternoon!";
            }
            else
            {
                GreetingMessage = "📺 Good evening!";
            }
        }

       
       

    }
}
