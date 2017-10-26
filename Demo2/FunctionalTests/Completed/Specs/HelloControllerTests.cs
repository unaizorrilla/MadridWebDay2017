using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Threading.Tasks;
using Xunit;

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

        [Fact]
        public async Task get_prompt_for_user()
        {
            (await Server.DefaultApi.CreateRequest("api/hello")
                .GetAsync()).StatusCode.Should().Be(HttpStatusCode.OK);
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
