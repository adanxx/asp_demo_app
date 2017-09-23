using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using aspconsoleapp.Services;
using aspconsoleapp.Data;
using Microsoft.EntityFrameworkCore;

namespace aspconsoleapp
{
    public class Startup
    {
    
     public IConfiguration Configuration { get; }

     public Startup(IHostingEnvironment env)
     {
          var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: true , reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional:true);


          builder.AddEnvironmentVariables();

          Configuration = builder.Build();
     }
       /* 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }
       */
    
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            //services.AddSingleton<IContact, InMemoryContact>(); // Connected to Inmemory Repostory
            services.AddScoped<IContact, DatabseContact>();    // Connected to Our Database DbContext;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
