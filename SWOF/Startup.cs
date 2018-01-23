using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using SWOF.BusinessLogic;
using SWOF.Core.Contract;
using SWOF.Core.Resources;
using SWOF.Data;
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

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

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

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.WithOrigins("https://vinay01joshi.github.io"));

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();

            app.UseStaticFiles();
        }
    }
}
