using Microsoft.EntityFrameworkCore;

namespace HeatingPlate_WEB.Data
{
    public class ApplicationContext:DbContext
    {
        public DbSet<metals> metals{ get; set; }
        public DbSet<coefficients> coefficients { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        { 
        
        }
    }
}
