using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RideShareMVC.Models;

namespace RideShareMVC
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
            services.AddTransient<FormattingService>();

            services.AddMvc();

            //services.AddIdentity<IdentityUser, IdentityRole>();

            services.AddDbContext<PlayerDataContext>(
                options =>
                {
                    var connectionString = Configuration.GetConnectionString("PlayerDataContext");
                    options.UseSqlServer(connectionString);
                });

            services.AddDbContext<IdentityDataContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("IdentityDataContext");
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>();

            var connection = @"Data Source=MYCOMPUTER1;Initial Catalog=RideShare;User ID=rideshareAdmin;" +
                "Password=Password123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;"+
                "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            services.AddDbContext<RideShareContext>(
                options => options.UseSqlServer(connection)
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.UseIdentity();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Users}/{action=Index}/{id?}");
            });

            app.UseStaticFiles();
        }
    }
}
