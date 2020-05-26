using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PersonalSite_ASP.Data;
using Microsoft.AspNetCore.Identity;
using PersonalSite_ASP.Data.Blog;

namespace PersonalSite_ASP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddDbContext<PersonalSite_ASPContext>(options =>
                    //options.UseSqlServer(Configuration.GetConnectionString("PersonalSite_ASPContext")));
            options.UseSqlServer(Configuration.GetConnectionString("PersonalSite_ASPLive")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddDefaultTokenProviders()
               .AddEntityFrameworkStores<PersonalSite_ASPContext>()
               .AddDefaultUI();

            services.AddRazorPages(options =>
            {
                options.Conventions.AllowAnonymousToPage("/");
                options.Conventions.AllowAnonymousToPage("/Contact");
                options.Conventions.AllowAnonymousToPage("/Blog/");
                options.Conventions.AllowAnonymousToPage("/Blog/Index");
                options.Conventions.AllowAnonymousToPage("/Blog/Details");
                options.Conventions.AuthorizePage("/Blog/AllPosts");
                options.Conventions.AuthorizePage("/Blog/Create");
                options.Conventions.AuthorizePage("/Blog/Delete");
                options.Conventions.AuthorizePage("/Blog/Edit");
                options.Conventions.AuthorizeFolder("/Identity");
                options.Conventions.AllowAnonymousToPage("/Identity/Login");
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
