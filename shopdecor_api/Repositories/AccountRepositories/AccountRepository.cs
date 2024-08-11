using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using shopdecor_api.Helper;
using shopdecor_api.Models.Domain;
using shopdecor_api.Models.DTO.AccountDTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

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
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {

                string message = "1001";

                return message;
            }
            if (!await userManager.CheckPasswordAsync(user, model.Password))
            {
                string message = "1002";
                return message;
            }

            var checkStart = user.Status;
            if (checkStart == false)
            {
                string message = "1003";
                return message;
            }
            //get role 
           

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };
            //check role

            var userRoles = await userManager.GetRolesAsync(user);
            var userID = user.Id;
            authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            //lấy giá trị rool = user hoặc role = admin
            var role = (userRoles.Select(role => new Claim(ClaimTypes.Name, role))).First().Value;




            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(7),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha512)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email,

            };

            var checkMail = await userManager.FindByEmailAsync(model.Email);
            if (checkMail != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "2002" });
            }
            var checkUser = await userManager.FindByNameAsync(model.UserName);
            if (checkUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "2001" });
            }
            var result = await userManager.CreateAsync(user, model.Password);

            //kiểm tra 
            if (result.Succeeded)
            {
                //kiểm tra role Customer đã có hay chưa
                if (!await roleManager.RoleExistsAsync(AppRole.User))
                {
                    // nếu chưa -> tạo role mới 
                    await roleManager.CreateAsync(new IdentityRole(AppRole.User));
                }

                // dã có thì add role cho tk 
                await userManager.AddToRoleAsync(user, AppRole.User);
            }
            else
            {
                
            }
           
            //check mail
           
            return result;
        }


        public async Task<ApplicationUser> ValidateTokenAndGetUserAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["JWT:Secret"]);

            try
            {
                // Ghi log token để kiểm tra định dạng
                Console.WriteLine($"Token received: {token}");
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
            catch(SecurityTokenMalformedException ex)
            {
                Console.WriteLine($"Token malformed: {ex.Message}");
                // Optionally, log the exception or handle it as needed
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Ghi log lỗi hoặc xử lý nếu cần
            }

            return null;
        }

        public async Task<object> GetUserDetailsAsync(string token)
        {
            var user = await ValidateTokenAndGetUserAsync(token);
            if (user == null)
            {
                return null; // Invalid token
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
            // Lấy tất cả người dùng từ UserManager và role admin

            //var users = userManager.Users.ToList().Where(x => x.Status == true);
            // lấy tất cả user theo role admin 
            var admin = await userManager.GetUsersInRoleAsync(AppRole.Admin); 
            return await Task.FromResult(admin);
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
            var checkMail = await userManager.FindByEmailAsync(account.Email);
            if (checkMail != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "2002" });
            }
            var checkUser = await userManager.FindByNameAsync(account.UserName);
            if (checkUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "2001" });
            }
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

        public async Task<IdentityResult> UpdateUser(EditAccount account, string Id)
        {


            var user = await userManager.FindByIdAsync(Id);


            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }
            //kiểm tra nếu giá trị email thay đổi và đã tồn tại trong db
            var checkMail = await userManager.FindByEmailAsync(account.Email);
            if (checkMail != null && user.Email != account.Email)
            {
                return IdentityResult.Failed(new IdentityError { Description = "2002" });
            }
            var checkPhone = await userManager.Users
                .FirstOrDefaultAsync(u => u.PhoneNumber == account.PhoneNumber);
            if (checkPhone != null && user.PhoneNumber != account.PhoneNumber)
            {
                return IdentityResult.Failed(new IdentityError { Description = "2003" });
            }
            //check giá trị có phù hợp như trong model không
            
            if (!Regex.IsMatch(account.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                return IdentityResult.Failed(new IdentityError { Description = "Email không hợp lệ" });
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

        public async Task<ApplicationUser> GetAccountById(string accountId)
        {
            return await userManager.FindByIdAsync(accountId);
        }

        public async Task<IdentityResult> ChangePassword(string id,ChangePasswordModel model)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }
           
            //check giá trị có phù hợp như trong model không
            var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            return result;
        }


    }



}
