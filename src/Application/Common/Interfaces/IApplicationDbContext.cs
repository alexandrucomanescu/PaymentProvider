using PaymentProvider.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using PaymentProvider.Domain.Enums;

namespace PaymentProvider.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Payment> Payments { get; set; }

        DbSet<PaymentState> PaymentStates { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
