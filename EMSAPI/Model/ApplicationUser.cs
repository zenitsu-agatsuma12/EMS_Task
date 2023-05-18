using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EMSAPI.Model
{
    public class ApplicationUser:IdentityUser
    {
        [EmailAddress]
        public string? First_Name { get; set;}
        public string? Last_Name { get; set;}
        public string? Address { get; set; }
    }
}
