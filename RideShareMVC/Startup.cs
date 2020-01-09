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
using System.Configuration;
using System.Data.SqlClient;

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

            services.AddIdentity<IdentityUser, IdentityRole>();

            //services.AddDbContext<IdentityDataContext>(options =>
            //{
            //    var connectionString = Configuration.GetConnectionString("IdentityDataContext");
            //    options.UseSqlServer(connectionString);
            //});

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<IdentityDataContext>();
           
            //this is a sample of strongly typed connection string in the application itself
            //string connection = ConfigurationManager.ConnectionStrings["RideshareDb"].ConnectionString;
            //var connection = @"Data Source=NIKESH-DESKTOP;Initial Catalog=RideShare;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //Also this will grab the connection string from the app.settings file
            //var connStrBuilder = new SqlConnectionStringBuilder(
            //     Configuration.GetConnectionString("RideshareDb"));

            //connection string is in app.settings instead of web.config file
            services.AddDbContext<RideShareContext>(
                options =>
                {
                    var connectionString = Configuration.GetConnectionString("RideshareDb");
                    options.UseSqlServer(connectionString);
                });

            //sample from PlayerDataContext
            //services.AddDbContext<PlayerDataContext>(
            //    options =>
            //    {
            //        var connectionString = Configuration.GetConnectionString("PlayerDataContext");
            //        options.UseSqlServer(connectionString);
            //    });
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
                    template: "{controller=tblUsers}/{action=Index}/{id?}");
            });

            app.UseStaticFiles();

        }
    }
}
