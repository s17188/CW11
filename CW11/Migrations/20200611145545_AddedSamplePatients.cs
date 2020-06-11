using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CW11.Migrations
{
    public partial class AddedSamplePatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1999, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Damian", "Idzikowski" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1995, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krzysztof", "Popowski" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);
        }
    }
}
