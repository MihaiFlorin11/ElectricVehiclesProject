using Dtos.InvoiceDtos;
using MediatR;

namespace CQRS.InvoiceCommands
{
    public class UpdateInvoiceCommand : IRequest<UpdateInvoiceDto>
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Paid { get; set; }
    }
}
