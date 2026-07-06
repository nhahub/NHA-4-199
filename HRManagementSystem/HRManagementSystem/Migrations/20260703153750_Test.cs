using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorrectionRequestInfo");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequisitionInfo_DepartmentID",
                table: "JobRequisitionInfo",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobRequisitionInfo_DepartmentInfo_DepartmentID",
                table: "JobRequisitionInfo",
                column: "DepartmentID",
                principalSchema: "dbo",
                principalTable: "DepartmentInfo",
                principalColumn: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobRequisitionInfo_DepartmentInfo_DepartmentID",
                table: "JobRequisitionInfo");

            migrationBuilder.DropIndex(
                name: "IX_JobRequisitionInfo_DepartmentID",
                table: "JobRequisitionInfo");

            migrationBuilder.CreateTable(
                name: "CorrectionRequestInfo",
                columns: table => new
                {
                    CorrectionRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CorrectionRequestCheckIN = table.Column<DateTime>(name: "CorrectionRequest CheckIN", type: "Date", nullable: true),
                    CorrectionRequestCheckOut = table.Column<DateTime>(name: "CorrectionRequest CheckOut", type: "Date", nullable: true),
                    CorrectionRequestReason = table.Column<string>(name: "CorrectionRequest Reason", type: "varchar(500)", maxLength: 500, nullable: false),
                    CorrectionRequestStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectionRequestInfo", x => x.CorrectionRequestID);
                });
        }
    }
}
