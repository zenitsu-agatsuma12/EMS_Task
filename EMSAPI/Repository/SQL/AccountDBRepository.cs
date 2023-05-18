using EMSAPI.Data;
using EMSAPI.DTO;
using EMSAPI.Model;
using Microsoft.AspNetCore.Identity;

namespace EMSAPI.Repository.SQL
{
    public class AccountDBRepository : IAccountDBRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly EMSDBContext _context;

        public AccountDBRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            EMSDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public async Task<ApplicationUser> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<SignInResult> SignInUserAsync(LoginDTO loginDTO)
        {
            return await _signInManager.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, false, lockoutOnFailure: false);
        }

        public async Task<IdentityResult> SignUpUserAsync(ApplicationUser username, string password)
        {
            return await _userManager.CreateAsync(username, password);
        }
    }
}
