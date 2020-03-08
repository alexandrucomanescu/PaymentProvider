using PaymentProvider.Application.Common.Interfaces;

namespace PaymentProvider.WebUI.IntegrationTests
{
    public class TestCurrentUserService : ICurrentUserService
    {
        public string UserId => "00000000-0000-0000-0000-000000000000";
    }
}
