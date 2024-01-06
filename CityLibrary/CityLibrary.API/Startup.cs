using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityLibrary.Domain.EnvironmentConfig;
using CityLibrary.Domain.PersistenceInterfaces;
using CityLibrary.Domain.Services.Implementation;
using CityLibrary.Domain.Services.Interface;
using CityLibrary.Domain.Utility;
using CityLibrary.Persistence.EfStructures;
using CityLibrary.Persistence.Repositories.Implementation;
using JobCandidates.Persistence.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CityLibrary.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            IEnvironmentConfig config = new EnvironmentConfig();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CityLibrary.API -- " + config.CityName, Version = "v1" });
            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowAnyOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseNpgsql(config.DatabaseConnectionString);
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSingleton(config);

            services.AddScoped<IBookReadRepository, BookReadRepository>();
            services.AddScoped<IBookWriteRepository, BookWriteRepository>();
            services.AddScoped<IBookRentalReadRepository, BookRentalReadRepository>();
            services.AddScoped<IBookRentalWriteRepository, BookRentalWriteRepository>();

            services.AddScoped<IBookRentalService, BookRentalService>();
            services.AddScoped<IRegistrationService, RegistrationService>();

            services.AddScoped<IHttpSender, HttpSender>();

            using (var context = new AppDbContextFactory().CreateDbContext(
                       new[] { config.DatabaseConnectionString }))
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CityLibrary.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAnyOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
