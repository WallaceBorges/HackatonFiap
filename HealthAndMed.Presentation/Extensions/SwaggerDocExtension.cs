﻿using Microsoft.OpenApi.Models;
using System.Reflection;

namespace HealthAndMed.Services.Extensions
{
    /// <summary>
    /// Classe de extensão para adicionarmos no projeto as configurações
    /// de geraçao da documentação do Swagger (OpenAPI)
    /// </summary>
    public static class SwaggerDocExtension
    {
        /// <summary>
        /// Personalizando o conteudo da documentação gerada pelo Swagger
        /// </summary>
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API para controle de Consultas Médicas",
                    Description = "API REST desenvolvida em AspNet 8 com EntityFramework Hackaton Health&Med Fiap",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "FIAP Pós Tech - Health&Med",
                        Email = "wallace.c.borges@hotmail.com",
                        Url = new Uri("https://www.fiap.com.br/")
                    }
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header usando Bearer.
                                    Entre com 'Bearer [espaço] então coloque seu token.
                                    Exemplo: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                        },
                        Array.Empty<string>()
                    }
                });


                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        /// <summary>
        /// Configurando a execução da página de documentação
        /// </summary>
        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger(); //abrindo a página da documentação
            //gerando o link utilizado para importar a documentação api no POSTMAN (api-docs)
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthAndMed.Presentation");
            });

            return app;
        }
    }
}
