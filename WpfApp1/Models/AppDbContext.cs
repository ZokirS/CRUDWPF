using System.Data.Entity;

namespace WpfApp1.Models
{
   public class AppDbContext: DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<AppDbContext>(new CreateDatabaseIfNotExists<AppDbContext>());
        }
       public DbSet<Staff> Staffs { get; set; }

       
    }
}
