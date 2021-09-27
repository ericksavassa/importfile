using ImportFile.Application.Services;
using ImportFile.Application.Services.Interfaces;
using ImportFile.Domain.Interfaces;
using ImportFile.Infrastructure.CSVClient;
using ImportFile.Infrastructure.Repositories.Mongo;
using ImportFile.Infrastructure.Repositories.Mongo.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ImportFile
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigureInfrastructure(services);
            ConfigureApplication(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureInfrastructure(IServiceCollection services)
        {
            ItemMap.Configure();
            var mongoConfig = new MongoDBConfig();
            Configuration.Bind("MongoDB", mongoConfig);
            services.AddSingleton(mongoConfig);
            var mongoContext = new ImportFileContext(mongoConfig);
            var itemMongoRepository = new ItemDbRepository(mongoContext);

            services.AddSingleton<IItemDbRepository>(itemMongoRepository);
            services.AddSingleton<IItemJsRepository>(new ItemJsRepository());

            services.AddSingleton<ICSVClient>(new CSVClient());
        }

        private void ConfigureApplication(IServiceCollection services)
        {
            services.AddScoped<IImportFileService, ImportFileService>();
            services.AddScoped<IItemService, ItemService>();
        }
    }
}