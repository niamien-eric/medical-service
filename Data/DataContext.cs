using Medical_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Medical_Manager.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Consult> Consults { get; set; }
    }
}
