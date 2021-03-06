using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SJ.Api.Core.Components;
using SJ.Api.Core.Context;
using SJ.Api.Core.Model;
using SJ.Api.Core.Repository;
using SJ.Api.Core.Repository.Base;

namespace SJ.Api.UI
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
            services.AddControllersWithViews()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            services.AddSession();
            services.AddAutoMapper(typeof(Startup));

            var connectionString = Configuration.GetSection("ConnectionStrings:Local");
            services.AddDbContext<SJApiContext>(x => x.UseSqlServer(connectionString.Value, y => y.MigrationsAssembly("SJ.Api.Core")));

            var apiConfig = new ApiConfig();
            Configuration.GetSection("APIConfigration").Bind(apiConfig);
            services.AddScoped(provider => new ApiClient(apiConfig));

            services.AddScoped<IInsuranceRepository, InsuranceRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
