

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using shopdecor_api.Helper;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.AccountDTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace shopdecor_api.Repositories.AccountRepositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;

        private readonly RoleManager<IdentityRole> roleManager;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
        }


        public async Task<string> SignInAsync(SignInModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            var passwordValid = await userManager.CheckPasswordAsync(user, model.Password);
            if (user == null || !passwordValid)
            {
                return string.Empty;
            }
           
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRole = await userManager.GetRolesAsync(user);
            foreach (var role in userRole)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)

            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new ApplicationUser
            {
                FullName = model.FullName,
                Email = model.Email,
                UserName = model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);

            //kiểm tra 
            if (result.Succeeded)
            {
                //kiểm tra role Customer đã có hay chưa
                if (!await roleManager.RoleExistsAsync(AppRole.Admin))
                {
                    // nếu chưa -> tạo role mới 
                    await roleManager.CreateAsync(new IdentityRole(AppRole.Admin));
                }

                // dã có thì add role cho tk 
                await userManager.AddToRoleAsync(user, AppRole.Admin);
            }
            return result;
        }


        public async Task<ApplicationUser> ValidateTokenAndGetUserAsync(string token)
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
                
            }

            return null;
        }

        public async Task<object> GetUserDetailsAsync(string token)
        {
            var user = await ValidateTokenAndGetUserAsync(token);
            if (user == null)
            {
                return null;
            }

            var roles = await userManager.GetRolesAsync(user);

            return new
            {
                user.Email,
                Roles = roles
            };
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            // Lấy tất cả người dùng từ UserManager
            var users = userManager.Users.ToList();
            return await Task.FromResult(users);
        }



        public async Task<IdentityResult> CreateUser(CreateAccount account)
        {
            var user = new ApplicationUser
            {
                FullName = account.FullName,
                Email = account.Email,
                UserName = account.UserName,
                Address = account.Address,
                PhoneNumber = account.PhoneNumber,
            };
            var result = await userManager.CreateAsync(user, account.Password);

            //kiểm tra 
            if (result.Succeeded)
            {
                //kiểm tra role Customer đã có hay chưa
                if (!await roleManager.RoleExistsAsync(AppRole.Admin))
                {
                    // nếu chưa -> tạo role mới 
                    await roleManager.CreateAsync(new IdentityRole(AppRole.Admin));
                }

                // dã có thì add role cho tk 
                await userManager.AddToRoleAsync(user, AppRole.Admin);
            }
            return result;
        }

        public async Task<IdentityResult> UpdateUser(CreateAccount account, string Id)
        {


            var user = await userManager.FindByIdAsync(Id);

            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            user.FullName = account.FullName;
            user.Email = account.Email;
            user.PhoneNumber = account.PhoneNumber;
            user.Address = account.Address;

            var result = await userManager.UpdateAsync(user);
            return result;
        }
       

        public async Task<IdentityResult> DeleteUser(string ID)
        {
            var user = await userManager.FindByIdAsync(ID);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }
            user.Status = false;
            var result = await userManager.UpdateAsync(user);
            return result;
        }
    }



}
