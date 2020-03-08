using PaymentProvider.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentProvider.WebUI.Controllers
{
    public class WeatherForecastController : ControllerBase
    {
        private IMediator _mediator;

        protected new IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }
    }
}
