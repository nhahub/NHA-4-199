using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobRequisitionInfo_EmployeesInfo_EmployeeID",
                table: "JobRequisitionInfo");

            migrationBuilder.AddForeignKey(
                name: "FK_JobRequisitionInfo_EmployeesInfo_EmployeeID",
                table: "JobRequisitionInfo",
                column: "EmployeeID",
                principalSchema: "dbo",
                principalTable: "EmployeesInfo",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobRequisitionInfo_EmployeesInfo_EmployeeID",
                table: "JobRequisitionInfo");

            migrationBuilder.AddForeignKey(
                name: "FK_JobRequisitionInfo_EmployeesInfo_EmployeeID",
                table: "JobRequisitionInfo",
                column: "EmployeeID",
                principalSchema: "dbo",
                principalTable: "EmployeesInfo",
                principalColumn: "EmployeeID");
        }
    }
}
