using mdland_dotnet_template_lib.Common.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace homework_api
{
    public class Startup : BaseStartup
    {
        public static string AppName { get; set; }

        public Startup(IConfiguration configuration) : base(configuration)
        {
            AppName = base.appName;
        }
        
        
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            //write you code here
            //services.AddTransient<IProfileService, ProfileServiceImpl>();
        }

        protected override Type GetProgramType()
        {
            return typeof(Program);
        }

        protected override string GetVersionFromCode()
        {
            return "1.0.0.1";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override  void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration config, ILoggerFactory loggerFactory)
        {
            base.Configure(app, env, config, loggerFactory);
            //write you code here
        }
    }
}