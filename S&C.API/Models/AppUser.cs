using Microsoft.AspNetCore.Identity;

namespace S_C.API.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
