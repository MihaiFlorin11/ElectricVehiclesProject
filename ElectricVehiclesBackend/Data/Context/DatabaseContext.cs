using Entities;
using Data.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data.Context
{
    public class DatabaseContext : DbContext
    {
        private readonly DatabaseSettings _dbSettings;
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }

        public DatabaseContext(IOptions<DatabaseSettings> optionSettings)
        {
            _dbSettings = optionSettings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.RegisterDate).HasMaxLength(2000).IsRequired();
                
                entity.HasData(
                new Vehicle()
                {
                    Id = 1,
                    VehicleTypeId = 1,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 2,
                    VehicleTypeId = 1,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 3,
                    VehicleTypeId = 2,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 4,
                    VehicleTypeId = 2,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 5,
                    VehicleTypeId = 2,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 6,
                    VehicleTypeId = 3,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 7,
                    VehicleTypeId = 3,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 8,
                    VehicleTypeId = 3,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 9,
                    VehicleTypeId = 4,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 10,
                    VehicleTypeId = 4,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 11,
                    VehicleTypeId = 4,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 12,
                    VehicleTypeId = 4,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 13,
                    VehicleTypeId = 5,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 14,
                    VehicleTypeId = 5,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 15,
                    VehicleTypeId = 5,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 16,
                    VehicleTypeId = 6,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 17,
                    VehicleTypeId = 6,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 18,
                    VehicleTypeId = 6,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 19,
                    VehicleTypeId = 6,
                    RegisterDate = DateTime.UtcNow,
                },
                new Vehicle()
                {
                    Id = 20,
                    VehicleTypeId = 6,
                    RegisterDate = DateTime.UtcNow,
                });
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Description).HasMaxLength(2000).IsRequired();
                entity.Property(x => x.PricePerMinute).IsRequired();

                entity.HasData(
                new VehicleType()
                {
                    Id = 1,
                    Description = "This type of vehicle is represented by a classic bike with several functionalities: " +
                                  "quality wheels that absorb vibrations and unevenness of the ground, high-quality steel frame, " +
                                  "brakes that allow safe stopping in any situation.",
                    Type = "ClassicBike",
                    PricePerMinute = 5,
                },
                new VehicleType()
                {
                    Id = 2,
                    Description = "This type of vehicle is represented by a electric bike with several functions: high-quality " +
                                  "wheels that absorb vibrations and unevenness of the ground, high-quality steel frame, brakes that allow safe " +
                                  "stopping in any situation, the engine that provides the necessary power for any movement and the battery with " +
                                  "increased autonomy",
                    Type = "ElectricBike",
                    PricePerMinute = 10,
                },
                new VehicleType()
                {
                    Id = 3,
                    Description = "This type of vehicle is represented by a classic scooter with several functionalities: " +
                                  "weight variation of customers, wheels offer increased driving comfort and iron frame.",
                    Type = "ClassicScooter",
                    PricePerMinute = 15,
                },
                new VehicleType()
                {
                    Id = 4,
                    Description = "This type of vehicle is represented by an electric scooter with a series of functions: " +
                                  "long-lasting battery autonomy, speed that allows moving as quickly as possible to the desired place and " +
                                  "wheels offer increased driving comfort.",
                    Type = "ElectricScooter",
                    PricePerMinute = 20,
                },
                new VehicleType()
                {
                    Id = 5,
                    Description = "This type of vehicle is represented by a classic car with several functionalities: " +
                                  "weight variation of customers, wheels offer increased driving comfort and safe in case of anything.",
                    Type = "ClassicCar",
                    PricePerMinute = 25,
                },
                new VehicleType()
                {
                    Id = 6,
                    Description = "This type of vehicle is represented by an electric car with a series of functions: long-lasting " +
                                  "battery autonomy, wheels offer increased driving comfort and protects the environment.",
                    Type = "ElectricCar",
                    PricePerMinute = 30,

                });
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.TotalPrice).IsRequired();
                entity.Property(x => x.Paid).IsRequired();

                entity.HasData(
                    new Invoice()
                    {
                        Id = 1,
                        Paid = true,
                    },
                    new Invoice()
                    {
                        Id = 2,
                        Paid = true,
                    },
                    new Invoice()
                    {
                        Id = 3,
                        Paid = false,
                    },
                    new Invoice()
                    {
                        Id = 4,
                        Paid = true,
                    },
                    new Invoice()
                    {
                        Id = 5,   
                        Paid = false,
                    },
                    new Invoice()
                    {
                        Id = 6,
                        Paid = true,
                    },
                    new Invoice()
                    {
                        Id = 7,
                        Paid = true,
                    },
                    new Invoice()
                    {
                        Id = 8,
                        Paid = true,
                    },
                    new Invoice()
                    {
                        Id = 9,
                        Paid = false,
                    },
                    new Invoice()
                    {
                        Id = 10,
                        Paid = false,
                    },
                    new Invoice()
                    {
                        Id = 11,
                        Paid = true,
                    },
                    new Invoice()
                    {
                        Id = 12,
                        Paid = true,
                    },
                    new Invoice()
                    {
                        Id = 13,
                        Paid = false,
                    },
                    new Invoice()
                    {
                        Id = 14,
                        Paid = true,
                    },
                    new Invoice()
                    {
                        Id = 15,
                        Paid = true,
                    },
                    new Invoice()
                    {
                        Id = 16,
                        Paid = true,
                    },
                    new Invoice()
                    {
                        Id = 17,
                        Paid = false,
                    },
                    new Invoice()
                    {
                        Id = 18,
                        Paid = true,
                    },
                    new Invoice()
                    {
                        Id = 19,
                        Paid = false,
                    }, new Invoice()
                    {
                        Id = 20,
                        Paid = true,
                    });
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.VehicleId).IsRequired();
                entity.Property(x => x.UserId).IsRequired();
                entity.Property(x => x.InvoiceId).IsRequired();
                entity.Property(x => x.StartDateTime).IsRequired();
                entity.Property(x => x.EndDateTime).IsRequired();

                entity.HasOne(x => x.Vehicle)
                      .WithMany(x => x.Rentals)
                      .HasForeignKey(x => x.VehicleId);

                entity.HasOne(x => x.User)
                      .WithMany(x => x.Rentals)
                      .HasForeignKey(x => x.UserId);

                entity.HasData(
                    new Rental()
                    {
                        Id = 1,
                        VehicleId = 1,
                        UserId = 2,
                        InvoiceId = 1,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(20).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 2,
                        VehicleId = 2,
                        UserId = 3,
                        InvoiceId = 2,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(30).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 3,
                        VehicleId = 3,
                        UserId = 4,
                        InvoiceId = 3,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(25).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 4,
                        VehicleId = 4,
                        UserId = 5,
                        InvoiceId = 4,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(15).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 5,
                        VehicleId = 5,
                        UserId = 6,
                        InvoiceId = 5,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(10).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 6,
                        VehicleId = 6,
                        UserId = 7,
                        InvoiceId = 6,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(30).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 7,
                        VehicleId = 7,
                        UserId = 2,
                        InvoiceId = 7,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(5).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 8,
                        VehicleId = 8,
                        UserId = 3,
                        InvoiceId = 8,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(10).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 9,
                        VehicleId = 9,
                        UserId = 4,
                        InvoiceId = 9,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(15).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 10,
                        VehicleId = 10,
                        UserId = 5,
                        InvoiceId = 10,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(10).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 11,
                        VehicleId = 11,
                        UserId = 6,
                        InvoiceId = 11,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(20).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 12,
                        VehicleId = 12,
                        UserId = 7,
                        InvoiceId = 12,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(30).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 13,
                        VehicleId = 13,
                        UserId = 2,
                        InvoiceId = 13,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(25).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 14,
                        VehicleId = 14,
                        UserId = 3,
                        InvoiceId = 14,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(15).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 15,
                        VehicleId = 15,
                        UserId = 4,
                        InvoiceId = 15,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(5).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 16,
                        VehicleId = 16,
                        UserId = 5,
                        InvoiceId = 16,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(15).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 17,
                        VehicleId = 17,
                        UserId = 6,
                        InvoiceId = 17,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(25).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 18,
                        VehicleId = 18,
                        UserId = 7,
                        InvoiceId = 18,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(20).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 19,
                        VehicleId = 19,
                        UserId = 2,
                        InvoiceId = 19,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(10).ToShortTimeString(),
                    },
                    new Rental()
                    {
                        Id = 20,
                        VehicleId = 20,
                        UserId = 3,
                        InvoiceId = 20,
                        StartDateTime = DateTime.UtcNow.ToShortTimeString(),
                        EndDateTime = DateTime.UtcNow.AddMinutes(30).ToShortTimeString(),
                    });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Username).HasMaxLength(2000).IsRequired();
                entity.Property(x => x.Email).HasMaxLength(2000).IsRequired();
                entity.Property(x => x.Password).HasMaxLength(2000).IsRequired();
                entity.Property(x => x.Role).HasMaxLength(2000).IsRequired();

                entity.HasData(
                   new User()
                   {
                       Id = 1,
                       Username = "Florin Mazureac",
                       Email = "florinmazureac@gmail.com",
                       Password = "florinmazureac",
                       Role = "Administrator"

                   },
                   new User()
                   {
                       Id = 2,
                       Username = "Andrei Olteanu",
                       Email = "andreiolteanu@gmail.com",
                       Password = "andreiolteanu",
                       Role = "User"
                   },
                   new User()
                   {
                       Id = 3,
                       Username = "Adrian Tabacu",
                       Email = "adriantabacu@gmail.com",
                       Password = "adriantabacu",
                       Role = "User"
                   },
                   new User()
                   {
                       Id = 4,
                       Username = "Maria Manolache",
                       Email = "mariamanolache@gmail.com",
                       Password = "mariamanolache",
                       Role = "User"
                   },
                   new User()
                   {
                       Id = 5,
                       Username = "Cristina Popescu",
                       Email = "cristinapopescu@gmail.com",
                       Password = "cristinapopescu",
                       Role = "User"
                   },
                   new User()
                   {
                       Id = 6,
                       Username = "Dorin Voinea",
                       Email = "dorinvoinea@gmail.com",
                       Password = "dorinvoinea",
                       Role = "User"
                   },
                   new User()
                   {
                       Id = 7,
                       Username = "Mircea Ionescu",
                       Email = "mirceaionescu@gmail.com",
                       Password = "mirceaionescu",
                       Role = "User"
                   });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
