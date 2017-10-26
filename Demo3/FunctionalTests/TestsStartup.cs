using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Acheve.AspNetCore.TestHost.Security;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FunctionalTests
{
    class TestsStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            HelloApi.Configuration.ConfigureServices(services)
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddTestServerAuthentication(JwtBearerDefaults.AuthenticationScheme, options =>
                 {
                     options.CommonClaims = new List<Claim>()
                     {
                        new Claim(ClaimTypes.Email,"bla@example.com")
                     };
                 });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            HelloApi.Configuration.Configure(app, env);

            //old scholl
            //app.UseMiddleware<AuthMidleware>();


            app.UseAuthentication();

            app.UseMvc();
        }
    }

    public class AuthMidleware
    {
        private readonly RequestDelegate next;

        public AuthMidleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var identity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"Unai Zorrilla"),
                new Claim(ClaimTypes.Role,"SA")
            }, "Bearer");

            context.User = new ClaimsPrincipal(identity);

            return next(context);
        }
    }
}
