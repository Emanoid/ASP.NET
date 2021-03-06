﻿using Auth20.Data;
using Auth20.Models;
using Auth20.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth20
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //Facebook
            services.AddAuthentication()
                .AddFacebook(options =>
            {
                options.AppId = "sslfsdsdf";
                options.AppSecret = "34SLKDFJOSKJDFLSDJLKJs";
            })

            //Google
            .AddGoogle(options =>
                {
                    IConfigurationSection googleAuthNSection =
                        Configuration.GetSection("Authentication:Google");

                    options.ClientId = googleAuthNSection["ClientId"];
                    options.ClientSecret = googleAuthNSection["ClientSecret"];
                })

            //Azure
            .AddOpenIdConnect("Azure AD", "Azure AD", options =>
             {
                 options.Authority = "https://login.windows.net/<Directory (tenant) ID>";
                 options.ClientId = "<Your Application (client) ID>";;
                 options.CallbackPath = "/signin-aad";
                 options.SignedOutCallbackPath = "/signout-callback-aad";
                 options.RemoteSignOutPath = "/signout-aad";
             });


            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            




            //identity options configurations
            services.Configure<IdentityOptions>(options =>
            {
                //password settings
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;

                //lockout settings
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

                //user settings
                options.User.RequireUniqueEmail = true;
            });


            services.AddMvc();





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            //var cookiePolicyOptions = new CookiePolicyOptions()
            //{
            //    MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Strict
            //};
            //app.UseCookiePolicy(cookiePolicyOptions);


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
