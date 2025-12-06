using Dtos.InvoiceDtos;
using MediatR;

namespace CQRS.InvoiceQueries
{
    public class GetInvoiceByIdQuery : IRequest<ViewInvoiceDto>
    {
        public int Id { get; set; }
    }
}
