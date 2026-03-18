//using System;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using Microsoft.AspNetCore.Mvc.Authorization;
//using System.Globalization;
//using Microsoft.AspNetCore.Localization;
//using CustomerCenter.Services.DI;
//using CustomerCenter.Repositories.DI;
////using CustomerCenter.Reports.DI;
//using CustomerCenter.Data.DI;
////using CustomerCenter.Proxies.DI;

//namespace CustomerCenter.API
//{
//    public class Startup
//    {
//        const string FrenchCulture = "fr-CA";
//        const string EnglishCulture = "en-CA";

//        private readonly IHostingEnvironment hostingEnvironment;
//        private readonly IConfiguration configuration;

//        private readonly IList<CultureInfo> supportedCultures = new List<CultureInfo>
//        {
//            new CultureInfo(FrenchCulture),
//            new CultureInfo(EnglishCulture)
//        };

//        public Startup(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
//        {
//            this.hostingEnvironment = hostingEnvironment;
//            this.configuration = configuration;
//        }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            // add application caching
//            services.AddMemoryCache();

//            // enable IOptions injection
//            services.AddOptions();


//            services.AddData(configuration);
//            //services.AddProxies(configuration);
//            services.ConfigureRepositories();
//            services.ConfigureBusinessLogics();
//            //services.ConfigureReports();

//            //Config.Configuration.ConfigureMapper();


//            services.AddAuthentication("Bearer")
//            .AddIdentityServerAuthentication(options =>
//            {
//                options.Authority = configuration.GetValue<string>("Authority");
//                options.RequireHttpsMetadata = configuration.GetValue<Boolean>("RequireHttpsMetadata");
//                options.ApiName = configuration["ApiName"];
//                options.ApiSecret = configuration["ApiSecret"];
//            });


//            services.AddCors(options =>
//            {
//                options.AddPolicy("GlassPolicy",
//                    builder =>
//                    {
//                        builder.WithOrigins(configuration["AllowedCorsOrigin"])
//                               .AllowAnyHeader()
//                               .AllowAnyMethod()
//                               .AllowCredentials();
//                    });
//            });

//            services.AddMvc(opts =>
//            {
//                if (this.hostingEnvironment.IsDevelopment())
//                {
//                    opts.Filters.Add(new AllowAnonymousFilter());
//                }
//            });
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
//        {
//            app.UseRequestLocalization(options =>
//            {
//                options.DefaultRequestCulture = new RequestCulture(FrenchCulture);
//                options.SupportedCultures = supportedCultures;
//                options.SupportedUICultures = supportedCultures;
//            });

//            app.UseAuthentication();

//            app.UseCors();

//            app.UseMvc();
//        }
//    }
//}
