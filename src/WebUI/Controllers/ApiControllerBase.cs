using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PaymentProvider.WebUI.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        protected IMediator Mediator;
    }
}
