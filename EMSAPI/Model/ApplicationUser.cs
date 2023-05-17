using Microsoft.AspNetCore.Identity;

namespace EMSAPI.Model
{
    public class ApplicationUser:IdentityUser
    {
        public int EmpId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
