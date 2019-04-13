using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DRHIdentityServer.Context;
using DRHIdentityServer.Extensions;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DRHIdentityServer
{
    public class Startup
    {
        private readonly IConfiguration configuraton;
        public Startup(IConfiguration _config)
        {
            configuraton = _config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
                        
            string BDTConnection = configuraton.GetConnectionString("BDTConnection");
            services.AddDbContext<BDTContext>(options => options.UseSqlServer(BDTConnection));
            services.AddTransient<DbContext, BDTContext>();

            ILoggerFactory _loggerFactory = new LoggerFactory();
            var cors = new DefaultCorsPolicyService(_loggerFactory.CreateLogger<DefaultCorsPolicyService>()) {
                AllowedOrigins = {
                    "http://127.0.0.1:5500"
                }
            };
            services.AddSingleton<ICorsPolicyService>(cors);
            services.AddSession(options => options.Cookie.SameSite = SameSiteMode.None);
            
            string identityConnection = configuraton.GetConnectionString("IdentityConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddMvc();
            services.AddDbContext<ApplicationDbContext>(builder =>
                builder.UseSqlServer(identityConnection, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));            
            services
                .AddIdentityServer()
                .AddConfigurationStore(options =>
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(identityConnection, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
                .AddDeveloperSigningCredential()
                .AddOperationalStore(options =>
                    options.ConfigureDbContext = builder =>
                    builder.UseSqlServer(identityConnection, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
                .AddCustomUserStore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors();
            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
