using Cadier.Model.ModelsConfigs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cadier.DB.Sessions;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Cadier.Abstractions.Interfaces.Services;
using Cadier.Business;
using Cadier.DB.Repositories;
using Cadier.Abstractions.Interfaces.Repositories;

namespace Cadier.Core
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            #region Configuracoes
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Configurar as configurações JWT
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
            services.AddSingleton<JwtSettings>(jwtSettings);            

            // Adicionar autenticação JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    };
                });

            services.AddSingleton(
                new BancoConfig() 
                { 
                    ConnectionString = configuration.GetValue<string>("ConnectionString"),
                    TimeOut = configuration.GetValue<int>("TimeOut")
                });

            services.AddTransient<DbSession, DbSession>();
            #endregion

            #region Services
            services.AddTransient<IPFisicaService, PFisicaService>();
            #endregion

            #region Repositories
            services.AddTransient<IPFisicaRepository, PFisicaRepository>();
            #endregion

            return services;
        }
    }
}
