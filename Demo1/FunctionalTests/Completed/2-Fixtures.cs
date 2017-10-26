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
    //demo 2 
    //public class withfixture_hello_api_should
    //    : IClassFixture<ServerFixture>
    //{
    //    public ServerFixture Server { get; private set; }
        
    //    public withfixture_hello_api_should(ServerFixture serverFixture)
    //    {
    //        Server = serverFixture;
    //    }

    //    [Fact]
    //    public async Task get_prompt_for_user()
    //    {
    //        (await Server.DefaultApi.CreateRequest("api/hello?name=unai")
    //            .GetAsync()).StatusCode.Should().Be(HttpStatusCode.OK);
    //    }
    //}

    //public class withfixture2_hello_api_should
    //    : IClassFixture<ServerFixture>
    //{
    //    public ServerFixture Server { get; private set; }

    //    public withfixture2_hello_api_should(ServerFixture serverFixture)
    //    {
    //        Server = serverFixture;
    //    }

    //    [Fact]
    //    public async Task get_prompt_for_user()
    //    {
    //        (await Server.DefaultApi.CreateRequest("api/hello?name=unai")
    //            .GetAsync()).StatusCode.Should().Be(HttpStatusCode.OK);
    //    }
    //}

    

    //[CollectionDefinition("APICollection")]
    //public class APICollection : ICollectionFixture<ServerFixture>
    //{
    //}

    ////demo 3 

    //[Collection("APICollection")]
    //public class withfixture_hello_api_should
        
    //{
    //    public ServerFixture Server { get; private set; }

    //    public withfixture_hello_api_should(ServerFixture serverFixture)
    //    {
    //        Server = serverFixture;
    //    }

    //    [Fact]
    //    public async Task get_prompt_for_user()
    //    {
    //        (await Server.DefaultApi.CreateRequest("api/hello?name=unai")
    //            .GetAsync()).StatusCode.Should().Be(HttpStatusCode.OK);
    //    }
    //}

    //[Collection("APICollection")]
    //public class withfixture2_hello_api_should
       
    //{
    //    public ServerFixture Server { get; private set; }

    //    public withfixture2_hello_api_should(ServerFixture serverFixture)
    //    {
    //        Server = serverFixture;
    //    }

    //    [Fact]
    //    public async Task get_prompt_for_user()
    //    {
    //        (await Server.DefaultApi.CreateRequest("api/hello?name=unai")
    //            .GetAsync()).StatusCode.Should().Be(HttpStatusCode.OK);
    //    }
    //}



    //public class ServerFixture
    //    :IDisposable
    //{
    //    public TestServer DefaultApi { get; private set; }

    //    public ServerFixture()
    //    {
    //        var builder = new WebHostBuilder();
    //        builder.UseStartup<Startup>();

    //        DefaultApi = new TestServer(builder);
    //    }

    //    public void Dispose()
    //    {
    //        DefaultApi.Dispose();
    //    }
    //}
}
