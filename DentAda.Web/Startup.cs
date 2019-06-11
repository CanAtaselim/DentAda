using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentAda.Business.BusinessLogic.Locator;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DentAda.Web
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
            /*
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationScheme = "DBYSCookieMiddlewareInstance",
                LoginPath = new PathString("/Auth/Login/Unauthorized/"),
                AccessDeniedPath = new PathString("/Auth/Login/Forbidden/"),
                AutomaticAuthenticate = false,
                AutomaticChallenge = true
            });
            app.UseSession();
            */

            services.AddAuthentication("DentAda_CookieMiddlewareInstance")
                .AddCookie(obj =>
                {
                    obj.LoginPath = new PathString("/Auth/Login/Unauthorized/");
                });

            var builder = services.AddMvc();
            services.AddTransient<AdministrationBLLocator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{area=Admin}/{controller=Dashboard}/{action=Start}");
            });
        }
    }
}
