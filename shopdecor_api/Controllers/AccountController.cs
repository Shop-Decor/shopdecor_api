using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public AccountController(IAccountRepository repo)
        {
            this.accountRepo = repo;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = await accountRepo.SignUpAsync(signUpModel);
            if (result.Succeeded)
            {

                return Ok(result.Succeeded);
            }

            return Ok(result);
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

        public async Task<IActionResult> Update([FromBody] EditAccount account, string Id)
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
        [HttpGet("GetUser")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser()
        {
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token is missing");
            }

            var user = await accountRepo.ValidateTokenAndGetUserAsync(token);
            if (user != null)
            {
                return Ok(user);
            }
            return Unauthorized();
        }
        [HttpPut("Delete/{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var result = await accountRepo.DeleteUser( Id);

            if (result.Succeeded)
            {

                return Ok(result.Succeeded);
            }

            return Ok(new { Token = result });
        }


        [HttpPut("ChangePass/{id}")]
        public async Task<IActionResult> ChangePass(string id, [FromBody] ChangePasswordModel changePasswordModel)
        {
            var result = await accountRepo.ChangePassword(id, changePasswordModel);

            if (result.Succeeded)
            {

                return Ok(result.Succeeded);
            }

            return Ok(new { Token = result });
        }




    }
}
