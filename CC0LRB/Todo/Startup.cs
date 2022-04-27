using Microsoft.AspNetCore.Builder; // Tartalmazza a beepitett koztes szoftver alkalmazashoz valo hozzaadasanak metodusait, valamint a koztes szoftver opciotipusait
using Microsoft.AspNetCore.Hosting; // Lasd: Program.cs
using Microsoft.Extensions.Hosting; // Lasd: Program.cs
using Microsoft.Extensions.Configuration; // Opcioosztalyok
using Microsoft.Extensions.DependencyInjection; // A .NET tamogatja a fuggosegi injection (DI) tervezesi mintat, amely az osztalyok es fuggosegeik kozotti vezerles inverziojanak (IoC) eleresenek technikaja

namespace Todo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Futasidoben hivodo metodus. Service-eket ad hozza a container-hez.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // Futasidoben hivodo metodus. HTTP request pipeline konfiguracioja.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // A default HSTS ertek 30 nap. Ezt lehet, hogy productionben  cserelni erdemes.
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
