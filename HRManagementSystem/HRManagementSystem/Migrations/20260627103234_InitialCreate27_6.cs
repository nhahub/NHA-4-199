using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate27_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "CandidateInfo",
                schema: "dbo",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateFirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CandidateLastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CandidateEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CandidatePhone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    CandidateResume = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    CandidateJopRequisition = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateInfo", x => x.CandidateId);
                });

            migrationBuilder.CreateTable(
                name: "CorrectionRequestInfo",
                columns: table => new
                {
                    CorrectionRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceID = table.Column<int>(type: "int", nullable: false),
                    CorrectionRequestCheckIN = table.Column<DateTime>(name: "CorrectionRequest CheckIN", type: "Date", nullable: true),
                    CorrectionRequestCheckOut = table.Column<DateTime>(name: "CorrectionRequest CheckOut", type: "Date", nullable: true),
                    CorrectionRequestReason = table.Column<string>(name: "CorrectionRequest Reason", type: "varchar(500)", maxLength: 500, nullable: false),
                    CorrectionRequestStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectionRequestInfo", x => x.CorrectionRequestID);
                });

            migrationBuilder.CreateTable(
                name: "WorkShiftInfo",
                columns: table => new
                {
                    WorkShiftID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    GracePeriod = table.Column<int>(type: "int", nullable: false),
                    LateThresholdMinutes = table.Column<int>(type: "int", nullable: false),
                    HalfDayThresholdMinutes = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShiftInfo", x => x.WorkShiftID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationInfo",
                schema: "dbo",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Apllicationstatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApllicationStage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    RequisitionID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationInfo", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_ApplicationInfo_CandidateInfo_CandidateID",
                        column: x => x.CandidateID,
                        principalSchema: "dbo",
                        principalTable: "CandidateInfo",
                        principalColumn: "CandidateId");
                });

            migrationBuilder.CreateTable(
                name: "AttendanceInfo",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CheckINAttendance = table.Column<DateTime>(type: "Date", nullable: false),
                    CheckOutAttendance = table.Column<DateTime>(type: "Date", nullable: false),
                    AttendanceStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShiftID = table.Column<int>(type: "int", nullable: false),
                    AttendanceSource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceInfo", x => x.AttendanceID);
                    table.ForeignKey(
                        name: "FK_AttendanceInfo_WorkShiftInfo_ShiftID",
                        column: x => x.ShiftID,
                        principalTable: "WorkShiftInfo",
                        principalColumn: "WorkShiftID");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentInfo",
                schema: "dbo",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    DepartmentName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DepartmentDescription = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    DepartmentMangr = table.Column<int>(type: "int", nullable: false),
                    CountOfDepartmentEmployee = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentInfo", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesInfo",
                schema: "dbo",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    EmployeeFirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    EmployeeLastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    EmployeeDateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeGender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmployeeHirDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EmployeeEFF_Start = table.Column<DateTime>(type: "Date", nullable: false),
                    EmployeeEFF_End = table.Column<DateTime>(type: "Date", nullable: false),
                    EmployeeEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    EmployeePhone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    EmployeeAdress = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    EmployeeBaseSalary = table.Column<decimal>(type: "Decimal(18,0)", maxLength: 100, nullable: false),
                    employeeAplication = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    EmployeeDepartment = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    EmployeeManger = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesInfo", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_EmployeesInfo_DepartmentInfo_EmployeeDepartment",
                        column: x => x.EmployeeDepartment,
                        principalSchema: "dbo",
                        principalTable: "DepartmentInfo",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK_EmployeesInfo_EmployeesInfo_EmployeeManger",
                        column: x => x.EmployeeManger,
                        principalSchema: "dbo",
                        principalTable: "EmployeesInfo",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "JobRequisitionInfo",
                columns: table => new
                {
                    JobRequisitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    JobRequisitionTitle = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    JobRequisitionDescription = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    JobRequisitionHeadCount = table.Column<int>(type: "int", nullable: false),
                    JobRequisitionStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequisitionInfo", x => x.JobRequisitionId);
                    table.ForeignKey(
                        name: "FK_JobRequisitionInfo_EmployeesInfo_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "dbo",
                        principalTable: "EmployeesInfo",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequestInfo",
                columns: table => new
                {
                    LeaveRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LeaveRequestType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OtherTypeDescription = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    LeaveRequestStartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    LeaveRequestEndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    LeaveRequestManagerStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LeaveRequestHrStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LeaveRequestComment = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequestInfo", x => x.LeaveRequestID);
                    table.ForeignKey(
                        name: "FK_LeaveRequestInfo_EmployeesInfo_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "EmployeesInfo",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "PayrollInfo",
                schema: "dbo",
                columns: table => new
                {
                    PayrollId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "Decimal(18,0)", nullable: false),
                    Allowance = table.Column<decimal>(type: "Decimal(18,0)", nullable: false),
                    Deductions = table.Column<decimal>(type: "Decimal(18,0)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "EGP"),
                    Notes = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollInfo", x => x.PayrollId);
                    table.ForeignKey(
                        name: "FK_PayrollInfo_EmployeesInfo_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "EmployeesInfo",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationInfo_CandidateID",
                schema: "dbo",
                table: "ApplicationInfo",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationInfo_RequisitionID",
                schema: "dbo",
                table: "ApplicationInfo",
                column: "RequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceInfo_EmployeeID",
                table: "AttendanceInfo",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceInfo_ShiftID",
                table: "AttendanceInfo",
                column: "ShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentInfo_DepartmentMangr",
                schema: "dbo",
                table: "DepartmentInfo",
                column: "DepartmentMangr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesInfo_EmployeeDepartment",
                schema: "dbo",
                table: "EmployeesInfo",
                column: "EmployeeDepartment");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesInfo_EmployeeManger",
                schema: "dbo",
                table: "EmployeesInfo",
                column: "EmployeeManger");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequisitionInfo_EmployeeID",
                table: "JobRequisitionInfo",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestInfo_EmployeeId",
                table: "LeaveRequestInfo",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollInfo_EmployeeId",
                schema: "dbo",
                table: "PayrollInfo",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationInfo_JobRequisitionInfo_RequisitionID",
                schema: "dbo",
                table: "ApplicationInfo",
                column: "RequisitionID",
                principalTable: "JobRequisitionInfo",
                principalColumn: "JobRequisitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceInfo_EmployeesInfo_EmployeeID",
                table: "AttendanceInfo",
                column: "EmployeeID",
                principalSchema: "dbo",
                principalTable: "EmployeesInfo",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentInfo_EmployeesInfo_DepartmentMangr",
                schema: "dbo",
                table: "DepartmentInfo",
                column: "DepartmentMangr",
                principalSchema: "dbo",
                principalTable: "EmployeesInfo",
                principalColumn: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentInfo_EmployeesInfo_DepartmentMangr",
                schema: "dbo",
                table: "DepartmentInfo");

            migrationBuilder.DropTable(
                name: "ApplicationInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AttendanceInfo");

            migrationBuilder.DropTable(
                name: "CorrectionRequestInfo");

            migrationBuilder.DropTable(
                name: "LeaveRequestInfo");

            migrationBuilder.DropTable(
                name: "PayrollInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CandidateInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobRequisitionInfo");

            migrationBuilder.DropTable(
                name: "WorkShiftInfo");

            migrationBuilder.DropTable(
                name: "EmployeesInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DepartmentInfo",
                schema: "dbo");
        }
    }
}
