using Microsoft.EntityFrameworkCore;

namespace PeopleSearch.Entities
{
    public class PeopleSearchDbContext : DbContext
    {
        public PeopleSearchDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> People { get; set; }
    }    
}
