using Applcation.Comman;
using Applcation.Feature.AuthApplacation.Login.LoginDTO;
using Applcation.Feature.AuthApplacation.RegisterUser.DTO;
using Applcation.Interface.Iservice;
using Domain.Enums;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly dbContext _dbContext;

        public AuthService(UserManager<User> userManager, IConfiguration configuration, dbContext dbContext)
        {
            _userManager = userManager;
            _configuration = configuration;
            _dbContext = dbContext;
        }



        public async Task<Result> RegisterUser(RegisterUserDTO registerDTO)
        {
            if (registerDTO == null)
                return Result.Failure(ErrorType.validation,"Invalid registration data");


            var CreateUser = new User
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                AccountTypes = AccountTypes.AccountActive,
                DateOfBirth = registerDTO.DateOfBirth

            };

            var result = await _userManager.CreateAsync(CreateUser, registerDTO.Password);
            if (!result.Succeeded)

            {
                var errors = result.Errors.Select(i => i.Description).ToList();
                return Result.Failure(ErrorType.validation,"Registerion Faild");

            }
            await _userManager.AddToRoleAsync(CreateUser, "User");

            return Result.Success("User registered successfully");

        }



















        public string GenerateJwtToken(User user, IList<string> roles)
        {
            var JWTSecretKey = _configuration.GetSection("JwtSettings");
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),

            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTSecretKey["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(double.Parse(JWTSecretKey["ExpireMinutes"]));
            var token = new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: creds,
                issuer: JWTSecretKey["Issuer"],
                audience: JWTSecretKey["Audience"]


            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }



        public async Task<Result<LoginResponseDTO>> signInApplaction(string Email, string Password)
        {
            var FindUser = await _userManager.FindByEmailAsync(Email);
            if (FindUser == null)
                return Result<LoginResponseDTO>.Failure("the Account Not found Please Register Only",ErrorType.notfound);
            switch (FindUser.AccountTypes)
            {
                case AccountTypes.AccountPending:
                    return Result<LoginResponseDTO>.Failure("the Account Replay Information with employee Company",ErrorType.notfound);
                case AccountTypes.AcoountSetPassword:
                    return Result<LoginResponseDTO>.Failure("Please Set New Password first ",ErrorType.validation);
                case AccountTypes.AcountReject:
                    return Result<LoginResponseDTO>.Failure("Your registration request was rejected.",ErrorType.forbidden);
                case AccountTypes.AccountDisable:
                    return Result<LoginResponseDTO>.Failure("Your account has been disabled.",ErrorType.forbidden);

            }

            var CheckPassword = await _userManager.CheckPasswordAsync(FindUser, Password);

            if (!CheckPassword)
            {
                return Result<LoginResponseDTO>.Failure("Invaild Email Or Password pleas Check",ErrorType.validation);
            }

            var RolesUser = await _userManager.GetRolesAsync(FindUser);
            var token = GenerateJwtToken(FindUser, RolesUser);

            return Result<LoginResponseDTO>.Success(new LoginResponseDTO
            {
                UserId = FindUser.Id,
                Email = Email,
                Role = RolesUser.ToList(),
                Token = token


            });


        }
    }
}
