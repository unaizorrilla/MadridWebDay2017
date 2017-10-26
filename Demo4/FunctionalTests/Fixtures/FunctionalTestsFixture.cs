using HelloApi.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Respawn;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace FunctionalTests.Fixtures
{
    public class FunctionaTestFixture
    {
        private static readonly Checkpoint Checkpoint = new Checkpoint();

        public TestServer ApiDefault { get; private set; }

        public FunctionaTestFixture()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseStartup<TestsStartup>();

            ApiDefault = new TestServer(webHostBuilder);

            ApiDefault.Host
                .MigrateDbContext<SomeContext>((context, provider) =>
                {
                    context.MasterData.AddRange(Enumerable.Range(1, 10).Select(index =>
                    {
                        return new SomeMasterEntity() { SomeProperty = $"value{index}" };
                    }));

                    context.SaveChanges();
                });

            Checkpoint.TablesToIgnore = new string[] { "MasterData" };

        }

        public static void ResetCheckpoint()
        {
            //TODO:use configuration
            Checkpoint.Reset("Server=.;Initial Catalog=samples;Integrated Security=true");
        }
    }


    public class ResetDatabase : BeforeAfterTestAttribute
    {
        public override void Before(MethodInfo methodUnderTest)
        {
            FunctionaTestFixture.ResetCheckpoint();
        }
    }

    [CollectionDefinition("Database")]
    public class DatabaseCollection
        : ICollectionFixture<FunctionaTestFixture>
    {
    }
}
