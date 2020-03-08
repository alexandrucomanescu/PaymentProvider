using PaymentProvider.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentProvider.WebUI.Controllers
{
    public class WeatherForecastController : ApiController
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();


        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }
    }
}
