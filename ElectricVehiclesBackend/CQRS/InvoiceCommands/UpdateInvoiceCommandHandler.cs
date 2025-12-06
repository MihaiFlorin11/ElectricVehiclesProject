using AutoMapper;
using Data.Repositories.InvoiceRepositories;
using Dtos.InvoiceDtos;
using Entities;
using MediatR;

namespace CQRS.InvoiceCommands
{
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, UpdateInvoiceDto>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public UpdateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UpdateInvoiceDto> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoiceUnmmaped = _mapper.Map<Invoice>(request);

            var invoice = await _invoiceRepository.UpdateInvoice(invoiceUnmmaped);

            var invoiceMapped = _mapper.Map<UpdateInvoiceDto>(invoice);

            return invoiceMapped;
        }
    }
}
