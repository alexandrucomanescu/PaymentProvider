using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentProvider.Domain.Entities;

namespace PaymentProvider.Infrastructure.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.Amount, a =>
            {
                a.Property(a => a.Value).HasColumnName("Amount");
            });

            builder.OwnsOne(p => p.CreditCardNumber, a =>
            {
                a.Property(a => a.Number).HasColumnName("CreditCardNumber");
            });
            builder.OwnsOne(p => p.SecurityCode, a =>
            {
                a.Property(a => a.Code).HasColumnName("SecurityCode");
            });

            builder.HasOne(p => p.PaymentState);
            //    .WithMany()
            //    .HasForeignKey("_paymentStateId"); 

            builder.Property(p => p.CardHolder)
                .IsRequired();
            builder.Property(p => p.ExpirationDate)
                .IsRequired();

        }
    }
}