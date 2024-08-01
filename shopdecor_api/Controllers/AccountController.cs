using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.AccountDTO;
using shopdecor_api.Repositories.AccountRepositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace shopdecor_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        public AccountController(IAccountRepository repo)
        {
            accountRepo = repo;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = await accountRepo.SignUpAsync(signUpModel);
            if (result.Succeeded)
            {

                return Ok(result.Succeeded);
            }

            return StatusCode(500);
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInModel signInModel)
        {
            var result = await accountRepo.SignInAsync(signInModel);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(new { Token = result });
        
        }
      

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateAccount account)
        {
            var result = await accountRepo.CreateUser(account);

            if (result.Succeeded)
            {

                return Ok(result.Succeeded);
            }

            return Ok(new { Token = result });
        }

        [HttpPut("{Id}")]

        public async Task<IActionResult> Update([FromBody] CreateAccount account, string Id)
        {
            var result = await accountRepo.UpdateUser(account,Id);

            if (result.Succeeded)
            {

                return Ok(result.Succeeded);
            }

            return Ok(new { Token = result });

        }

        [HttpGet("Get")]
        //check role 
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Get()
        {
            
            // Fetch all users (assuming the user has the right permissions)
            var users = await accountRepo.GetAllUsersAsync();

            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            return Ok(users);
        }

        private async Task<ApplicationUser> ValidateTokenAndGetUserAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["JWT:Secret"]);

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    ValidAudience = configuration["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);

                var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId != null)
                {
                    return await userManager.FindByIdAsync(userId);
                }
            }
            catch
            {
                // Handle the exception as needed
            }

            return null;
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(string Id)
        {
            var result = await accountRepo.DeleteUser( Id);

            if (result.Succeeded)
            {

                return Ok(result.Succeeded);
            }

            return Ok(new { Token = result });
        }




    }
}
