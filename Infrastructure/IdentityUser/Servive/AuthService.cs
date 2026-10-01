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



        public async Task<Results> RegisterUser(RegisterUserDTO registerDTO)
        {
            if (registerDTO == null)
                return Results.Failure("Invalid registration data");


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
                return Results.Failure("Registerion Faild", errors);

            }
            await _userManager.AddToRoleAsync(CreateUser, "User");

            return ResultT<string>.Success("User registered successfully");

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



        public async Task<ResultT<LoginResponseDTO>> signInApplaction(string Email, string Password)
        {
            var FindUser = await _userManager.FindByEmailAsync(Email);
            if (FindUser == null)
                return ResultT<LoginResponseDTO>.Failure("the Account Not found Please Register Only");
            switch (FindUser.AccountTypes)
            {
                case AccountTypes.AccountPending:
                    return ResultT<LoginResponseDTO>.Failure("the Account Replay Information with employee Company");
                case AccountTypes.AcoountSetPassword:
                    return ResultT<LoginResponseDTO>.Failure("Please Set New Password first ");
                case AccountTypes.AcountReject:
                    return ResultT<LoginResponseDTO>.Failure("Your registration request was rejected. ");
                case AccountTypes.AccountDisable:
                    return ResultT<LoginResponseDTO>.Failure("Your account has been disabled ");

            }

            var CheckPassword = await _userManager.CheckPasswordAsync(FindUser, Password);

            if (!CheckPassword)
            {
                return ResultT<LoginResponseDTO>.Failure("Invaild Email Or Password pleas Check");
            }

            var RolesUser = await _userManager.GetRolesAsync(FindUser);
            var token = GenerateJwtToken(FindUser, RolesUser);

            return ResultT<LoginResponseDTO>.Success(new LoginResponseDTO
            {
                UserId = FindUser.Id,
                Email = Email,
                Role = RolesUser.ToList(),
                Token = token


            });


        }
    }
}
