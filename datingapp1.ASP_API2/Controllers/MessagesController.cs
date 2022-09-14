using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace datingapp1.ASP_API2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        //private readonly IMessageRepository _messageRepository;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}




/*
public class CityController
{


    [HttpGet]
    public async Task<ActionResult<IEnumerable<City>>> GetAll()
    {
        var cities = await _mediator.Send(new GetAllCitiesQuery());

        return Ok(cities);
    }

    [HttpGet("getById/{id}")]
    public async Task<ActionResult<IEnumerable<City>>> GetById(int id)
    {
        var cities = await _mediator.Send(new GetCityByIdQuery() { CityId = id });

        return Ok(cities);
    }

    [HttpGet("searchByText/{text}")]
    public async Task<ActionResult<IEnumerable<City>>> SearchByText(string text)
    {
        var cities = await _mediator.Send(new GetCitiesByTextQuery() { searchText = text });

        return Ok(cities);
    }

}*/