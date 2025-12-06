using AutoMapper;
using CQRS.InvoiceCommands;
using CQRS.InvoiceQueries;
using Dtos.InvoiceDtos;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace API.Controllers
{
    [Route("api/invoices")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ViewInvoiceDto>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _mediator.Send(new GetInvoicesQuery());

            return Ok(invoices);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewInvoiceDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var invoice = await _mediator.Send(new GetInvoiceByIdQuery()
            {
                Id = id,
            });

            return Ok(invoice);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CreateInvoiceDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> AddInvoice(CreateInvoiceDto createInvoiceDto)
        {
            var invoice = await _mediator.Send(new CreateInvoiceCommand()
            {
                TotalPrice = createInvoiceDto.TotalPrice,
                Paid = createInvoiceDto.Paid,
            });

            return Ok(invoice);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CreateInvoiceDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("totalprices")]
        public async Task<IActionResult> AddTotalPriceForEachInvoice()
        {
            var invoices = await _mediator.Send(new CreateTotalPriceForEachInvoiceCommand());

            return Ok(invoices);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(UpdateInvoiceDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, UpdateInvoiceDto updateInvoiceDto)
        {
            if (id == 0 || id != updateInvoiceDto.Id)
            {
                return BadRequest();
            }

            var invoice = await _mediator.Send(new UpdateInvoiceCommand()
            {
                Id = updateInvoiceDto.Id,
                TotalPrice = updateInvoiceDto.TotalPrice,
                Paid = updateInvoiceDto.Paid,
            });

            return Ok(invoice);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(DeleteInvoiceDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var invoice = await _mediator.Send(new DeleteInvoiceCommand()
            {
                Id = id,
            });

            return Ok(invoice);
        }
    }
}
