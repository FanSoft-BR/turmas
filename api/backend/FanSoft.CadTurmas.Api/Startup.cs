using System.Text;
using FanSoft.CadTurmas.Api.Infra;
using FanSoft.CadTurmas.CrossCutting.DI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FanSoft.CadTurmas.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // não serializa nulos
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.RegisterServices();
            services.AddSwagger();
            
            // var securitySettings = _configuration.GetSection("SecuritySettings");
            // services.Configure<SecuritySettings>(securitySettings);
            // ou:
            var securitySettings = new SecuritySettings();
            
            new ConfigureFromConfigurationOptions<SecuritySettings>(
                _configuration.GetSection("SecuritySettings")
            ).Configure(securitySettings);
            services.AddSingleton(securitySettings);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitySettings.SigningKey));

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme =
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer( options => {
                options.RequireHttpsMetadata = securitySettings.RequireHttpsMetadata;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = securitySettings.ValidIssuer,
                    ValidAudience = securitySettings.ValidAudience
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();

            app.UseCustomSwagger();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
