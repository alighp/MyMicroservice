using Microsoft.EntityFrameworkCore;
using SampleApplication.Core.Domain;

namespace SampleApplication.Infra.Data
{
    public class EFDBContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=. ; initial catalog = MicroService ; Trusted_connection = true");
        }
    }
}