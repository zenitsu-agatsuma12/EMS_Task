using EMSAPI.DTO;
using EMSAPI.Model;
using Microsoft.AspNetCore.Identity;

namespace EMSAPI.Repository
{
    public interface IAccountDBRepository
    {
        Task<IdentityResult> SignUpUserAsync(ApplicationUser username, string password);
        Task<SignInResult> SignInUserAsync(LoginDTO loginDTO);
        Task<ApplicationUser> FindUserByEmailAsync(string email);
    }
}
