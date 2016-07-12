using System.Data.Entity;
using zabawa_z_gitem.Models;

namespace zabawa_z_gitem.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("LocalDb")
        {
            
        }
        public DbSet<TextFile> TextFiles { get; set; }
        public DbSet<Type> Types { get; set; } 
    }
}