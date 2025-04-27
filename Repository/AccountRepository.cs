using Microsoft.AspNetCore.Identity;
using WebApplication7.Models;
using WebApplication7.Services;

namespace WebApplication7.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;

        public AccountRepository(UserManager<ApplicationUser> userManager ,
                                 SignInManager<ApplicationUser> signInManager,
                                 IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel usermodel)
        {
            var user = new ApplicationUser()
            {
                FirstName = usermodel.FirstName,
                LastName= usermodel.LastName, 
                Email = usermodel.Email,
                UserName = usermodel.Email,

            };
         var result=  await  _userManager.CreateAsync(user , usermodel.Password);
            return result;
        }
        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email,signInModel.Password,signInModel.RememberMe,false);

            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);

             return await _userManager.ChangePasswordAsync(user , model.CurrentPassword , model.NewPassword);
        }
    }
}
