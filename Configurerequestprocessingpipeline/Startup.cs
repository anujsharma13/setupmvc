using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configurerequestprocessingpipeline
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //we added a another variable ILogger<startup> logger
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseRouting();

            app.Use(async (context,next) =>
           {
              logger.LogInformation("hello first");
              await next();
               logger.LogInformation("bye first");
           });
            app.Use(async (context, next) =>
            {
                logger.LogInformation("hello second");
                await next();
                logger.LogInformation("bye second");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("hello third");
               
                logger.LogInformation("bye third");
            });
        }
    }
}
