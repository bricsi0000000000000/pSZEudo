using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContractStore.Migrations
{
    public partial class AddPeopleDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WornName = table.Column<string>(nullable: false),
                    NamePrefix = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    BirthName = table.Column<string>(nullable: false),
                    MotherName = table.Column<string>(nullable: false),
                    Nationality = table.Column<string>(nullable: false),
                    BirthPlace = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PostCode = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    HouseNumber = table.Column<int>(nullable: false),
                    PersonalID = table.Column<int>(nullable: false),
                    TaxNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "BirthDate", "BirthName", "BirthPlace", "City", "Email", "FirstName", "Gender", "HouseNumber", "LastName", "MotherName", "NamePrefix", "Nationality", "PersonalID", "PhoneNumber", "PostCode", "Street", "TaxNumber", "WornName" },
                values: new object[] { 1, new DateTime(1998, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bálint", "Győr", "Győr", "balint@gmail.com", "Valamilyen", "Férfi", 2, "Bálint", "Virág", "", "magyar", 4, "0620123456", 1234, "Nagy", 213213, "Bálint" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "BirthDate", "BirthName", "BirthPlace", "City", "Email", "FirstName", "Gender", "HouseNumber", "LastName", "MotherName", "NamePrefix", "Nationality", "PersonalID", "PhoneNumber", "PostCode", "Street", "TaxNumber", "WornName" },
                values: new object[] { 2, new DateTime(1996, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ádám", "Győr", "Tiszalök", "adam@gmail.com", "Valamekkora", "Férfi", 3, "Ádám", "Evelin", "Dr.", "német", 6, "0620789123", 2345, "Kis", 543453, "Ádám" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "BirthDate", "BirthName", "BirthPlace", "City", "Email", "FirstName", "Gender", "HouseNumber", "LastName", "MotherName", "NamePrefix", "Nationality", "PersonalID", "PhoneNumber", "PostCode", "Street", "TaxNumber", "WornName" },
                values: new object[] { 3, new DateTime(1993, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zsolt", "Budapest", "Győr", "zsolt@gmail.com", "Kovács", "Férfi", 26, "Zsolt", "Lilla", "", "magyar", 4, "0620123456", 1234, "Kovács", 213213, "Zsolt" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
