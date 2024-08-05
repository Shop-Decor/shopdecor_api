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

        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        public Task<IdentityResult> CreateUser(CreateAccount account);
        public Task<IdentityResult> UpdateUser(EditAccount account, string Id);
        public Task<IdentityResult> DeleteUser(string ID);

        Task<ApplicationUser> GetAccountById(string accountId);

    }
}
