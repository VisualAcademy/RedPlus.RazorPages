using Microsoft.AspNetCore.Identity;

namespace Zero.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
