using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewDiary.Migrations
{
    public partial class NewDiaryUpdate_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Auditorias_IdAuditorium",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementsOfWorks_SubGroupWorks_IdSubGroupWork",
                table: "ElementsOfWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_IdDepartment",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_SubGroupWorks_GroupWorks_IdGroupWork",
                table: "SubGroupWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Computers_IdComputer",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_DiaryEntries_DiaryEntry",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_GroupWorks_IdGroupWork",
                table: "Works");

            migrationBuilder.DropTable(
                name: "DiaryEntries");

            migrationBuilder.DropIndex(
                name: "IX_Works_DiaryEntry",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "DiaryEntry",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Works");

            migrationBuilder.RenameColumn(
                name: "IdGroupWork",
                table: "Works",
                newName: "GroupOfThisWorkIdGroupWork");

            migrationBuilder.RenameColumn(
                name: "IdComputer",
                table: "Works",
                newName: "EmployeeIdEmployee");

            migrationBuilder.RenameIndex(
                name: "IX_Works_IdGroupWork",
                table: "Works",
                newName: "IX_Works_GroupOfThisWorkIdGroupWork");

            migrationBuilder.RenameIndex(
                name: "IX_Works_IdComputer",
                table: "Works",
                newName: "IX_Works_EmployeeIdEmployee");

            migrationBuilder.RenameColumn(
                name: "IdGroupWork",
                table: "SubGroupWorks",
                newName: "GroupWorkIdGroupWork");

            migrationBuilder.RenameIndex(
                name: "IX_SubGroupWorks_IdGroupWork",
                table: "SubGroupWorks",
                newName: "IX_SubGroupWorks_GroupWorkIdGroupWork");

            migrationBuilder.RenameColumn(
                name: "IdDepartment",
                table: "Employees",
                newName: "DepartmentIdDepartment");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_IdDepartment",
                table: "Employees",
                newName: "IX_Employees_DepartmentIdDepartment");

            migrationBuilder.RenameColumn(
                name: "IdSubGroupWork",
                table: "ElementsOfWorks",
                newName: "SubGroupWorkIdSubGroupWork");

            migrationBuilder.RenameIndex(
                name: "IX_ElementsOfWorks_IdSubGroupWork",
                table: "ElementsOfWorks",
                newName: "IX_ElementsOfWorks_SubGroupWorkIdSubGroupWork");

            migrationBuilder.RenameColumn(
                name: "IdAuditorium",
                table: "Computers",
                newName: "AuditoriumIdAuditorium");

            migrationBuilder.RenameIndex(
                name: "IX_Computers_IdAuditorium",
                table: "Computers",
                newName: "IX_Computers_AuditoriumIdAuditorium");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfInput",
                table: "Works",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "Computers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ComputerWork",
                columns: table => new
                {
                    ComputerIdComputer = table.Column<int>(type: "int", nullable: false),
                    WorkIdWork = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerWork", x => new { x.ComputerIdComputer, x.WorkIdWork });
                    table.ForeignKey(
                        name: "FK_ComputerWork_Computers_ComputerIdComputer",
                        column: x => x.ComputerIdComputer,
                        principalTable: "Computers",
                        principalColumn: "IdComputer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputerWork_Works_WorkIdWork",
                        column: x => x.WorkIdWork,
                        principalTable: "Works",
                        principalColumn: "IdWork",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerWork_WorkIdWork",
                table: "ComputerWork",
                column: "WorkIdWork");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Auditorias_AuditoriumIdAuditorium",
                table: "Computers",
                column: "AuditoriumIdAuditorium",
                principalTable: "Auditorias",
                principalColumn: "IdAuditorium",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementsOfWorks_SubGroupWorks_SubGroupWorkIdSubGroupWork",
                table: "ElementsOfWorks",
                column: "SubGroupWorkIdSubGroupWork",
                principalTable: "SubGroupWorks",
                principalColumn: "IdSubGroupWork",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentIdDepartment",
                table: "Employees",
                column: "DepartmentIdDepartment",
                principalTable: "Departments",
                principalColumn: "IdDepartment",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubGroupWorks_GroupWorks_GroupWorkIdGroupWork",
                table: "SubGroupWorks",
                column: "GroupWorkIdGroupWork",
                principalTable: "GroupWorks",
                principalColumn: "IdGroupWork",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Employees_EmployeeIdEmployee",
                table: "Works",
                column: "EmployeeIdEmployee",
                principalTable: "Employees",
                principalColumn: "IdEmployee",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_GroupWorks_GroupOfThisWorkIdGroupWork",
                table: "Works",
                column: "GroupOfThisWorkIdGroupWork",
                principalTable: "GroupWorks",
                principalColumn: "IdGroupWork",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Auditorias_AuditoriumIdAuditorium",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementsOfWorks_SubGroupWorks_SubGroupWorkIdSubGroupWork",
                table: "ElementsOfWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentIdDepartment",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_SubGroupWorks_GroupWorks_GroupWorkIdGroupWork",
                table: "SubGroupWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Employees_EmployeeIdEmployee",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_GroupWorks_GroupOfThisWorkIdGroupWork",
                table: "Works");

            migrationBuilder.DropTable(
                name: "ComputerWork");

            migrationBuilder.DropColumn(
                name: "DateOfInput",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "Computers");

            migrationBuilder.RenameColumn(
                name: "GroupOfThisWorkIdGroupWork",
                table: "Works",
                newName: "IdGroupWork");

            migrationBuilder.RenameColumn(
                name: "EmployeeIdEmployee",
                table: "Works",
                newName: "IdComputer");

            migrationBuilder.RenameIndex(
                name: "IX_Works_GroupOfThisWorkIdGroupWork",
                table: "Works",
                newName: "IX_Works_IdGroupWork");

            migrationBuilder.RenameIndex(
                name: "IX_Works_EmployeeIdEmployee",
                table: "Works",
                newName: "IX_Works_IdComputer");

            migrationBuilder.RenameColumn(
                name: "GroupWorkIdGroupWork",
                table: "SubGroupWorks",
                newName: "IdGroupWork");

            migrationBuilder.RenameIndex(
                name: "IX_SubGroupWorks_GroupWorkIdGroupWork",
                table: "SubGroupWorks",
                newName: "IX_SubGroupWorks_IdGroupWork");

            migrationBuilder.RenameColumn(
                name: "DepartmentIdDepartment",
                table: "Employees",
                newName: "IdDepartment");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentIdDepartment",
                table: "Employees",
                newName: "IX_Employees_IdDepartment");

            migrationBuilder.RenameColumn(
                name: "SubGroupWorkIdSubGroupWork",
                table: "ElementsOfWorks",
                newName: "IdSubGroupWork");

            migrationBuilder.RenameIndex(
                name: "IX_ElementsOfWorks_SubGroupWorkIdSubGroupWork",
                table: "ElementsOfWorks",
                newName: "IX_ElementsOfWorks_IdSubGroupWork");

            migrationBuilder.RenameColumn(
                name: "AuditoriumIdAuditorium",
                table: "Computers",
                newName: "IdAuditorium");

            migrationBuilder.RenameIndex(
                name: "IX_Computers_AuditoriumIdAuditorium",
                table: "Computers",
                newName: "IX_Computers_IdAuditorium");

            migrationBuilder.AddColumn<int>(
                name: "DiaryEntry",
                table: "Works",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Works",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DiaryEntries",
                columns: table => new
                {
                    IdDiaryEntry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmployee = table.Column<int>(type: "int", nullable: false),
                    IdWork = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryEntries", x => x.IdDiaryEntry);
                    table.ForeignKey(
                        name: "FK_DiaryEntries_Employees_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employees",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Works_DiaryEntry",
                table: "Works",
                column: "DiaryEntry",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiaryEntries_IdEmployee",
                table: "DiaryEntries",
                column: "IdEmployee");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Auditorias_IdAuditorium",
                table: "Computers",
                column: "IdAuditorium",
                principalTable: "Auditorias",
                principalColumn: "IdAuditorium",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementsOfWorks_SubGroupWorks_IdSubGroupWork",
                table: "ElementsOfWorks",
                column: "IdSubGroupWork",
                principalTable: "SubGroupWorks",
                principalColumn: "IdSubGroupWork",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_IdDepartment",
                table: "Employees",
                column: "IdDepartment",
                principalTable: "Departments",
                principalColumn: "IdDepartment",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubGroupWorks_GroupWorks_IdGroupWork",
                table: "SubGroupWorks",
                column: "IdGroupWork",
                principalTable: "GroupWorks",
                principalColumn: "IdGroupWork",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Computers_IdComputer",
                table: "Works",
                column: "IdComputer",
                principalTable: "Computers",
                principalColumn: "IdComputer",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_DiaryEntries_DiaryEntry",
                table: "Works",
                column: "DiaryEntry",
                principalTable: "DiaryEntries",
                principalColumn: "IdDiaryEntry",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_GroupWorks_IdGroupWork",
                table: "Works",
                column: "IdGroupWork",
                principalTable: "GroupWorks",
                principalColumn: "IdGroupWork",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
