using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tyuiu.MedvedevKA.Project.V16.Migrations
{
    /// <inheritdoc />
    public partial class add_TypeOperation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 13, 16, 25, 22, 668, DateTimeKind.Local).AddTicks(3372));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 14, 16, 25, 22, 668, DateTimeKind.Local).AddTicks(3391));
        }
    }
}
