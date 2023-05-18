using System.ComponentModel.DataAnnotations;

namespace EMSAPI.DTO
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
