using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentProvider.Application.Common.Interfaces;
using PaymentProvider.Application.Payments.Commands.CreatePayment;
using PaymentProvider.Domain.Entities;
using PaymentProvider.Domain.Enums;
using PaymentProvider.Domain.ValueObjects;

namespace PaymentProvider.Application.Payments.Commands.ProcessPaymentCommand
{
    public partial class ProcessPaymentCommand : IRequest
    {
        public string CreditCardNumber { get; set; }

        public string CardHolder { get; set; }

        public string SecurityCode { get; set; }

        public decimal Amount { get; set; }

        public DateTime ExpirationDate { get; set; }

        public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommand>
        {
            private readonly IApplicationDbContext _context;
            private readonly IDateTime _dateTime;
            private readonly IMediator _mediator;

            private readonly ICheapPaymentGateway _cheapPaymentGateway;
            private readonly IExpensivePaymentGateway _expensivePaymentGateway;
            private readonly IPremiumPaymentService _premiumService;

            public ProcessPaymentCommandHandler(IApplicationDbContext context, IDateTime dateTime, IMediator mediator)
            {
                _context = context;
                _dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
                _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            }

            public async Task<Unit> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
            {
                bool result = false;
                var createPaymentCommand = new CreatePaymentCommand
                {
                    Amount = request.Amount,
                    CreditCardNumber = request.CreditCardNumber,
                    SecurityCode = request.SecurityCode,
                    CardHolder = request.CardHolder,
                    ExpirationDate = request.ExpirationDate
                };

                await _mediator.Send(createPaymentCommand);
                if (request.Amount < 20)
                {
                    //result = Call _cheapPaymentGateway
                }

                if (20 < request.Amount && request.Amount <= 500)
                {
                    //result = _cheapPaymentGateway.Process()

                    /*
                     *if result = not available
                     * call _expensivePaymentGateway
                     *
                     *
                     */
                }
                if (request.Amount > 500)
                {
                   result = await TryPremiumService();
                }

                if (result)
                {
                    //TODO set payment status if service worked and we have completed the payment
                }

                return Unit.Value;
            }

            //TODO Add Polly for retry mechanism
            private async Task<bool> TryPremiumService()
            {
                int retryCount = 3;
                int currentRetry = 0;
                TimeSpan delay = TimeSpan.FromSeconds(5);
                for (; ; )
                {
                    try
                    {
                        await TransientOperationAsync();


                        // Return or break.
                        break;
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Operation Exception");

                        currentRetry++;

                        // Check if the exception thrown was a transient exception
                        // based on the logic in the error detection strategy.
                        // Determine whether to retry the operation, as well as how
                        // long to wait, based on the retry strategy.
                        if (currentRetry > retryCount || !IsTransient(ex))
                        {
                            // If this isn't a transient error or we shouldn't retry,
                            // rethrow the exception.
                            throw;
                        }
                    }

                    // Wait to retry the operation.
                    // Consider calculating an exponential delay here and
                    // using a strategy best suited for the operation and fault.
                    await Task.Delay(delay);
                }

                return true;
            }

            private bool IsTransient(Exception ex)
            {
                // Determine if the exception is transient.
                // In some cases this is as simple as checking the exception type, in other
                // cases it might be necessary to inspect other properties of the exception.
                //if (ex is OperationTransientException)
                //    return true;

                var webException = ex as WebException;
                if (webException != null)
                {
                    // If the web exception contains one of the following status values
                    // it might be transient.
                    return new[] {WebExceptionStatus.ConnectionClosed,
                            WebExceptionStatus.Timeout,
                            WebExceptionStatus.RequestCanceled }.
                        Contains(webException.Status);
                }

                // Additional exception checking logic goes here.
                return false;
            }

            // Async method that wraps a call to a remote service (details not shown).
            private async Task TransientOperationAsync()
            {
                //// Call external service.
                //await _premiumServiceAsync();
            }
        }
    }
}
