using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace FanSoft.CadTurmas.Api
{
    public static class SwaggerExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Cadastro de Turmas - API V1",
                    Description = "API - Cadastro de Turmas | FanSoft",
                    TermsOfService = new System.Uri("https://fansoft.com.br"),
                    Contact = new OpenApiContact() { Name = "FanSoft", Email = "nalin@fansoft.com.br" },
                    License = new OpenApiLicense { Name = "Use under LICX", Url = new System.Uri("https://example.com/license") }
                });

                c.CustomSchemaIds(x => x.FullName);

                 // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }

        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cadastro de Turmas - API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }


}