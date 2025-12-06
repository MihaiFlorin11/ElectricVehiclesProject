using CQRS.RentalCommands;
using CQRS.RentalQueries;
using Dtos.RentalDtos;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace API.Controllers
{
    [Route("api/rentals")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class RentalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentalsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ViewRentalDto>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetRentals()
        {
            var rentals = await _mediator.Send(new GetRentalsQuery());

            return Ok(rentals);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewRentalDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalById(int id)
        {
            var rental = await _mediator.Send(new GetRentalByIdQuery()
            {
                Id = id,
            });

            return Ok(rental);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CreateRentalDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> AddRental(CreateRentalDto createRentalDto)
        {
            var rental = await _mediator.Send(new CreateRentalCommand()
            {
                VehicleId = createRentalDto.VehicleId,
                UserId = createRentalDto.UserId,
                InvoiceId = createRentalDto.InvoiceId,
                StartDateTime = createRentalDto.StartDateTime,
                EndDateTime = createRentalDto.EndDateTime,
            });

            return Ok(rental);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(UpdateRentalDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRental(int id, UpdateRentalDto updateRentalDto)
        {
            if (id == 0 || id != updateRentalDto.Id)
            {
                return BadRequest();
            }

            var rental = await _mediator.Send(new UpdateRentalCommand()
            {
                Id = updateRentalDto.Id,
                StartDateTime = updateRentalDto.StartDateTime,
                EndDateTime = updateRentalDto.EndDateTime,
            });

            return Ok(rental);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(DeleteRentalDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            var rental = await _mediator.Send(new DeleteRentalCommand()
            {
                Id = id,
            });

            return Ok(rental);
        }
    }   
}
