using Microsoft.EntityFrameworkCore;

namespace Aodag.Samples.Addressbook.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<Models.Person> People
        {
            get;
            set;
        }
    }
}