using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModsenTask.Services.EntityFrameworkCore.Events.Context;
using ModsenTask.Services.EntityFrameworkCore.Events.Entities.Data;
using ModsenTask.Services.Services;
using System;

namespace ModsenTask
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<EventDataContext>(opts =>
            {
                opts.UseSqlServer(
                    Configuration["ConnectionStrings:EventDataConnection"]);
            });

            services.AddScoped<IEventService, EventService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Event Web API",
                    Description = "Test ASP.NET Core Web API for Modsen Company",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Maksim Silkou",
                        Email = "maxim.silkou.2002@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/maksim-silkou-7906b6221/"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}