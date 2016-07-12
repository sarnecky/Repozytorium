using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Configuration = zabawa_z_gitem.Migrations.Configuration;

namespace zabawa_z_gitem.DAL
{
    public class Initializer : MigrateDatabaseToLatestVersion<StoreContext, Configuration>
    {

        public static void AddOrUpdateDatabase(StoreContext context)
        {
            var types = new List<Models.Type>()
            {
                new Models.Type {Name = ".pdf", IconFileName = "pdf.png"},
                new Models.Type {Name = ".txt", IconFileName = "txt.png"},
                new Models.Type {Name = ".docx", IconFileName = "docx.png"},
            };

            types.ForEach( t => context.Types.AddOrUpdate(t));
            context.SaveChanges();
        }
    }
}