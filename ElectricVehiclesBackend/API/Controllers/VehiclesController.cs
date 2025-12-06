using AutoMapper;
using Dtos.VehicleDtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using MediatR;
using CQRS.VehicleQueries;
using CQRS.VehicleCommands;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class VehiclesController : ControllerBase
    {
        private readonly IMediator _mediator; 

        public VehiclesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ViewVehicleDto>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            var vehicles = await _mediator.Send(new GetVehiclesQuery());

            return Ok(vehicles);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewVehicleDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var vehicle = await _mediator.Send(new GetVehicleByIdQuery()
            {
                Id = id,
            });

            return Ok(vehicle);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CreateVehicleDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> AddVehicle(CreateVehicleDto createVehicleDto)
        {
            var vehicle = await _mediator.Send(new CreateVehicleCommand()
            {
                VehicleType = createVehicleDto.VehicleType,
                RegisterDate = createVehicleDto.RegisterDate.ToString(),
            });

            return Ok(vehicle);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(UpdateVehicleDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]   
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, UpdateVehicleDto updateVehicleDto)
        {
            if (id == 0 || id != updateVehicleDto.Id)
            {
                return BadRequest();
            }

            var vehicle = await _mediator.Send(new UpdateVehicleCommand()
            {
                Id = updateVehicleDto.Id,
                VehicleType = updateVehicleDto.VehicleType,
                RegisterDate = updateVehicleDto.RegisterDate.ToString(),
            });

            return Ok(vehicle);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(DeleteVehicleDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _mediator.Send(new DeleteVehicleCommand()
            {
                Id = id,
            });

            return Ok(vehicle);
        }
    }
}
