using System.Data.Entity;
using System.Threading.Tasks;

namespace GOOS_Sample.Models
{
    public interface IBudgetsRepository
    {
        DbSet<Budget> Budgets { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}