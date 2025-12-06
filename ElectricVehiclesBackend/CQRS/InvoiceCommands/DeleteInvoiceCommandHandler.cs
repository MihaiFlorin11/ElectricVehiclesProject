using AutoMapper;
using Data.Repositories.InvoiceRepositories;
using Dtos.InvoiceDtos;
using MediatR;

namespace CQRS.InvoiceCommands
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, DeleteInvoiceDto>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public DeleteInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<DeleteInvoiceDto> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.DeleteInvoice(request.Id);

            var invoiceMapped = _mapper.Map<DeleteInvoiceDto>(invoice);

            return invoiceMapped;
        }
    }
}
