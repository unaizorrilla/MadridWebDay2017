using HelloApi.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace HelloApi
{
    public static class Configuration
    {
        static public IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters()
                .AddAuthorization();

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });


            services.AddDbContext<SomeContext>(options =>
            {
                options.EnableSensitiveDataLogging(true);
                options.UseSqlServer("Server=.;Initial Catalog=samples;Integrated Security=true", opts =>
                {
                });
            });


            return services;
        }

        static public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}
