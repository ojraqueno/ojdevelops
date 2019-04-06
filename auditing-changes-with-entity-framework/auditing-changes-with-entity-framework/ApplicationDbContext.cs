using Microsoft.EntityFrameworkCore;
using TrackerEnabledDbContext.Core;

namespace auditing_changes_with_entity_framework
{
    public class ApplicationDbContext : TrackerContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ef-audit;Trusted_Connection=True;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Person> Persons { get; set; }
    }
}