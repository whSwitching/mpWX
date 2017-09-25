using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace mpwx
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Data.EntityModel>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("sqliteConn"));
            });

            services.AddAuthentication("CookieSchemeOperatorAuth")
                    .AddCookie("CookieSchemeOperatorAuth", options =>
                    {
                        options.Cookie.HttpOnly = true;
                        options.LoginPath = new PathString("/Account/Login");
                        options.LogoutPath = new PathString("/Account/Logout");
                        options.AccessDeniedPath = new PathString("/Home/Forbidden");
                    })
                    .AddCookie("CookieSchemeAdminAuth", options =>
                    {
                        options.Cookie.HttpOnly = true;
                        options.LoginPath = new PathString("/Account/Login");
                        options.LogoutPath = new PathString("/Account/Logout");
                        options.AccessDeniedPath = new PathString("/Home/Forbidden");
                    });

            services.AddMvc();

            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            Data.EntityModel.Initialize(serviceProvider.GetService<Data.EntityModel>());
        }
    }
}
