using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using perfectPixelApi.Models;
using perfectPixelApi.Data;
using Microsoft.EntityFrameworkCore;
using perfectPixelApi.Data.Repositories;
using perfectPixelApi.Services;
using perfectPixelApi.Services.impl;

namespace perfectPixelApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ImageContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("ImageContext")));

            services.AddScoped<ImageDataInitializer>();
            services.AddScoped<ISubmittedImageRepository, SubmittedImageRepository>();
            services.AddScoped<IScoreRepository, ScoreRepository>();
            services.AddScoped<IScoreService,ScoreServiceImpl>(); 


            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "apidocs";
                c.Title = "PerfectPixel API";
                c.Version = "v1";
                c.Description = "Images and score for PerfectPixel site";
            });
            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ImageDataInitializer imageDataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwaggerUi3();
            app.UseSwagger();
            app.UseCors("AllowAllOrigins");
            imageDataInitializer.InitializeData();
        }
    }
}
