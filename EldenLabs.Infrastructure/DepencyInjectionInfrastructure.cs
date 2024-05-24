using EldenLabs.Domain.Repositories;
using EldenLabs.Domain.Repositories.Base;
using EldenLabs.Infrastructure.AppContext;
using EldenLabs.Infrastructure.Helpers.Jwt;
using EldenLabs.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EldenLabs.Infrastructure
{
    public static class DepencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructureApplication(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMeasurementRepository, MeasurementRepository>();

            var connectionString = configuration.GetConnectionString("ConnectionString") ?? throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });


            // Configuration for the authenticate the user params
            services.AddScoped<JwtTokenService>();

            var validIssuer = configuration.GetValue<string>("Jwt:Issuer");
            var validAudience = configuration.GetValue<string>("Jwt:Audience");
            var key = Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Key"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = validIssuer,
                    ValidAudience = validAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            });

            return services;
        }
    }
}
