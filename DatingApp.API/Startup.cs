using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DatingApp.API
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
      services.AddDbContext<DataContext>(x => x.UseSqlite
      (Configuration.GetConnectionString("DefaultConnection"))); //scaffolds the database to enable query of db
      services.AddControllers();

      //security allows browser to trust data coming back from server
      services.AddCors(); // makes service available to be used as middleware
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage(); //acts as global exception handler
      }

      // app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); //allows browser to trust data coming back from server

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers(); //Mapping controller endpoints
      });
    }
  }
}
