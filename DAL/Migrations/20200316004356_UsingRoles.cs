using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UsingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Employee<int>Id",
                table: "EmployeeRole",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Employee",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "Employee",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRole_Employee<int>Id",
                table: "EmployeeRole",
                column: "Employee<int>Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Employee_Employee<int>Id",
                table: "EmployeeRole",
                column: "Employee<int>Id",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Employee_Employee<int>Id",
                table: "EmployeeRole");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeRole_Employee<int>Id",
                table: "EmployeeRole");

            migrationBuilder.DropColumn(
                name: "Employee<int>Id",
                table: "EmployeeRole");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "Employee");
        }
    }
}
