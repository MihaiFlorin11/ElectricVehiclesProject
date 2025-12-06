using AutoMapper;
using Data.Repositories.InvoiceRepositories;
using Dtos.InvoiceDtos;
using MediatR;

namespace CQRS.InvoiceQueries
{
    public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, IEnumerable<ViewInvoiceDto>>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public GetInvoicesQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ViewInvoiceDto>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _invoiceRepository.GetInvoicesAsync();

            var invoicesMapped = _mapper.Map<IEnumerable<ViewInvoiceDto>>(invoices);

            return invoicesMapped;

        }
    }
}
