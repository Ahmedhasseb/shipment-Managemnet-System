
using Applcation.Interface.IRepository;
using Applcation.Interface.Iservice;
using Infrastructure.Data;
using Infrastructure.Data.SeedData;
using Infrastructure.GenericRepository;
using Infrastructure.IdentityUser.Servive;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using model;
using service;
using System.Text;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string ConnectionStrin, IConfiguration configuration)
        {
            // Database Connection
            services.AddDbContext<dbContext>(options =>
                options.UseSqlServer(ConnectionStrin));

            var JWTSettings = configuration.GetSection("JwtSettings");

            // 🔑 JWT Authentication Setup


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var key = Encoding.UTF8.GetBytes(JWTSettings["Key"]);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = JWTSettings["Issuer"],
                    ValidAudience = JWTSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });



            services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            }).AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<dbContext>()
            .AddSignInManager<SignInManager<User>>()
            .AddDefaultTokenProviders();

            // Services

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMerchantRepository, MerchantRequestRepository>();
            services.AddScoped<IMarchmentRequestService, MarchmentRequestService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(Genericrepository<>));
            services.AddScoped<IuniteOfWork, UniteOfWork>();
            services.AddTransient<IEmailService, EmailService>();
            
            services.AddScoped<IRegisterManagerBranch, RegisterMangerBranch>();
            services.AddScoped<IRestPassword, ResetPassword>();
            services.AddScoped<ICreateBranchesService, CreateBranchServices>();
            return services;
        }
        
    }

   
        public static class IdentitySeedExtensions
        {
            public static async Task SeedIdentityAsync(this WebApplication app)
            {
                using var scope = app.Services.CreateScope();

                var roleManager =
                    scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var userManager =
                    scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                await IdentitySeeder.SeedRoleAsync(
                    roleManager,
                    userManager);
            }
        }
    
}
