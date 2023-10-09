using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewDiary.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auditorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAuditorium = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDepartment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameGroupWork = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameComputer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    AuditoriumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Computers_Auditorias_AuditoriumId",
                        column: x => x.AuditoriumId,
                        principalTable: "Auditorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEmployee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubGroupWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSubGroupWork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupWorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGroupWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubGroupWorks_GroupWorks_GroupWorkId",
                        column: x => x.GroupWorkId,
                        principalTable: "GroupWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementsOfWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameElementOfWork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubGroupWorkId = table.Column<int>(type: "int", nullable: false),
                    Norm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementsOfWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementsOfWorks_SubGroupWorks_SubGroupWorkId",
                        column: x => x.SubGroupWorkId,
                        principalTable: "SubGroupWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCompletion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ElementOfWorkId = table.Column<int>(type: "int", nullable: false),
                    CountOfEntities = table.Column<int>(type: "int", nullable: false),
                    TimeSpent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_ElementsOfWorks_ElementOfWorkId",
                        column: x => x.ElementOfWorkId,
                        principalTable: "ElementsOfWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Works_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComputerWork",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "int", nullable: false),
                    WorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerWork", x => new { x.ComputerId, x.WorkId });
                    table.ForeignKey(
                        name: "FK_ComputerWork_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputerWork_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computers_AuditoriumId",
                table: "Computers",
                column: "AuditoriumId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerWork_WorkId",
                table: "ComputerWork",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementsOfWorks_SubGroupWorkId",
                table: "ElementsOfWorks",
                column: "SubGroupWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubGroupWorks_GroupWorkId",
                table: "SubGroupWorks",
                column: "GroupWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_ElementOfWorkId",
                table: "Works",
                column: "ElementOfWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_EmployeeId",
                table: "Works",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerWork");

            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Auditorias");

            migrationBuilder.DropTable(
                name: "ElementsOfWorks");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "SubGroupWorks");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "GroupWorks");
        }
    }
}
