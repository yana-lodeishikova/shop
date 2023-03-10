using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using Shop.Data.interfaces;
using Shop.Data.mocrs;
using Shop.Data.Models;
using Shop.Data.Repozitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop
{
    public class Startup {


        private IConfigurationRoot _Conftring;

        public Startup(IHostingEnvironment hostEnv) {
            _Conftring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("DbSettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_Conftring.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCar, CarRepozitory>();
            services.AddTransient<ICarsCategory, CategoryRepozitory>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddTransient<IAllOrder, OrdersRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new { Controller = "Car", action = "List" });
            });


            using (var scop = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scop.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
            
        }
    }
}
