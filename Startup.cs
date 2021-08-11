using Book_Store.Modules;
using Book_Store.Modules.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // (option => option.EnableEndpointRouting = false) This To Disable Work
            // Routing Using EndPointRouting
            services.AddMvc(option => option.EnableEndpointRouting = false);


            //services.AddSingleton<interface_repository<Author>, repository_author >();
            //services.AddSingleton<interface_repository<Book>, repository_Book >();

            services.AddScoped<interface_repository<Author>, DB_repository_author>();
            services.AddScoped<interface_repository<Book>, DB_repository_Book>();
            services.AddDbContext<BookDBContent>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("connectionSql"));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            // Way One (1) To Routing Using (endpoint)
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller}/{action}/{id?}");
            //});

            // Way Two (2) To Routing Using (Mvc)
            app.UseMvc(route => {
                route.MapRoute("MainRoute", "{controller=controller_book}/{action=Index}/{id?}");
            });
        }
    }
}
