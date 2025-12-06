using Dtos.VehicleTypeDtos;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CQRS.VehicleTypeQueries;
using CQRS.VehicleTypeCommands;
using System.Net.Mime;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/vehicleTypes")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class VehicleTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleTypesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ViewVehicleTypeDto>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetVehicleTypes()
        {
            var vehicleTypes = await _mediator.Send(new GetVehicleTypesQuery());

            return Ok(vehicleTypes);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewVehicleTypeDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleTypeById(int id)
        {
            var vehicleType = await _mediator.Send(new GetVehicleTypeByIdQuery()
            {
                Id = id 
            });
            
            return Ok(vehicleType);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CreateVehicleTypeDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> AddVehicleType(CreateVehicleTypeDto createVehicleTypeDto)
        {
            var vehicleType = await _mediator.Send(new CreateVehicleTypeCommand()
            {
                Description = createVehicleTypeDto.Description,
                PricePerMinute = createVehicleTypeDto.PricePerMinute,
            });

            return Ok(vehicleType);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(UpdateVehicleTypeDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicleType(int id, UpdateVehicleTypeDto updateVehicleTypeDto)
        {
            if (id == 0 || id != updateVehicleTypeDto.Id)
            {
                return BadRequest();
            }

            var vehicleType = await _mediator.Send(new UpdateVehicleTypeCommand()
            {
                Id = updateVehicleTypeDto.Id,
                Description = updateVehicleTypeDto.Description,
                PricePerMinute = updateVehicleTypeDto.PricePerMinute,
            });

            return Ok(vehicleType);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(DeleteVehicleTypeDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleType(int id)
        {
            var vehicleType = await _mediator.Send(new DeleteVehicleTypeCommand()
            {
                Id = id,
            });

            return Ok(vehicleType);
        }
    }
}
