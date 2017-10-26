using Respawn;
using System;
using Xunit;
using Xunit.Sdk;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using HelloApi.Infrastructure;
using System.Linq;
using Microsoft.AspNetCore.TestHost;
using System.Threading.Tasks;
using FunctionalTests.Fixtures;

namespace FunctionalTests
{
    [Collection("Database")]
    public class some_command_should
    {
        private readonly FunctionaTestFixture _fixture;

        public some_command_should(FunctionaTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [ResetDatabase]
        public async Task work()
        {
            (await _fixture.ApiDefault.CreateRequest("api/hello")
                .GetAsync()).EnsureSuccessStatusCode();
        }
    }

   
}
