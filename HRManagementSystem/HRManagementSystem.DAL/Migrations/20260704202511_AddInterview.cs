using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddInterview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterviewInfo",
                schema: "dbo",
                columns: table => new
                {
                    InterviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    InterviewerEmployeeId = table.Column<int>(type: "int", nullable: false),
                    InterviewRound = table.Column<int>(type: "int", nullable: false),
                    InterviewType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    InterviewResult = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InterviewNotes = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewInfo", x => x.InterviewID);
                    table.ForeignKey(
                        name: "FK_InterviewInfo_ApplicationInfo_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationInfo",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewInfo_EmployeesInfo_InterviewerEmployeeId",
                        column: x => x.InterviewerEmployeeId,
                        principalSchema: "dbo",
                        principalTable: "EmployeesInfo",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterviewInfo_ApplicationId",
                schema: "dbo",
                table: "InterviewInfo",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewInfo_InterviewerEmployeeId",
                schema: "dbo",
                table: "InterviewInfo",
                column: "InterviewerEmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterviewInfo",
                schema: "dbo");
        }
    }
}
