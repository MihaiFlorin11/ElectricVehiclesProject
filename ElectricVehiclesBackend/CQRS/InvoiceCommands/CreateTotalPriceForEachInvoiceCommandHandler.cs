using AutoMapper;
using Data.Repositories.InvoiceRepositories;
using Data.Repositories.RentalRepositories;
using Data.Repositories.VehicleRepositories;
using Data.Repositories.VehicleTypeRepositories;
using Dtos.InvoiceDtos;
using MediatR;

namespace CQRS.InvoiceCommands
{
    public class CreateTotalPriceForEachInvoiceCommandHandler : IRequestHandler<CreateTotalPriceForEachInvoiceCommand, bool>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;

        public CreateTotalPriceForEachInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IRentalRepository rentalRepository, IVehicleRepository vehicleRepository, IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
            _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _vehicleTypeRepository = vehicleTypeRepository ?? throw new ArgumentNullException(nameof(vehicleTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> Handle(CreateTotalPriceForEachInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoices = await _invoiceRepository.GetInvoicesAsync();

            var index = 1;

            foreach (var invoice in invoices)
            {
                var rental = await _rentalRepository.GetRentalByIdAsync(index);

                var vehicle = await _vehicleRepository.GetVehicleByIdAsync(index);

                var vehicleType = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(vehicle.VehicleTypeId);

                var rentalStartDateTime = DateTime.Parse(rental.StartDateTime);

                var rentalEndDateTime = DateTime.Parse(rental.EndDateTime);

                var totalMinutes = (rentalEndDateTime.Subtract(rentalStartDateTime)).TotalMinutes;

                var totalPrice = vehicleType.PricePerMinute * (decimal)totalMinutes;

                invoice.TotalPrice = totalPrice;

                var invoiceMapped = _mapper.Map<CreateTotalPriceForEachInvoiceDto>(invoice);

                await _invoiceRepository.SaveChangesAsync();

                index++;
            }

            return index - 1 == invoices.Count();
        }
    }
}
