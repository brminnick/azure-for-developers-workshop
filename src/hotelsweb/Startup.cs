using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using hotelsweb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace hotelsweb
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
      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });


      services.AddMvc();
      services.AddDbContext<HotelsContext>(options => options.UseSqlServer(GetConnectionString()));
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
        app.UseExceptionHandler("/Error");
        app.UseHsts();
      }

      app.Use(async (context, next) =>
      {
        context.Request.Headers.TryGetValue("x-ms-client-principal-name", out var principalName);
        if (!string.IsNullOrEmpty(principalName))
        {
          context.User = new GenericPrincipal(new GenericIdentity(principalName), roles: null);
        }
      });

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();

      app.UseMvc();
    }

    private string GetConnectionString() {
      return ( Configuration["UseLocalSql"] != null && Convert.ToBoolean(Configuration["UseLocalSql"]))
           ? Configuration.GetConnectionString("LocalConnection")
           : Configuration.GetConnectionString("HotelsConnection");
    }
  }
}
