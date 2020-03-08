using PaymentProvider.Domain.Common;

namespace PaymentProvider.Domain.Enums
{
    public class PaymentStatus : Enumeration
    {
        public static readonly PaymentStatus Pending = new PaymentStatus(1, "Pending");
        public static readonly PaymentStatus Failed = new PaymentStatus(2, "Failed");
        public static readonly PaymentStatus Success = new PaymentStatus(3, "Success");

        public PaymentStatus(int id, string name)
            : base(id, name)
        {
        }
    }
}