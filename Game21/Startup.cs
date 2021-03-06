﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Game21.Data;
using Game21.Service;
using Game21.Service.Configuration;
using Game21.Service.Configuration.Routes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace Game21
{
    public class Startup
    {
        
        private ApplicationConfiguration Configuration { get; }
        
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(env.ContentRootPath, "configuration"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("routes.json", false, true)
                .AddEnvironmentVariables();
                        
            Configuration = new ApplicationConfiguration(builder.Build());
        }

       
      // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            // Add framework services.
            services.AddMvc();

            services.AddDbContext<PlayersContext>(options => options.UseSqlServer(
                Configuration.DefaultConnection));

//            services.AddDistributedMemoryCache();
            
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = Configuration.CacheConnection;
                options.SchemaName = "dbo";
                options.TableName = "Sessions";
            });
            
            services.AddSession(options => options.IdleTimeout = TimeSpan.FromHours(1));

            services.AddScoped<SessionService>();
            
            services.AddScoped<PlayerRepository>();
            services.AddScoped<PlayerService>();

            // Add IServiceCollection only for meta controller purposes.
            services.AddSingleton<IServiceCollection>(services);
            
            // Add Application services.
            services.AddSingleton<ApplicationConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, PlayersContext playersContext)
        {
            loggerFactory.AddConsole(Configuration.Logging);
            loggerFactory.AddDebug();

            playersContext.Database.Migrate();

            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            
            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes =>
            {
                foreach (var item in Configuration.Routes)
                {
                    routes.MapRoute(item);
                }

                routes.MapRoute("fallback", "{*whatever}", new {controller = "Home", action = "Index"});
            });
        }
    }
}