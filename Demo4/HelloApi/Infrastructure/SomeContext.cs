using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HelloApi.Infrastructure
{
    public class SomeContext : DbContext
    {
        public SomeContext(DbContextOptions<SomeContext> options)
            :base(options)
        {
        }

        public DbSet<SomeMasterEntity> MasterData { get; set; }

        public DbSet<SomeEntity> Entities { get; set; }

    }

    public class SomeMasterEntity
    {
        public int Id { get; set; }

        public string SomeProperty { get; set; }
    }


    public class SomeEntity
    {
        public int Id { get; set; }

        public string SomeProperty { get; set; }
    }

    public class SomeContextDesingTimeFactory
        : IDesignTimeDbContextFactory<SomeContext>
    {
        public SomeContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SomeContext>();

            builder.UseSqlServer("Server=.;Initial Catalog=samples;Integrated Security=true");

            return new SomeContext(builder.Options);
        }
    }
}
