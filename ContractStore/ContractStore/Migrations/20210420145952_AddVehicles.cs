using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContractStore.Migrations
{
    public partial class AddVehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VehicleType = table.Column<string>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: false),
                    ManuType = table.Column<string>(nullable: false),
                    ProductYear = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    ValidityBegin = table.Column<DateTime>(nullable: false),
                    Mass = table.Column<int>(nullable: false),
                    TransportablePeople = table.Column<int>(nullable: false),
                    NumberOfSeats = table.Column<int>(nullable: false),
                    NumberOfStandingPlaces = table.Column<int>(nullable: false),
                    RateOfPerformance = table.Column<double>(nullable: false),
                    TractionData = table.Column<string>(nullable: false),
                    TechnicalValidity = table.Column<DateTime>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    PlacedInTrafficDate = table.Column<DateTime>(nullable: false),
                    ChassisNumber = table.Column<string>(nullable: false),
                    EngineNumber = table.Column<string>(nullable: false),
                    Capacity = table.Column<double>(nullable: false),
                    Performance = table.Column<double>(nullable: false),
                    Propellant = table.Column<string>(nullable: false),
                    EnvironmentProtectionClass = table.Column<string>(nullable: false),
                    GearBoxType = table.Column<string>(nullable: false),
                    EngineData = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    LicencePlate = table.Column<string>(nullable: false),
                    ProhibitionOfSelling = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "PasswordHash",
                value: "NJSAj6vUdXexj54gYy+4DYmLpK1JNIno2W6P14JwMtccurNK");

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "ID", "Capacity", "Category", "ChassisNumber", "Color", "EngineData", "EngineNumber", "EnvironmentProtectionClass", "GearBoxType", "LicencePlate", "ManuType", "Manufacturer", "Mass", "NumberOfSeats", "NumberOfStandingPlaces", "Performance", "PlacedInTrafficDate", "ProductYear", "ProhibitionOfSelling", "Propellant", "RateOfPerformance", "RegisterDate", "TechnicalValidity", "TractionData", "TransportablePeople", "ValidityBegin", "VehicleType" },
                values: new object[,]
                {
                    { 1, 100.0, "category1", "lx123456", "kék", "abc122", "123456678", "class1", "automatic", "abc123", "type1", "bmw", 1000, 4, 0, 1200.0, new DateTime(2018, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2014, "yes", "no", 98.900000000000006, new DateTime(2016, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2222, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "good", 5, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "BMW 1" },
                    { 2, 100.0, "category2", "lr123456", "piros", "abc134", "123456678", "class2", "manual", "abc444", "type2", "audi", 1000, 4, 0, 1200.0, new DateTime(2018, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2014, "yes", "no", 98.900000000000006, new DateTime(2016, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2222, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "good", 5, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "audi 1" },
                    { 3, 100.0, "category3", "lj123456", "narancs", "abc552", "123456678", "class3", "fél automata", "abc555", "type3", "mercedes", 1000, 4, 0, 1200.0, new DateTime(2018, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2014, "yes", "no", 98.900000000000006, new DateTime(2016, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2222, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "good", 5, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "w12" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "PasswordHash",
                value: null);
        }
    }
}
