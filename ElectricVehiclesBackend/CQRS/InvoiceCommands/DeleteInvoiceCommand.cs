using Dtos.InvoiceDtos;
using MediatR;

namespace CQRS.InvoiceCommands
{
    public class DeleteInvoiceCommand : IRequest<DeleteInvoiceDto>
    {
        public int Id { get; set; }
    }
}
