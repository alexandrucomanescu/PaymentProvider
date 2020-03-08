using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentProvider.Domain.Entities;

namespace PaymentProvider.Infrastructure.Persistence.Configurations
{
    public class PaymentStatesConfiguration : IEntityTypeConfiguration<PaymentState>
    {
        public void Configure(EntityTypeBuilder<PaymentState> builder)
        {
            builder.HasKey(p => p.Id);
            builder.OwnsOne(p => p.Status, a =>
            {
                a.Property(ps => ps.Id).HasColumnName("Status");
                a.Property(ps => ps.Name).HasColumnName("StatusName");
            });
            


        }
    }
}
