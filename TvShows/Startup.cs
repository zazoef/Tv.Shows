using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Net.Http;
using TvShows.Interfaces.Repository;
using TvShows.Interfaces.Services;
using TvShows.Models;
using TvShows.Services;
using TvShows.Repository;

namespace TvShows
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TvShows",
                    Version = "v1"
                });
            });
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://api.tvmaze.com/") 
            };
            services.AddSingleton<HttpClient>(httpClient);
            services.AddScoped<IScraperService, ScraperService>();
            services.AddScoped<IShowService, ShowService>();
            services.AddScoped<IFileRepository<Show>, FileRepository<Show>>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TvShows");
            });
        }
    }
}
