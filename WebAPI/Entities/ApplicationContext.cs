using Microsoft.EntityFrameworkCore;

namespace WebAPI.Entities
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Sporcular> Sporculars { get; set; }
        public DbSet<Takimlar> Takimlars { get; set; }
        public DbSet<Ligler> Liglers { get; set; }
        public DbSet<Formalar> Formalars { get; set; }
    }
}
