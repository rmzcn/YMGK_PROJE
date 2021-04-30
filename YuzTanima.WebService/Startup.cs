using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuzTanima.Business.Abstract;
using YuzTanima.Business.Concrete;
using YuzTanima.DataAccess.Abstract;
using YuzTanima.DataAccess.Concrete.EntityFramework;

namespace YuzTanima.WebService
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
            services.AddControllers();

            services.AddSingleton<IBirimlerDal, EfBirimlerDal>();
            services.AddSingleton<IBirimlerService, BirimlerManager>();

            services.AddSingleton<ICalisanlarDal, EfCalisanlarDal>();
            services.AddSingleton<ICalisanlarService, CalisanlarManager>();

            services.AddSingleton<IZiyaretcilerDal, EfZiyartcilerDal>();
            services.AddSingleton<IZiyaretcilerService, ZiyaretcilerManager>();

            services.AddSingleton<ICalisanYollariDal, EfCalisanYollariDal>();
            services.AddSingleton<ICalisanYollariService, CalisanYollariManager>();

            services.AddSingleton<IKameralarDal, EfKameralarDal>();
            services.AddSingleton<IKameralarService, KameralarManager>();

            services.AddCors(options =>
            {
                // The CORS policy is open for testing purposes. In a production application, you should restrict it to known origins.
                options.AddPolicy(
                    "AllowAll",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
