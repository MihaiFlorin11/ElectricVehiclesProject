using AutoMapper;
using Data.Repositories.InvoiceRepositories;
using Dtos.InvoiceDtos;
using MediatR;

namespace CQRS.InvoiceQueries
{
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, ViewInvoiceDto>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public GetInvoiceByIdQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ViewInvoiceDto> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(request.Id);

            var invoiceMapped = _mapper.Map<ViewInvoiceDto>(invoice);

            return invoiceMapped;
        }
    }
}
