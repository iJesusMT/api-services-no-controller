using Microsoft.EntityFrameworkCore;

namespace servicios.Models{
    public class DataContext:DbContext
    {
        public DbSet<Producto> Productos { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }
    }
}
