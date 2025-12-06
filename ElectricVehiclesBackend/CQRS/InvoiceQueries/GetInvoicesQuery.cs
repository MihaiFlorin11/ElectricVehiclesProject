using Dtos.InvoiceDtos;
using MediatR;

namespace CQRS.InvoiceQueries
{
    public class GetInvoicesQuery : IRequest<IEnumerable<ViewInvoiceDto>>
    {

    }
}
