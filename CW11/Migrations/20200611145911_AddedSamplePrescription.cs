using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CW11.Migrations
{
    public partial class AddedSamplePrescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2020, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 2, new DateTime(2020, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2);
        }
    }
}
