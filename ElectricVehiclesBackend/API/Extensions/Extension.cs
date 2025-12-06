using Data.Repositories.VehicleRepositories;
using Data.Repositories.VehicleTypeRepositories;
using Data.Repositories.UserRepositories;
using Data.Repositories.RentalRepositories;
using Data.Repositories.InvoiceRepositories;

namespace API.Extensions
{
    public static class Extension
    {
        public static void Services(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IVehicleRepository, VehicleRepository>();
            serviceCollection.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IRentalRepository, RentalRepository>();
            serviceCollection.AddScoped<IInvoiceRepository, InvoiceRepository>();
        }
    }
}
