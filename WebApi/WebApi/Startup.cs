using ApplicationCore.Interfaces;
using AutoMapper;
using Mediator.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace SuperPortal2._0
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var mappingConfig = new MapperConfiguration(cfg =>
            {
                var apiTypes = typeof(IBaseProfile).GetTypeInfo().Assembly
                .GetTypes()
                .Where(t => t.BaseType == typeof(Profile));

                foreach (var type in apiTypes)
                {
                    cfg.AddProfile(type);
                }
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.Scan(scan => scan
                .FromAssemblies(typeof(IBaseRepository).GetTypeInfo().Assembly)
                .AddClasses(classes => classes.AssignableTo<IBaseRepository>(), false)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan
                .FromAssemblies(typeof(IBaseService).GetTypeInfo().Assembly)
                .AddClasses(classes => classes.AssignableTo<IBaseService>(), false)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("TestPolicy", builder =>
            //    {
            //        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            //    });
            //});

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseCors("TestPolicy");

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
