using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeesApp.Migrations
{
    public partial class createDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "AccountNumber", "Age", "Name" },
                values: new object[] { new Guid("aeb5cd6a-2e9b-4c7e-9293-acb78f5f39f2"), "123-3452134543-32", 30, "Mark" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "AccountNumber", "Age", "Name" },
                values: new object[] { new Guid("576c04e1-cc91-40d3-9e3d-d3bf51d27bc2"), "123-9384613085-55", 28, "Evelin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
