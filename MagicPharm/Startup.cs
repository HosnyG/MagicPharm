using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicPharm.Models.Context;
using MagicPharm.Models.Entites;
using MagicPharm.Models.Repositories;
using MagicPharm.Models.Repositories.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MagicPharm
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            this._config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("sqlCon"));
            });
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>().AddDefaultUI().AddDefaultTokenProviders();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddScoped<ICarouselRepository, CarouselRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMemoryCache();
            services.AddSession();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context,RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();



            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("defaultRoute","{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            DbInitializer.Seed(context);

        }
    }
}
