using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Population.Entity;
namespace Population.Data
{
    public interface IDataContext
    {
      DbSet<User> User { get; set; }
      Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}