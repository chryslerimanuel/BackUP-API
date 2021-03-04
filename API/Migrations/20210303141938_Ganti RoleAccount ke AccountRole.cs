using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class GantiRoleAccountkeAccountRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_M_RoleAccount");

            migrationBuilder.CreateTable(
                name: "Tb_M_AccountRole",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "int", nullable: false),
                    Account_NIK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_AccountRole", x => new { x.Role_Id, x.Account_NIK });
                    table.ForeignKey(
                        name: "FK_Tb_M_AccountRole_Tb_M_Account_Account_NIK",
                        column: x => x.Account_NIK,
                        principalTable: "Tb_M_Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_M_AccountRole_Tb_M_Role_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Tb_M_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_AccountRole_Account_NIK",
                table: "Tb_M_AccountRole",
                column: "Account_NIK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_M_AccountRole");

            migrationBuilder.CreateTable(
                name: "Tb_M_RoleAccount",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "int", nullable: false),
                    Account_NIK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_RoleAccount", x => new { x.Role_Id, x.Account_NIK });
                    table.ForeignKey(
                        name: "FK_Tb_M_RoleAccount_Tb_M_Account_Account_NIK",
                        column: x => x.Account_NIK,
                        principalTable: "Tb_M_Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_M_RoleAccount_Tb_M_Role_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Tb_M_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_RoleAccount_Account_NIK",
                table: "Tb_M_RoleAccount",
                column: "Account_NIK");
        }
    }
}
