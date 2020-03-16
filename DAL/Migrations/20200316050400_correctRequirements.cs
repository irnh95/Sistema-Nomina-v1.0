using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class correctRequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "EmployeeRole",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRole_EmployeeId",
                table: "EmployeeRole",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Employee_EmployeeId",
                table: "EmployeeRole",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Employee_EmployeeId",
                table: "EmployeeRole");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeRole_EmployeeId",
                table: "EmployeeRole");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeRole");

            migrationBuilder.AddColumn<int>(
                name: "Employee<int>Id",
                table: "EmployeeRole",
                type: "int",
                nullable: true);

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
    }
}
