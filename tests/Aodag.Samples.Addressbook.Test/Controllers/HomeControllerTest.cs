using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Aodag.Samples.Addressbook.Controllers;
using Aodag.Samples.Addressbook.Data;
using System.Linq;

namespace Aodag.Samples.Addressbook.Test.Controllers
{
    public class HomeControllerTest
    {
        public DbContextOptions<ApplicationDbContext> NewDbContextOptions()
        {
            var service = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase()
                .UseInternalServiceProvider(service);
            return builder.Options;
        }
        public HomeController NewTarget()
        {
            var dbContext = new ApplicationDbContext(NewDbContextOptions());
            return new HomeController(dbContext);
        }

        [Fact]
        public void Create()
        {
            var target = NewTarget();
            target.Create("test", "target", "testing@example.com");
            var results = target.DbContext.People.ToArray();
            Assert.NotEmpty(results);
            Assert.Equal(results[0].FirstName, "test");
            Assert.Equal(results[0].LastName, "target");
            Assert.Equal(results[0].Email, "testing@example.com");
        }
    }
}