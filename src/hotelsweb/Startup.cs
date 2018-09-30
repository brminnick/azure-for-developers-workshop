using System;
using System.Security.Principal;
using System.Threading.Tasks;
using hotelsweb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Rest;
using hotelsweb.Abstractions;
using hotelsweb.Services;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Extensions.Logging;

namespace hotelsweb
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            Logger = logger;
        }

        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

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
            services.AddDbContext<HotelsContext>(options => options.UseSqlServer(GetConnectionString(),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                }));
            services.AddScoped<ITextAnalyticsClient>(factory =>
            {
                var apiKey = Configuration["SentimentAnalysis:ApiKey"];
                var baseUrl = Configuration["SentimentAnalysis:BaseUrl"];

                var credentials = new ApiKeyServiceClientCredentials(apiKey);

                return new TextAnalyticsClient(credentials) { Endpoint = baseUrl };
            });
            services.AddScoped<ITextAnalysisService, TextAnalysisService>();
            services.AddScoped<ReviewsService>();
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

            app.Use((context, next) =>
            {
                context.Request.Headers.TryGetValue("x-ms-client-principal-name", out var principalName);
                if (!string.IsNullOrEmpty(principalName))
                {
                    context.User = new GenericPrincipal(new GenericIdentity(principalName), roles: null);
                }
                return next();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }

        private string GetConnectionString()
        {
            return (Configuration["UseLocalSql"] != null && Convert.ToBoolean(Configuration["UseLocalSql"]))
                 ? Configuration.GetConnectionString("LocalConnection")
                 : Configuration.GetConnectionString("HotelsConnection");
        }

        class ApiKeyServiceClientCredentials : ServiceClientCredentials
        {
            readonly string _subscriptionKey;

            public ApiKeyServiceClientCredentials(string subscriptionKey) => _subscriptionKey = subscriptionKey;

            public override Task ProcessHttpRequestAsync(System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

                return Task.CompletedTask;
            }
        }
    }
}
