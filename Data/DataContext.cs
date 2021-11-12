
using Microsoft.EntityFrameworkCore;
using Population.Entity;

namespace Population.Data
{
    public class DataContext: DbContext ,IDataContext
    {

        public DataContext(DbContextOptions<DataContext> options):base(options)
       {
          
       }

       public DbSet<User> User { get; set; }
  
    }
}