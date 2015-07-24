using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.OptionDescriptors;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using ReleaseManager.Api.Host.Hal;
using ReleaseManager.Api.Host.Representations;
using ReleaseManager.Api.Host.TableStorage;

namespace ReleaseManager.Api.Host
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IHostingEnvironment env)
        {
            _configuration = new Configuration()
                .AddJsonFile("Config.json");
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

            InitialiseTableStorage(app);
        }

        private void ConfigureMyServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(_configuration.GetSubKey("AppSettings"));
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
            var jsonFormatter = new JsonHalMediaTypeOutputFormatter();
            var descriptor = new OutputFormatterDescriptor(jsonFormatter);
            options.OutputFormatters.Add(descriptor);
        }

    }
}
