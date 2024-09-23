using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using VehicleSalesSystem.Data;

namespace VehicleSalesSystem
{
    public class Startup
    {
        // A propriedade Configuration deve ser declarada
        public IConfiguration Configuration { get; }

        // O construtor deve injetar IConfiguration
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // ConfigureServices adiciona os serviços à aplicação
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração do Entity Framework com SQL Server
            services.AddDbContext<VendaVeiculosContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("VendaVeiculosDatabase")));

            services.AddControllersWithViews();
        }

        // Configure define o pipeline de requisição HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
