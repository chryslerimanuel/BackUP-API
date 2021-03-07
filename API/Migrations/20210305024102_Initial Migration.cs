using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_M_Person",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Person", x => x.NIK);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_University",
                columns: table => new
                {
                    UniversityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_University", x => x.UniversityID);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_Account",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Account", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_Tb_M_Account_Tb_M_Person_NIK",
                        column: x => x.NIK,
                        principalTable: "Tb_M_Person",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_Education",
                columns: table => new
                {
                    EducationID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EducationDegree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationGPA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Education", x => x.EducationID);
                    table.ForeignKey(
                        name: "FK_Tb_M_Education_Tb_M_University_UniversityID",
                        column: x => x.UniversityID,
                        principalTable: "Tb_M_University",
                        principalColumn: "UniversityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_T_AccountRole",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_T_AccountRole", x => new { x.NIK, x.RoleID });
                    table.ForeignKey(
                        name: "FK_Tb_T_AccountRole_Tb_M_Account_NIK",
                        column: x => x.NIK,
                        principalTable: "Tb_M_Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_T_AccountRole_Tb_M_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Tb_M_Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_T_Profiling",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EducationID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_T_Profiling", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_Tb_T_Profiling_Tb_M_Account_NIK",
                        column: x => x.NIK,
                        principalTable: "Tb_M_Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_T_Profiling_Tb_M_Education_EducationID",
                        column: x => x.EducationID,
                        principalTable: "Tb_M_Education",
                        principalColumn: "EducationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_Education_UniversityID",
                table: "Tb_M_Education",
                column: "UniversityID");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_AccountRole_RoleID",
                table: "Tb_T_AccountRole",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_Profiling_EducationID",
                table: "Tb_T_Profiling",
                column: "EducationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_T_AccountRole");

            migrationBuilder.DropTable(
                name: "Tb_T_Profiling");

            migrationBuilder.DropTable(
                name: "Tb_M_Role");

            migrationBuilder.DropTable(
                name: "Tb_M_Account");

            migrationBuilder.DropTable(
                name: "Tb_M_Education");

            migrationBuilder.DropTable(
                name: "Tb_M_Person");

            migrationBuilder.DropTable(
                name: "Tb_M_University");
        }
    }
}
