using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeAdress",
                schema: "dbo",
                table: "EmployeesInfo");

            migrationBuilder.DropColumn(
                name: "EmployeeDateBirth",
                schema: "dbo",
                table: "EmployeesInfo");

            migrationBuilder.DropColumn(
                name: "EmployeeEmail",
                schema: "dbo",
                table: "EmployeesInfo");

            migrationBuilder.DropColumn(
                name: "EmployeeFirstName",
                schema: "dbo",
                table: "EmployeesInfo");

            migrationBuilder.DropColumn(
                name: "EmployeeGender",
                schema: "dbo",
                table: "EmployeesInfo");

            migrationBuilder.DropColumn(
                name: "EmployeeLastName",
                schema: "dbo",
                table: "EmployeesInfo");

            migrationBuilder.DropColumn(
                name: "EmployeePhone",
                schema: "dbo",
                table: "EmployeesInfo");

            migrationBuilder.DropColumn(
                name: "CandidateEmail",
                schema: "dbo",
                table: "CandidateInfo");

            migrationBuilder.DropColumn(
                name: "CandidateFirstName",
                schema: "dbo",
                table: "CandidateInfo");

            migrationBuilder.DropColumn(
                name: "CandidateLastName",
                schema: "dbo",
                table: "CandidateInfo");

            migrationBuilder.DropColumn(
                name: "CandidatePhone",
                schema: "dbo",
                table: "CandidateInfo");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeManger",
                schema: "dbo",
                table: "EmployeesInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "EmployeeBaseSalary",
                schema: "dbo",
                table: "EmployeesInfo",
                type: "Decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                schema: "dbo",
                table: "EmployeesInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                schema: "dbo",
                table: "CandidateInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesInfo_PersonID",
                schema: "dbo",
                table: "EmployeesInfo",
                column: "PersonID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateInfo_PersonID",
                schema: "dbo",
                table: "CandidateInfo",
                column: "PersonID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Email",
                table: "Persons",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateInfo_Persons_PersonID",
                schema: "dbo",
                table: "CandidateInfo",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesInfo_Persons_PersonID",
                schema: "dbo",
                table: "EmployeesInfo",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateInfo_Persons_PersonID",
                schema: "dbo",
                table: "CandidateInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesInfo_Persons_PersonID",
                schema: "dbo",
                table: "EmployeesInfo");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesInfo_PersonID",
                schema: "dbo",
                table: "EmployeesInfo");

            migrationBuilder.DropIndex(
                name: "IX_CandidateInfo_PersonID",
                schema: "dbo",
                table: "CandidateInfo");

            migrationBuilder.DropColumn(
                name: "PersonID",
                schema: "dbo",
                table: "EmployeesInfo");

            migrationBuilder.DropColumn(
                name: "PersonID",
                schema: "dbo",
                table: "CandidateInfo");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeManger",
                schema: "dbo",
                table: "EmployeesInfo",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "EmployeeBaseSalary",
                schema: "dbo",
                table: "EmployeesInfo",
                type: "Decimal(18,0)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeAdress",
                schema: "dbo",
                table: "EmployeesInfo",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmployeeDateBirth",
                schema: "dbo",
                table: "EmployeesInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmployeeEmail",
                schema: "dbo",
                table: "EmployeesInfo",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeFirstName",
                schema: "dbo",
                table: "EmployeesInfo",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeGender",
                schema: "dbo",
                table: "EmployeesInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeLastName",
                schema: "dbo",
                table: "EmployeesInfo",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeePhone",
                schema: "dbo",
                table: "EmployeesInfo",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CandidateEmail",
                schema: "dbo",
                table: "CandidateInfo",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CandidateFirstName",
                schema: "dbo",
                table: "CandidateInfo",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CandidateLastName",
                schema: "dbo",
                table: "CandidateInfo",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CandidatePhone",
                schema: "dbo",
                table: "CandidateInfo",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
