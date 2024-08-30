using Azure;
using BlogApi.Dtos;
using BlogApi.Dtos.RoleDtos;
using BlogApi.Dtos.UserDtos;
using BlogApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Authorization = BlogApi.Models.Authorization;

namespace BlogApi.Repository.UserRepository
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly JWT _jwt;

        public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, JWT jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt;
        }
        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return $"No Accounts Registered with {model.Email}.";
            }
            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var roleExists = Enum.GetNames(typeof(Authorization.Roles))
                    .Any(x => x.ToLower() == model.Role.ToLower());
                if (roleExists)
                {
                    var validRole = Enum.GetValues(typeof(Authorization.Roles)).Cast<Authorization.Roles>()
                        .Where(x => x.ToString().ToLower() == model.Role.ToLower())
                        .FirstOrDefault();

                    await _userManager.AddToRoleAsync(user, validRole.ToString());
                    return $"Added {model.Role} to user {model.Email}.";
                }
                return $"Role {model.Role} not found.";
            }
            return $"Incorrect Credentials for user {user.Email}.";
        }

        public async Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model)
        {
            AuthenticationModel authenticationModel;
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return new AuthenticationModel { IsAuthenticated = false, Message = $"No Accounts Registered with {model.Email}." };

            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);

                authenticationModel = new AuthenticationModel
                {
                    IsAuthenticated = true,
                    Message = jwtSecurityToken.ToString(),
                    UserName = user.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Email = user.Email,
                };
                var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                authenticationModel.Roles = rolesList.ToList();
                return authenticationModel;
            }
            else
            {
                authenticationModel = new AuthenticationModel()
                {
                    IsAuthenticated = false,
                    Message = $"Incorrect Credentials for user {user.Email}."
                };
            }


            return authenticationModel;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;

        }

        public async Task<IActionResult> RegisterAsync(RegisterDto model)
        {
            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
            };

            var userWithSameEmail = await _userManager.FindByEmailAsync(model.Email);
            if (userWithSameEmail == null)
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    return new OkObjectResult(user);
                }
                else
                {
                    var errors = result.Errors.Select(e => e.Description).ToList();
                    string jsonErrors = JsonSerializer.Serialize(errors);
                    return new ContentResult
                    {
                        Content = jsonErrors,
                        ContentType = "application/json",
                        StatusCode = 400
                    };
                }
            }
            else
            {
                var errorMessage = $"Email {user.Email} is already registered.";
                return new BadRequestObjectResult(errorMessage);
            }
        }

        public async Task<GetByIdUserDto> GetByIdUser(string id)
        {
            if (id != null)
            {
                var result = await _userManager.FindByIdAsync(id);
                if (result == null)
                {

                    return new GetByIdUserDto();
                }
                GetByIdUserDto getByIdUserDto = new GetByIdUserDto();
                getByIdUserDto.Id = result.Id;
                getByIdUserDto.UserName = result.UserName;
                getByIdUserDto.PhoneNumber = result.PhoneNumber;
                getByIdUserDto.PhoneNumberConfirmed = result.PhoneNumberConfirmed;
                getByIdUserDto.EmailConfirmed = result.EmailConfirmed;
                getByIdUserDto.Email = result.Email;
                getByIdUserDto.FullName = result.FullName;


                return getByIdUserDto;


            }
            return new GetByIdUserDto();


        }

        public async Task<List<GetUsersDto>> GetAllUsers()
        {


            var users = await _userManager.Users.ToListAsync();


            var results = users.Select(user => new GetUsersDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                PhoneNumber = user.PhoneNumber

            }).ToList();

            return results;
        }

        public async Task<UpdateUserResponseDto> UpdateUserAsync(UpdateUserDto model)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(p => p.Id == model.Id);

            if (user == null)
            {
                return new UpdateUserResponseDto { IsSuccessful=false};
            }
           
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.FullName = model.FullName;
            if (!string.IsNullOrEmpty(model.OldPassword) && !string.IsNullOrEmpty(model.Password))
            {
                var passwordChangeResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.Password);

             
                if(!passwordChangeResult.Succeeded)
                {
                  var error= passwordChangeResult.Errors.Select(e => e.Description);
                    return new UpdateUserResponseDto { IsSuccessful=false, Errors=error};
                }
            }
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new UpdateUserResponseDto { IsSuccessful=true};
            }
            else
            {
               var error= result.Errors.Select(e => e.Description);
                return new UpdateUserResponseDto { IsSuccessful=false , Errors=error};
            }
            


        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (user == null)
            {
                return false;
            }
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;


        }


    }
}
