using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:17 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:27 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:22 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:12 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:07 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:27 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:02 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:07 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:12 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:07 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:17 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:27 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:22 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:12 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:02 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:12 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:22 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:17 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:07 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:27 AM", "6:57 AM" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4748));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4751));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4751));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4753));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4753));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4754));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4754));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4756));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4756));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4757));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4757));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 19,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4759));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 20,
                column: "RegisterDate",
                value: new DateTime(2025, 12, 6, 6, 57, 21, 322, DateTimeKind.Utc).AddTicks(4759));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:57 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "8:07 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "8:02 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:52 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:47 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "8:07 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:42 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:47 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:52 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:47 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:57 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "8:07 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "8:02 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:52 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:42 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:52 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "8:02 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:57 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "7:47 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { "8:07 PM", "7:37 PM" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4001));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4004));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4010));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4011));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4011));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 19,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4013));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 20,
                column: "RegisterDate",
                value: new DateTime(2023, 4, 12, 19, 37, 15, 705, DateTimeKind.Utc).AddTicks(4013));
        }
    }
}
