﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Kroeg.Server.BackgroundTasks;
using Kroeg.Server.Configuration;
using Kroeg.Server.Middleware;
using Kroeg.Server.Models;
using Kroeg.Server.OStatusCompat;
using Kroeg.Server.Services;
using Kroeg.Server.Services.EntityStore;
using Kroeg.Server.Tools;

namespace Kroeg.Server
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddDbContext<APContext>(options => options.UseNpgsql(Configuration.GetConnectionString("Default")).EnableSensitiveDataLogging());

            services.AddIdentity<APUser, IdentityRole>()
                .AddEntityFrameworkStores<APContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
                options.Cookies.ApplicationCookie.LoginPath = "/auth/login";
            });
            
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("Kroeg")["TokenSigningKey"]));
            services.AddSingleton(new JwtTokenSettings
            {
                Audience =Configuration.GetSection("Kroeg")["BaseUri"],
                Issuer = Configuration.GetSection("Kroeg")["BaseUri"],
                ExpiryTime = TimeSpan.FromDays(30),
                Credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            });

            services.AddSingleton(new EntityData
            {
                BaseUri = Configuration.GetSection("Kroeg")["BaseUri"],
                RewriteRequestScheme = Configuration.GetSection("Kroeg")["RewriteRequestScheme"] == "True"
            });

            services.AddSingleton<BackgroundTaskQueuer>();

            services.AddTransient<EntityFlattener>();
            services.AddTransient<CollectionTools>();
            services.AddTransient<DeliveryService>();
            services.AddTransient<DatabaseEntityStore>();
            services.AddTransient<ActivityService>();
            services.AddTransient<AtomEntryParser>();
            services.AddTransient<AtomEntryGenerator>();
            services.AddTransient<IEntityStore>((provider) =>
            {
                var dbservice = provider.GetRequiredService<DatabaseEntityStore>();
                return new RetrievingEntityStore(dbservice);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIdentity();

            var tokenSettings = app.ApplicationServices.GetRequiredService<JwtTokenSettings>();

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = tokenSettings.Credentials.Key,

                    ValidateIssuer = true,
                    ValidIssuer = Configuration.GetSection("Kroeg")["BaseUri"],

                    ValidateAudience = true,
                    ValidAudience = Configuration.GetSection("Kroeg")["BaseUri"],

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }
            });

            app.UseStaticFiles();

            app.UseDeveloperExceptionPage();
            app.UseMiddleware<GetEntityMiddleware>();
            app.UseMvc();

            app.ApplicationServices.GetRequiredService<BackgroundTaskQueuer>(); // kickstart background tasks!

//            app.ApplicationServices.GetRequiredService<APContext>().Database.EnsureDeleted();
            app.ApplicationServices.GetRequiredService<APContext>().Database.EnsureCreated();
        }
    }
}
