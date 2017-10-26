using FluentAssertions;
using HelloWebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTests
{
    [Collection("APIServer")]
    public class hello_controller_should
        :IClassFixture<HostFixture>
    {
        private readonly HostFixture _fixture;

        public hello_controller_should(HostFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task get_prompt_for_user()
        {
            (await _fixture.APIClient.CreateRequest(API.Hello)
                .GetAsync()).EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task get_prompt_for_user2()
        {


            (await _fixture.APIClient.CreateRequest(API.Hello)
                .GetAsync()).EnsureSuccessStatusCode();
        }
    }

    [CollectionDefinition("APIServer")]
    public class HostCollection : ICollectionFixture<HostFixture>
    {

    }

    public class HostFixture
    {
        public TestServer APIClient { get; private set; }

        public HostFixture()
        {
            var builder = new WebHostBuilder()
               .UseStartup<Startup>();

            APIClient =  new TestServer(builder);
        }
    }

    public static class API
    {
        public static string Hello = "api/hello";
    }
}
