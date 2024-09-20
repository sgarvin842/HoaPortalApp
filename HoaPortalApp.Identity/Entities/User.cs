using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HoaPortalApp.Domain.Entities
{
    public abstract class User: IdentityUser
    {
        public required string FirstName { get; set; }
        public string MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Username { get; set; } 
        public abstract bool Login(string Email, string password);
        public abstract void Logout();
        public abstract void ResetPassword(string NewPassword);
    }
}
