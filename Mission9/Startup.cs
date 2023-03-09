using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mission9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // tells asp to use MVC model
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:BookDBConnection"]);
           });

            services.AddScoped<IBookstoreRepository, EFBookstoreRespository>();

            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //corresponds to wwwroot
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            //endpoints. the order determines url order and order for finding the page?
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("categorypage", "{category}/Page{pageNum}", new { Controller = "Home", action = "Index" });


                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page_{pageNum}",
                    defaults: new { Controller = "Home", action = "Index", pageNum=1});

                endpoints.MapControllerRoute("category", "{category}",
                new { Controller = "Home", action = "Index", pageNum = 1 });


                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });

        }
    }
}
