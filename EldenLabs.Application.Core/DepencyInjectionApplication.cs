using EldenLabs.Application.Core.Config;
using EldenLabs.Application.Core.Dto;
using EldenLabs.Application.Core.Services;
using EldenLabs.Application.Core.Validation;
using EldenLabs.Infrastructure;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Application.Core
{
    public static class DepencyInjectionApplication
    {

        public static IServiceCollection AddApplicationInjection(
            this IServiceCollection services,
            IConfiguration configuration) {


            // Add 
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMeasurementService, MeasurementService>();

            services.AddInfrastructureApplication(configuration);


            // Add configuration of Automapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

           

            services.AddTransient<IValidator<SignUpRequestDto>, SignUpValidator>();
            services.AddTransient<IValidator<SignInRequestDto>, SignInValidator>();


            return services;
        }
    }
}
