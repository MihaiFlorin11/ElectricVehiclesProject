using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", maxLength: 2000, nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerMinute = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleTypes_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Paid", "TotalPrice" },
                values: new object[,]
                {
                    { 1, true, 0m },
                    { 2, true, 0m },
                    { 3, false, 0m },
                    { 4, true, 0m },
                    { 5, false, 0m },
                    { 6, true, 0m },
                    { 7, true, 0m },
                    { 8, true, 0m },
                    { 9, false, 0m },
                    { 10, false, 0m },
                    { 11, true, 0m },
                    { 12, true, 0m },
                    { 13, false, 0m },
                    { 14, true, 0m },
                    { 15, true, 0m },
                    { 16, true, 0m },
                    { 17, false, 0m },
                    { 18, true, 0m },
                    { 19, false, 0m },
                    { 20, true, 0m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "florinmazureac@gmail.com", "florinmazureac", "Administrator", "Florin Mazureac" },
                    { 2, "andreiolteanu@gmail.com", "andreiolteanu", "User", "Andrei Olteanu" },
                    { 3, "adriantabacu@gmail.com", "adriantabacu", "User", "Adrian Tabacu" },
                    { 4, "mariamanolache@gmail.com", "mariamanolache", "User", "Maria Manolache" },
                    { 5, "cristinapopescu@gmail.com", "cristinapopescu", "User", "Cristina Popescu" },
                    { 6, "dorinvoinea@gmail.com", "dorinvoinea", "User", "Dorin Voinea" },
                    { 7, "mirceaionescu@gmail.com", "mirceaionescu", "User", "Mircea Ionescu" }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Description", "PricePerMinute", "Type", "VehicleId" },
                values: new object[,]
                {
                    { 1, "This type of vehicle is represented by a classic bike with several functionalities: quality wheels that absorb vibrations and unevenness of the ground, high-quality steel frame, brakes that allow safe stopping in any situation.", 5m, "ClassicBike", null },
                    { 2, "This type of vehicle is represented by a electric bike with several functions: high-quality wheels that absorb vibrations and unevenness of the ground, high-quality steel frame, brakes that allow safe stopping in any situation, the engine that provides the necessary power for any movement and the battery with increased autonomy", 10m, "ElectricBike", null },
                    { 3, "This type of vehicle is represented by a classic scooter with several functionalities: weight variation of customers, wheels offer increased driving comfort and iron frame.", 15m, "ClassicScooter", null },
                    { 4, "This type of vehicle is represented by an electric scooter with a series of functions: long-lasting battery autonomy, speed that allows moving as quickly as possible to the desired place and wheels offer increased driving comfort.", 20m, "ElectricScooter", null },
                    { 5, "This type of vehicle is represented by a classic car with several functionalities: weight variation of customers, wheels offer increased driving comfort and safe in case of anything.", 25m, "ClassicCar", null },
                    { 6, "This type of vehicle is represented by an electric car with a series of functions: long-lasting battery autonomy, wheels offer increased driving comfort and protects the environment.", 30m, "ElectricCar", null }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "RegisterDate", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4001), 1 },
                    { 2, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4003), 1 },
                    { 3, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4003), 2 },
                    { 4, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4004), 2 },
                    { 5, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4005), 2 },
                    { 6, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4005), 3 },
                    { 7, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4006), 3 },
                    { 8, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4006), 3 },
                    { 9, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4007), 4 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "RegisterDate", "VehicleTypeId" },
                values: new object[,]
                {
                    { 10, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4008), 4 },
                    { 11, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4008), 4 },
                    { 12, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4009), 4 },
                    { 13, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4009), 5 },
                    { 14, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4010), 5 },
                    { 15, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4011), 5 },
                    { 16, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4011), 6 },
                    { 17, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4012), 6 },
                    { 18, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4012), 6 },
                    { 19, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4013), 6 },
                    { 20, new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4013), 6 }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "EndDateTime", "InvoiceId", "StartDateTime", "UserId", "VehicleId" },
                values: new object[,]
                {
                    { 1, "7:57 PM", 1, "7:37 PM", 2, 1 },
                    { 2, "8:07 PM", 2, "7:37 PM", 3, 2 },
                    { 3, "8:02 PM", 3, "7:37 PM", 4, 3 },
                    { 4, "7:52 PM", 4, "7:37 PM", 5, 4 },
                    { 5, "7:47 PM", 5, "7:37 PM", 6, 5 },
                    { 6, "8:07 PM", 6, "7:37 PM", 7, 6 },
                    { 7, "7:42 PM", 7, "7:37 PM", 2, 7 },
                    { 8, "7:47 PM", 8, "7:37 PM", 3, 8 },
                    { 9, "7:52 PM", 9, "7:37 PM", 4, 9 },
                    { 10, "7:47 PM", 10, "7:37 PM", 5, 10 },
                    { 11, "7:57 PM", 11, "7:37 PM", 6, 11 },
                    { 12, "8:07 PM", 12, "7:37 PM", 7, 12 },
                    { 13, "8:02 PM", 13, "7:37 PM", 2, 13 },
                    { 14, "7:52 PM", 14, "7:37 PM", 3, 14 },
                    { 15, "7:42 PM", 15, "7:37 PM", 4, 15 },
                    { 16, "7:52 PM", 16, "7:37 PM", 5, 16 },
                    { 17, "8:02 PM", 17, "7:37 PM", 6, 17 },
                    { 18, "7:57 PM", 18, "7:37 PM", 7, 18 },
                    { 19, "7:47 PM", 19, "7:37 PM", 2, 19 },
                    { 20, "8:07 PM", 20, "7:37 PM", 3, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_InvoiceId",
                table: "Rentals",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_VehicleId",
                table: "Rentals",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_VehicleId",
                table: "VehicleTypes",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
