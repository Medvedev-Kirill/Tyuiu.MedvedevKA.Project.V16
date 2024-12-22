using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tyuiu.MedvedevKA.Project.V16.Migrations
{
    /// <inheritdoc />
    public partial class SaleReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SaleDate",
                table: "Sales",
                newName: "Date");

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 20, 18, 52, 36, 898, DateTimeKind.Local).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 21, 18, 52, 36, 898, DateTimeKind.Local).AddTicks(6738));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                columns: new[] { "Date", "EmployeeId" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 52, 36, 898, DateTimeKind.Local).AddTicks(6760), 2 });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                columns: new[] { "Date", "EmployeeId" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 52, 36, 898, DateTimeKind.Local).AddTicks(6762), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Sales",
                newName: "SaleDate");

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 20, 16, 7, 47, 866, DateTimeKind.Local).AddTicks(5563));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 21, 16, 7, 47, 866, DateTimeKind.Local).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                columns: new[] { "EmployeeId", "SaleDate" },
                values: new object[] { 1, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                columns: new[] { "EmployeeId", "SaleDate" },
                values: new object[] { 2, new DateTime(2024, 12, 19, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
