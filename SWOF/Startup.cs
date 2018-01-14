using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using SWOF.BusinessLogic;
using SWOF.Core.Contract;
using SWOF.Core.Resources;
using SWOF.Data;
using SWOF.Mapping;
using SWOF.Persistence;

namespace SWOF
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

            services.AddMvc();

            // Data and repositories
            services.AddDbContext<BauDbContext>(options =>
               options.UseMySQL(Configuration.GetConnectionString("MySqlServer")));
            services.AddScoped<IEngineerRepository, EngineerRepository>();

            // Factories
            services.AddScoped<IEngineerPoolFactory, EngineerPoolFactory>();

            // Add our custom services
            services.AddScoped<IScheduleGeneratorService, ScheduleGeneratorService>();
            services.AddScoped<IScheduleStrategy, NextSlotScheduleStrategy>();
            services.AddScoped<IRuleEvaluator, RuleEvaluator>();

            // Alternative schedule generation strategies
            // services.AddScoped<IScheduleStrategy, SequentialFillScheduleStrategy>();

            // Add Adapters and their concrete types. Random - scoped so single seeded instance per web request
            services.AddScoped<IRandomAdapter, RandomAdapter>();
            services.AddScoped<Random>(x => new Random());

            // Options
            services.Configure<ScheduleOptions>(Configuration.GetSection("Schedule"));

            // Rules for schedule generation
            services.AddTransient<IRule, ConsecutiveDayRule>();
            services.AddTransient<IRule, ShiftsPerDayRule>();
            services.AddTransient<IList<IRule>>(p => p.GetServices<IRule>().ToList());

            services.AddAutoMapper();

            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                var info = new Info
                {
                    Contact = new Contact { Name = "J. Oliver" },
                    Title = "Support Wheel API",
                    Version = "v1"
                };
                c.SwaggerDoc("v1", info);

                // Set the comments path for the swagger json and ui
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "SupportWheel.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SupportWheelOfFate");
            });

            /// SeedData.Initialize(app.ApplicationServices);
            app.UseMvc();
        }
    }
}
