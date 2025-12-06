using Dtos.InvoiceDtos;
using MediatR;

namespace CQRS.InvoiceCommands
{
    public class CreateInvoiceCommand : IRequest<CreateInvoiceDto>
    {
        public decimal TotalPrice { get; set; }
        public bool Paid { get; set; }
    }
}
