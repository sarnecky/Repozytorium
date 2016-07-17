using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using zabawa_z_gitem.Models;

namespace zabawa_z_gitem.DAL
{
    public class StoreContext : IdentityDbContext<ApplicationUser>
    {
        public StoreContext() : base("LocalDb")
        {
            
        }

        public static StoreContext Create()
        {
            return new StoreContext();
        }
        public DbSet<TextFile> TextFiles { get; set; }
        public DbSet<Type> Types { get; set; } 
    }
}