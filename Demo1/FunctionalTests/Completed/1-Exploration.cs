using FluentAssertions;
using HelloWebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTests
{
    //public class hello_api_should
    //{
    //    [Fact]
    //    public async Task get_the_prompt_for_user()
    //    {
    //        var builder = new WebHostBuilder();
    //        builder.UseStartup<Startup>();

    //        var server = new TestServer(builder);

    //        (await server.CreateRequest("api/hello?name=Unai")
    //            .GetAsync()).StatusCode.Should().Be(HttpStatusCode.OK);
    //    }

    //    [Fact]
    //    public async Task post_do_some_action()
    //    {
    //        var builder = new WebHostBuilder();
    //        builder.UseStartup<Startup>();

    //        var server = new TestServer(builder);

    //        (await server.CreateRequest("api/hello").AddHeader("content-type", "application/json")
    //            .PostAsync()).StatusCode.Should().Be(HttpStatusCode.OK);

    //    }
    //}
}
