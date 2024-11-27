namespace HoaPortalApp.Mvc.Models
{
        public class LoginViewModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string? ReturnUrl { get; set; } // Optional: to handle redirection after login
        }
}
