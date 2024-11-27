namespace HoaPortalApp.Api.Routing
{
    public static class AuthRouting
    {
        public static class Actions
        {
            public const string Login = "api/v1/auth/login"; // Adjust the route as necessary
            public const string Register = "api/v1/auth/register";
            public const string SendResetPasswordCode = "api/v1/auth/send-reset-password-code";
            public const string ResetPassword = "api/v1/auth/reset-password";
        }
    }
}