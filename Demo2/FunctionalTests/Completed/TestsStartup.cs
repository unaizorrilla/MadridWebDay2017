using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionalTests
{
    class TestsStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            HelloApi.Configuration.ConfigureServices(services);

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            HelloApi.Configuration.Configure(app, env);

            //¿Porque no en mi definición de API?
            app.UseMvc();
        }
    }
}
