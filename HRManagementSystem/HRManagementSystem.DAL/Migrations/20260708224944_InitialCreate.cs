using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

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
                name: "CandidateInfo",
                schema: "dbo",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateResume = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    CandidateJopRequisition = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateInfo", x => x.CandidateId);
                    table.ForeignKey(
                        name: "FK_CandidateInfo_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "Id");
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
                    DepartmentDescription = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
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
                    EmployeeHirDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EmployeeEFF_Start = table.Column<DateTime>(type: "Date", nullable: false),
                    EmployeeEFF_End = table.Column<DateTime>(type: "Date", nullable: false),
                    EmployeeBaseSalary = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    employeeAplication = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    EmployeeDepartment = table.Column<int>(type: "int", nullable: false),
                    EmployeeManger = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_EmployeesInfo_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

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
                        name: "FK_JobRequisitionInfo_DepartmentInfo_DepartmentID",
                        column: x => x.DepartmentID,
                        principalSchema: "dbo",
                        principalTable: "DepartmentInfo",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK_JobRequisitionInfo_EmployeesInfo_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "dbo",
                        principalTable: "EmployeesInfo",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_CandidateInfo_PersonID",
                schema: "dbo",
                table: "CandidateInfo",
                column: "PersonID",
                unique: true);

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
                name: "IX_EmployeesInfo_PersonID",
                schema: "dbo",
                table: "EmployeesInfo",
                column: "PersonID",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_JobRequisitionInfo_DepartmentID",
                table: "JobRequisitionInfo",
                column: "DepartmentID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Email",
                table: "Persons",
                column: "Email",
                unique: true);

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
                name: "AttendanceInfo");

            migrationBuilder.DropTable(
                name: "HiringHistoryInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "InterviewInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LeaveRequestInfo");

            migrationBuilder.DropTable(
                name: "PayrollInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WorkShiftInfo");

            migrationBuilder.DropTable(
                name: "ApplicationInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CandidateInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JobRequisitionInfo");

            migrationBuilder.DropTable(
                name: "EmployeesInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DepartmentInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
