using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MusicApiData;
using MusicApiData.DAL;
using MusicApiData.Models;
using MusicApiData.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MusicApi
{
    /// <summary>
    /// API startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes startup class
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Property containing configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures services
        /// </summary>
        /// <param name="services">Collection of services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "MusicApi", Version = "v1" });
                var commentsFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var commentsPath = Path.Combine(AppContext.BaseDirectory, commentsFileName);
                options.IncludeXmlComments(commentsPath);
            });
            services.AddDbContext<MusicApiDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MusicApiDbConnection")));
            services.AddTransient<IMusicApiDao<Playlist>, MusicApiDao<Playlist>>();
            services.AddTransient<IMusicApiDao<Album>, MusicApiDao<Album>>();
            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        /// <summary>
        /// Configures the app
        /// </summary>
        /// <param name="app">App to configure</param>
        /// <param name="env">Web host environment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
