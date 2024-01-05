using CodexAppSuggestion.Data;
using CodexAppSuggestion.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodexAppSuggestion.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string ConfirmPassword { get; set; }
        
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            var checkEmail = new Db();
            var emailResults = checkEmail.FindAllUsers();
            foreach(var email in emailResults)
            {
                if (email.Email == Email)
                {
                    ModelState.AddModelError("", "This Email already exists!!");
                    return Page();

                }
            }

            if (ConfirmPassword != Password)
            {
                ModelState.AddModelError("", "The Password and Confirm-Password does not match!");
                return Page();

            }
            var userCreate = new Db();
            var newUser = new User
            {
                UserName = UserName,
                Email = Email,
                Password = Password,
            };
            userCreate.CreateUser(newUser);
            return Redirect($"DashBoard/{Email}");

        }
    }
}
