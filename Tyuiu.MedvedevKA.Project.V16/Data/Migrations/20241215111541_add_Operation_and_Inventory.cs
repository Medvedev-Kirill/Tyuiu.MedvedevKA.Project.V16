using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tyuiu.MedvedevKA.Project.V16.Migrations
{
    /// <inheritdoc />
    public partial class add_Operation_and_Inventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperationType = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Description", "Name", "Price", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 1, "Электроника", "Description A", "Product A", 10.99m, 10, "шт." },
                    { 2, "Канцелярия", "Description B", "Product B", 25.50m, 5, "шт." }
                });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Date", "EmployeeId", "OperationType", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 13, 16, 15, 41, 471, DateTimeKind.Local).AddTicks(6346), 1, 0, 1, 100 },
                    { 2, new DateTime(2024, 12, 14, 16, 15, 41, 471, DateTimeKind.Local).AddTicks(6368), 2, 1, 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_EmployeeId",
                table: "Operations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_ProductId",
                table: "Operations",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Product",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");
        }
    }
}
