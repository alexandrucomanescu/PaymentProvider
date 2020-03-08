using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PaymentProvider.Application.Common.Interfaces;

namespace PaymentProvider.Application.Payments.Queries.GetPayments
{
    public class GetPaymentsQuery : IRequest<PaymentsVm>
    {
        public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQuery, PaymentsVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetPaymentsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PaymentsVm> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
            {
                var vm = new PaymentsVm
                {
                    Payments = await _context.Payments
                        .AsNoTracking()
                        .ProjectTo<PaymentDto>(_mapper.ConfigurationProvider)
                        .OrderBy(t => t.CardHolder)
                        .ToListAsync(cancellationToken)
                };

                return vm;
            }
        }
    }
}