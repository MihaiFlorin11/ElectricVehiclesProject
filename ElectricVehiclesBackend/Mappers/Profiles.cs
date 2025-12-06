using AutoMapper;
using Dtos.VehicleDtos;
using Dtos.VehicleTypeDtos;
using Dtos.UserDtos;
using Entities;
using CQRS.VehicleCommands;
using CQRS.VehicleTypeCommands;
using CQRS.UserCommands;
using Dtos.RentalDtos;
using CQRS.RentalCommands;
using Dtos.InvoiceDtos;
using CQRS.InvoiceCommands;

namespace Mappers
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Vehicle, ViewVehicleDto>().ReverseMap();
            CreateMap<Vehicle, CreateVehicleDto>().ReverseMap();
            CreateMap<Vehicle, UpdateVehicleDto>().ReverseMap();
            CreateMap<Vehicle, DeleteVehicleDto>().ReverseMap();
            CreateMap<Vehicle, CreateVehicleCommand>().ReverseMap();
            CreateMap<Vehicle, UpdateVehicleCommand>().ReverseMap();
            CreateMap<Vehicle, DeleteVehicleCommand>().ReverseMap();

            CreateMap<VehicleType, ViewVehicleTypeDto>().ReverseMap();
            CreateMap<VehicleType, CreateVehicleTypeDto>().ReverseMap();
            CreateMap<VehicleType, UpdateVehicleTypeDto>().ReverseMap();
            CreateMap<VehicleType, DeleteVehicleTypeDto>().ReverseMap();
            CreateMap<VehicleType, CreateVehicleTypeCommand>().ReverseMap();
            CreateMap<VehicleType, UpdateVehicleTypeCommand>().ReverseMap();
            CreateMap<VehicleType, DeleteVehicleTypeCommand>().ReverseMap();

            CreateMap<User, ViewUserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, DeleteUserDto>().ReverseMap();
            CreateMap<User, RegisterUserDto>().ReverseMap();
            CreateMap<User, LoginUserDto>().ReverseMap();
            CreateMap<User, LoginToSendUserDto>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, DeleteUserCommand>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, LoginUserCommand>().ReverseMap();
            
            CreateMap<Rental, ViewRentalDto>().ReverseMap();
            CreateMap<Rental, CreateRentalDto>().ReverseMap();
            CreateMap<Rental, UpdateRentalDto>().ReverseMap();
            CreateMap<Rental, DeleteRentalDto>().ReverseMap();
            CreateMap<Rental, CreateRentalCommand>().ReverseMap();
            CreateMap<Rental, UpdateRentalCommand>().ReverseMap();
            CreateMap<Rental, DeleteRentalCommand>().ReverseMap();
            CreateMap<Rental, ViewRentalIdsDto>().ReverseMap();

            CreateMap<Invoice, ViewInvoiceDto>().ReverseMap();
            CreateMap<Invoice, CreateInvoiceDto>().ReverseMap();
            CreateMap<Invoice, UpdateInvoiceDto>().ReverseMap();
            CreateMap<Invoice, DeleteInvoiceDto>().ReverseMap();
            CreateMap<Invoice, CreateInvoiceCommand>().ReverseMap();
            CreateMap<Invoice, UpdateInvoiceCommand>().ReverseMap();
            CreateMap<Invoice, DeleteInvoiceCommand>().ReverseMap();
            CreateMap<Invoice, CreateTotalPriceForEachInvoiceDto>().ReverseMap();
        }
    }
}
