using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingTaskEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Assigned",
                table: "Tasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Assigned",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "MonthlySalary", "Phone" },
                values: new object[] { 1, new DateTime(1993, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "aleksandra@gmail.com", "Aleksandra", "Brankovan", 323f, "018200200" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Assigned", "Description", "DueDate", "EmployeeId", "Title" },
                values: new object[] { 1, true, "Clean work table", new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Cleaning" });
        }
    }
}
