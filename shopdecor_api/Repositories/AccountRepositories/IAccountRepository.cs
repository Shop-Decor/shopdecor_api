using Microsoft.AspNetCore.Identity;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.AccountDTO;
namespace shopdecor_api.Repositories.AccountRepositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
        public Task<ApplicationUser> ValidateTokenAndGetUserAsync(string token);
        public Task<object> GetUserDetailsAsync(string token);
    }
}
