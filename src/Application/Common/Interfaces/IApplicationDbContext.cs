using Accounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<Customer> Customers { get; set; }

        DbSet<FinanceYear> FinanceYears { get; set; }
        DbSet<Bond> Bonds { get; set; }
        DbSet<GeneralLedger> GeneralLedgers { get; set; }
        DbSet<MainAccount> MainAccounts { get; set; }
        DbSet<TotalAccount> TotalAccounts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
