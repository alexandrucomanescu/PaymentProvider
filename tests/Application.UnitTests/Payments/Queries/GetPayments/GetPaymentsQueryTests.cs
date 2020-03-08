using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PaymentProvider.Application.Payments.Queries.GetPayments;
using PaymentProvider.Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace PaymentProvider.Application.UnitTests.Payments.Queries.GetPayments
{
    [Collection("QueryTests")]
    public class GetPaymentsQueryTests
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPaymentsQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectPaymentsAndListCount()
        {
            var query = new GetPaymentsQuery();

            var handler = new GetPaymentsQuery.GetPaymentsQueryHandler(_context, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<PaymentsVm>();
            result.Payments.Count.ShouldBe(0);
        }
    }
}
