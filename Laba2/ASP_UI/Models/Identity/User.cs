using Microsoft.AspNetCore.Identity;

namespace ASP_UI.Models.Identiy
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
