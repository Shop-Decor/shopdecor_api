using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.AccountDTO;
using shopdecor_api.Models.DTO.FilterDTO;
using shopdecor_api.Models.DTO.PagingDTO;
using shopdecor_api.Models.DTO.ProductDTO;
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
        private readonly IMapper _mapper;
        public AccountController(IAccountRepository repo, IMapper mapper)
        {
            _mapper = mapper;
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


            return Ok(result.Errors.FirstOrDefault().Description);
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
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Create([FromBody] CreateAccount account)
        {
            var result = await accountRepo.CreateUser(account);

            if (result.Succeeded)
            {

                return Ok(result.Succeeded);
            }

            return Ok(result.Errors.FirstOrDefault().Description);
        }

        [HttpPut("{Id}")]

        public async Task<IActionResult> Update(string Id, [FromBody] EditAccount account)
        {
            var result = await accountRepo.UpdateUser(account,Id);

            if (result.Succeeded)
            {

                return Ok(result.Succeeded);
            }

            return Ok(result.Errors.FirstOrDefault().Description);

        }

        [HttpGet("Get")]
        //check role 
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Get([FromQuery] PagingDTO paging, [FromQuery] SearchDTO? search)
        {

            var usersList = await accountRepo.GetAllUsersAsync(search); // Await the asynchronous method
            var queryable = usersList.AsQueryable(); // Convert the list to IQueryable

            var totalRecord = queryable.Count();
            paging = paging ?? new PagingDTO();
            paging.index = paging.index < 1 ? 1 : paging.index;
            paging.size = paging.size < 1 ? 16 : paging.size;

            if (!string.IsNullOrEmpty(search?.keyword))
            {
                queryable = queryable.Where(user => user.UserName.Contains(search.keyword));
            }

            totalRecord = queryable.Count(); // Recalculate total records after filtering

            queryable = queryable
                .OrderByDescending(user => user.DateCreated) // Order the users by DateCreated
                .Skip((paging.index - 1) * paging.size) // Skip to the desired page
                .Take(paging.size); // Take the page size number of users

            var users = queryable.ToList(); // Execute the query and get the list of users
            var usersRes = users; // Map the users to the desired DTO

            return Ok(new PagingResponseDTO<ApplicationUser>()
            {
                list = usersRes,
                paging = new()
                {
                    index = paging.index,
                    size = paging.size,
                    totalPage = (int)Math.Ceiling((decimal)totalRecord / paging.size),
                }
            });
        }
        [HttpGet("GetUser")]

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
        [Authorize(Roles = "Admin")]
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
