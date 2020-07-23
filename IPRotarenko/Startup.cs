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
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); //добавление инфраструктуры MVC  и добавление пакета RazorRuntimeCompilation(Для динамического изменения Views)
            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
            services.AddSingleton<IProductData, InMemoryProductData>();
            // AddTransient каждый раз будет создаваться экземпляр
            // AddScoped один экзнмпляр на облать видимости 
            // AddSingleton одни обьект на все время жизни приложения 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider ServiceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
               
            }
            app.UseStaticFiles(); // Разрешить запрашивать статическое содержимое 
            app.UseDefaultFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/greetings", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}"); // Строка вызова контролера и действия в нем.
                
            });
        }
    }
}
