using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tyuiu.MedvedevKA.Project.V16.Migrations
{
    /// <inheritdoc />
    public partial class _add_Dobavil_svoistvo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 13, 18, 3, 35, 972, DateTimeKind.Local).AddTicks(9070));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 14, 18, 3, 35, 972, DateTimeKind.Local).AddTicks(9089));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 13, 17, 25, 58, 365, DateTimeKind.Local).AddTicks(5091));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 14, 17, 25, 58, 365, DateTimeKind.Local).AddTicks(5111));
        }
    }
}
