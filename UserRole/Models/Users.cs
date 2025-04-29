using Microsoft.AspNetCore.Identity;

namespace UserRole.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
