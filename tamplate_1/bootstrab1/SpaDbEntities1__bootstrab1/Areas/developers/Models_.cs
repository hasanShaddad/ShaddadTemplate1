using System.Data.Entity;
using Tamplate_1.Models;

namespace Tamplate_1.ShaddadDbEntities1__Tamplate_1.Areas.developers
{
    public class Models_ : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Tamplate_1.ShaddadDbEntities1__Tamplate_1.Areas.developers.Models_>());

        public Models_() : base("name=Models_")
        {
        }

        public DbSet<C_Images> C_Images { get; set; }
    }
}
