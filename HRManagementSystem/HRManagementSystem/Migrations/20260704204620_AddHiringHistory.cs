using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddHiringHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HiringHistoryInfo",
                schema: "dbo",
                columns: table => new
                {
                    HiringHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ApprovedByEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Decision = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiringHistoryInfo", x => x.HiringHistoryID);
                    table.ForeignKey(
                        name: "FK_HiringHistoryInfo_ApplicationInfo_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationInfo",
                        principalColumn: "ApplicationID");
                    table.ForeignKey(
                        name: "FK_HiringHistoryInfo_EmployeesInfo_ApprovedByEmployeeId",
                        column: x => x.ApprovedByEmployeeId,
                        principalSchema: "dbo",
                        principalTable: "EmployeesInfo",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_HiringHistoryInfo_EmployeesInfo_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "EmployeesInfo",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HiringHistoryInfo_ApplicationId",
                schema: "dbo",
                table: "HiringHistoryInfo",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HiringHistoryInfo_ApprovedByEmployeeId",
                schema: "dbo",
                table: "HiringHistoryInfo",
                column: "ApprovedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HiringHistoryInfo_EmployeeId",
                schema: "dbo",
                table: "HiringHistoryInfo",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HiringHistoryInfo",
                schema: "dbo");
        }
    }
}
