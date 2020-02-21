using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ProjectManager.Entities.Context;
using ProjectManager.Repositories;
using ProjectManager.Repositories.Interfaces;

namespace ProjectManager.Core.Extensions
{
    public static class ServicesExtensions
    {
         public static void ConfigureCors (this IServiceCollection services)
        {
            services.AddCors();
        }

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ProjectManagerContext>(
                   options => options.UseNpgsql(
                   config["ProjectManagerContextDb"])
                );
        }

        public static void ConfigureRepositories (this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
        }

        public static void ConfigureServices (this IServiceCollection services)
        {
        }

        public static void ConfigureSwaggerDocs (this IServiceCollection services)
        {
            services.AddSwaggerGen (c =>
            {
                c.SwaggerDoc ("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ProjectManager Api",
                    Description = "Documentação da WebApi ProjectManager",
                    Contact = new OpenApiContact
                    {
                        Name = "Leonardo Nogueira da Silva",
                            Email = "leonardo.lns@outlook.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine (AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments (xmlPath);
            });
        }
    }
}