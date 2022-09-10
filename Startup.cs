using FirstMVCCoreApp.Models;
using FirstMVCCoreApp.Repsitory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace FirstMVCCoreApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlCon")));
            services.AddScoped<IEmployeeRepository, EmployeeRepsoitory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");
            if (env.IsEnvironment("QA"))
            {
                //app.Run(async (context) =>
                //{
                //   await context.Response.WriteAsync("Development Enviroment Executed");
                //});
                app.UseDeveloperExceptionPage();


            }
            else
            {
                //app.Run(async (context) =>
                //{
                //    await context.Response.WriteAsync("Production Enviroment Executed");
                //});
                app.UseExceptionHandler("/Home/Error");
            }

            //    app.Use(async (context, next) =>
            //            {
            //                await context.Response.WriteAsync("FirstMiddleWare");
            //    await next();
            //    await context.Response.WriteAsync("FirstMiddleWare Response");


            //});


            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("SecondMiddleWare");
            //    await next();
            //    await context.Response.WriteAsync("SecondMiddleWare Response");


            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("3rd MiddleWare");
            //    await context.Response.WriteAsync("3rdMiddleWare Response");

            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("4thMiddleWare");
            //    await next();
            //    await context.Response.WriteAsync("4thMiddleWare Response");

            //});

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
