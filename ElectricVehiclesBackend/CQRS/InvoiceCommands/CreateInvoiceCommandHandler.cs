using AutoMapper;
using Data.Repositories.InvoiceRepositories;
using Dtos.InvoiceDtos;
using Entities;
using MediatR;

namespace CQRS.InvoiceCommands
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, CreateInvoiceDto>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateInvoiceDto> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoiceUnmmaped = _mapper.Map<Invoice>(request);

            var invoice = await _invoiceRepository.AddInvoice(invoiceUnmmaped);

            var invoiceMapped = _mapper.Map<CreateInvoiceDto>(invoice);

            return invoiceMapped;
        }
    }
}
