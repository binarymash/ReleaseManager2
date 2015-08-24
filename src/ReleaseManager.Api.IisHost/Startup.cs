using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Runtime;
using ReleaseManager.Api.Host.Hal;
using ReleaseManager.Api.Host.Representations;
using ReleaseManager.Api.Host.TableStorage;

namespace ReleaseManager.Api.Host
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var configurationBuilder = new ConfigurationBuilder(appEnv.ApplicationBasePath);
            configurationBuilder.AddEnvironmentVariables("BinaryMash.ReleaseManager:");
            configurationBuilder.AddJsonFile("Config.json");
            _configuration = configurationBuilder.Build();
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .Configure<MvcOptions>(options =>
                {
                    ConfigureHalOutputFormatters(options);
                    options.Filters.Add(new Filters.ExceptionHandlerFilter());
                    options.Filters.Add(new Filters.RequestIdStorageFilter());
                });

            ConfigureMyServices(services);
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc();

            if (env.IsEnvironment("Development"))
            {
                app.UseErrorPage();
            }

            InitialiseTableStorage(app);
        }

        private void ConfigureMyServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(_configuration.GetConfigurationSection("AppSettings"));
            services.AddSingleton<Storage>();
            services.AddScoped<RequestIdStore>();
            services.AddScoped<VndError.ErrorFactory>();
            services.AddScoped<Validators.RepositoryValidator>();
            services.AddScoped<Validators.TrackerValidator>();
        }

        private void InitialiseTableStorage(IApplicationBuilder app)
        {
            app.ApplicationServices.GetService<Storage>()
                .Initialise()
                .Wait();
        }

        private void ConfigureHalOutputFormatters(MvcOptions options)
        {
            var jsonHalMediaTypeOutputFormatter = new JsonHalMediaTypeOutputFormatter();
            options.OutputFormatters.Add(jsonHalMediaTypeOutputFormatter);
        }

    }
}
