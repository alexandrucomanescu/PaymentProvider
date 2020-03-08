using PaymentProvider.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentProvider.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        //DbSet<Payment> TodoLists { get; set; }

        //DbSet<PaymentStatus> TodoLists { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
