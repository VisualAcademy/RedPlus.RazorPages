using Microsoft.AspNetCore.Identity;

namespace Zero.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
