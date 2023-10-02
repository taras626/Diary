using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewDiary.Migrations
{
    public partial class NewDiary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auditorias",
                columns: table => new
                {
                    IdAuditorium = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.IdAuditorium);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    IdDepartment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDepartment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.IdDepartment);
                });

            migrationBuilder.CreateTable(
                name: "GroupWorks",
                columns: table => new
                {
                    IdGroupWork = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupWorks", x => x.IdGroupWork);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    IdComputer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAuditorium = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.IdComputer);
                    table.ForeignKey(
                        name: "FK_Computers_Auditorias_IdAuditorium",
                        column: x => x.IdAuditorium,
                        principalTable: "Auditorias",
                        principalColumn: "IdAuditorium",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDepartment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_IdDepartment",
                        column: x => x.IdDepartment,
                        principalTable: "Departments",
                        principalColumn: "IdDepartment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubGroupWorks",
                columns: table => new
                {
                    IdSubGroupWork = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdGroupWork = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGroupWorks", x => x.IdSubGroupWork);
                    table.ForeignKey(
                        name: "FK_SubGroupWorks_GroupWorks_IdGroupWork",
                        column: x => x.IdGroupWork,
                        principalTable: "GroupWorks",
                        principalColumn: "IdGroupWork",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "ElementsOfWorks",
                columns: table => new
                {
                    IdElementOfWork = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSubGroupWork = table.Column<int>(type: "int", nullable: false),
                    Norm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementsOfWorks", x => x.IdElementOfWork);
                    table.ForeignKey(
                        name: "FK_ElementsOfWorks_SubGroupWorks_IdSubGroupWork",
                        column: x => x.IdSubGroupWork,
                        principalTable: "SubGroupWorks",
                        principalColumn: "IdSubGroupWork",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    IdWork = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaryEntry = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCompletion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdGroupWork = table.Column<int>(type: "int", nullable: false),
                    CountOfEntities = table.Column<int>(type: "int", nullable: false),
                    TimeSpent = table.Column<int>(type: "int", nullable: false),
                    IdComputer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.IdWork);
                    table.ForeignKey(
                        name: "FK_Works_Computers_IdComputer",
                        column: x => x.IdComputer,
                        principalTable: "Computers",
                        principalColumn: "IdComputer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Works_DiaryEntries_DiaryEntry",
                        column: x => x.DiaryEntry,
                        principalTable: "DiaryEntries",
                        principalColumn: "IdDiaryEntry",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Works_GroupWorks_IdGroupWork",
                        column: x => x.IdGroupWork,
                        principalTable: "GroupWorks",
                        principalColumn: "IdGroupWork",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computers_IdAuditorium",
                table: "Computers",
                column: "IdAuditorium");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryEntries_IdEmployee",
                table: "DiaryEntries",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_ElementsOfWorks_IdSubGroupWork",
                table: "ElementsOfWorks",
                column: "IdSubGroupWork");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdDepartment",
                table: "Employees",
                column: "IdDepartment");

            migrationBuilder.CreateIndex(
                name: "IX_SubGroupWorks_IdGroupWork",
                table: "SubGroupWorks",
                column: "IdGroupWork");

            migrationBuilder.CreateIndex(
                name: "IX_Works_DiaryEntry",
                table: "Works",
                column: "DiaryEntry",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Works_IdGroupWork",
                table: "Works",
                column: "IdGroupWork");

            migrationBuilder.CreateIndex(
                name: "IX_Works_IdComputer",
                table: "Works",
                column: "IdComputer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementsOfWorks");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "SubGroupWorks");

            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "DiaryEntries");

            migrationBuilder.DropTable(
                name: "GroupWorks");

            migrationBuilder.DropTable(
                name: "Auditorias");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
