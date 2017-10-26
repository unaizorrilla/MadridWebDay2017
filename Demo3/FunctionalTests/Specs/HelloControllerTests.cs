using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using Acheve.AspNetCore.TestHost.Security;
using System.Security.Claims;
using System.Collections.Generic;

namespace FunctionalTests
{
    public class HelloControllerTests
        :IClassFixture<ServerFixture>
    {
        ServerFixture Server;

        public HelloControllerTests(ServerFixture fixture)
        {
            Server = fixture;
        }

        //[Fact]
        //public async Task get_prompt_for_user_old_scholl()
        //{
        //    (await Server.DefaultApi.CreateRequest("api/hello")
        //        .GetAsync()).StatusCode.Should().Be(HttpStatusCode.OK);
        //}

        [Fact]
        public async Task get_prompt_for_user_acheve()
        {
            (await Server.DefaultApi.CreateRequest("api/hello")
                .WithIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,"unai"),
                    new Claim(ClaimTypes.Role,"admin")
                }).GetAsync()).StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task get_prompt_for_user_acheve_2()
        {
            (await Server.DefaultApi.CreateRequest("api/hello")
                .WithIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,"unai"),
                    new Claim(ClaimTypes.Role,"user")
                }).GetAsync()).StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }

    public class ServerFixture
    {
        public TestServer DefaultApi { get; private set; }

        public ServerFixture()
        {
            var builder = new WebHostBuilder();
            builder.UseStartup<TestsStartup>();

            DefaultApi = new TestServer(builder);
        }
    }
}
