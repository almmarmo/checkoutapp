using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mundipagg.Checkout.Application;
using Mundipagg.Checkout.Domain;
using Mundipagg.Checkout.Repository.RestApi;
using Mundipagg.Checkout.Repository.SqlEntity.Contexts;
using Mundipagg.Checkout.Service;
using Microsoft.EntityFrameworkCore;
using Mundipagg.Checkout.WebApi.Data;
using Mundipagg.Checkout.Repository.SqlEntity;

namespace Mundipagg.Checkout.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            var connectionKey = Configuration.GetValue<string>("DefaultConnectionKey");

            services.AddDbContext<CheckoutDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString(connectionKey)));

            services.AddScoped<ICheckoutRepository, CheckoutRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IAuthenticationTokenRepository, AuthenticationTokenRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();

            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<ICheckoutApplicationService, CheckoutApplicationService>();
            services.AddScoped<IAuthenticationApplicationService, AuthenticationApplicationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CheckoutDbContext context)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            //context.Database.Migrate();

            app.UseDefaultFiles(new DefaultFilesOptions() { DefaultFileNames = new List<string>() { "SignIn.html" } });
            app.UseStaticFiles();
            app.UseMvc();

            DbInitializer.Initialize(context);
        }
    }
}
