using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaymentProvider.Application.Payments.Commands.CreatePayment;
using PaymentProvider.Application.Payments.Commands.ProcessPaymentCommand;

namespace PaymentProvider.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ApiControllerBase
    {

        public ApiController(IMediator mediator)
        {
            this.Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ActionName("ProcessPayment")]
        public async Task<ActionResult> ProcessPayment(ProcessPaymentCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

    }
}
