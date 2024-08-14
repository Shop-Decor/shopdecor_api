using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using shopdecor_api.Helper;
using shopdecor_api.Models.Domain;

namespace shopdecor_api.Services
{
    public class AccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateFirstAccount()
        {
            // Check if any user already exists role admin
            var user = await _userManager.FindByNameAsync("admin");
            if (user != null)
            {
                return IdentityResult.Success;
            }

         

            var newuser = new ApplicationUser
            {
                UserName = "admin",
                FullName = "admin",
                Email = "admin@gmail.com",
                Status = true,
            };

            var result = await _userManager.CreateAsync(newuser, "Admin@123");
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(AppRole.Admin))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppRole.Admin));
                }

                await _userManager.AddToRoleAsync(newuser, AppRole.Admin);
            }

            return result;
        }
    }
}
