using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tyuiu.MedvedevKA.Project.V16.Migrations
{
    /// <inheritdoc />
    public partial class Otchet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 20, 14, 48, 31, 510, DateTimeKind.Local).AddTicks(1945));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 21, 14, 48, 31, 510, DateTimeKind.Local).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                column: "SaleDate",
                value: new DateTime(2024, 12, 17, 14, 48, 31, 510, DateTimeKind.Local).AddTicks(2015));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                column: "SaleDate",
                value: new DateTime(2024, 12, 19, 14, 48, 31, 510, DateTimeKind.Local).AddTicks(2018));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 15, 14, 9, 15, 703, DateTimeKind.Local).AddTicks(52));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 16, 14, 9, 15, 703, DateTimeKind.Local).AddTicks(71));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                column: "SaleDate",
                value: new DateTime(2024, 12, 12, 14, 9, 15, 703, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                column: "SaleDate",
                value: new DateTime(2024, 12, 14, 14, 9, 15, 703, DateTimeKind.Local).AddTicks(98));
        }
    }
}
