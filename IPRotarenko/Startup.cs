using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPRotarenko.Infastructure.Interfaces;
using IPRotarenko.Infastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IPRotarenko.Controllers;
using IPRotarenko.Data;
using IPRotarenko.Infastructure.Services.InDataBase;
using IPRotarenko.Infastructure.Services.InCookies;

namespace IPRotarenko
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); //���������� �������������� MVC  � ���������� ������ RazorRuntimeCompilation(��� ������������� ��������� Views)
            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
            services.AddScoped<IProductData, MySqlProductData>();
            services.AddScoped<IRecipeData, MySqlRecipeData>();
            services.AddScoped<IReviewSiteData, MySqlReviewSiteData>();
            services.AddHttpContextAccessor();
            services.AddScoped<ICartService, CookiesCartService>();
            services.AddScoped<IOrderService, MySqlOrderService>();
            // AddTransient ������ ��� ����� ����������� ���������
            // AddScoped ���� ��������� �� ������ ��������� 
            // AddSingleton ���� ������ �� ��� ����� ����� ���������� 
            services.AddTransient<AppContextInitial>();
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppContextInitial appContextInitial )
        {
            appContextInitial.Initialize();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
               
            }
            app.UseStaticFiles(); // ��������� ����������� ����������� ���������� 
            app.UseDefaultFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/greetings", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}"); // ������ ������ ���������� � �������� � ���.
                
            });
        }
    }
}
