using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infrastructure.Persistence.Migrations
{
    public partial class AddBondEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACC_BONDS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ACC_BOND_CRT_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_BOND_CRT_DATE = table.Column<DateTime>(nullable: false),
                    ACC_BOND_UPD_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_BOND_UPD_DATE = table.Column<DateTime>(nullable: true),
                    ACC_BOND_USER_ID = table.Column<int>(nullable: false),
                    ACC_BOND_INTIAL_SNO = table.Column<int>(nullable: false),
                    ACC_BOND_NAME_AR = table.Column<string>(maxLength: 250, nullable: false),
                    ACC_BOND_NAME_EN = table.Column<string>(maxLength: 250, nullable: true),
                    ACC_BOND_CUSTOMER_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACC_BONDS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACC_BONDS_ACC_CUSTOMERS_ACC_BOND_CUSTOMER_ID",
                        column: x => x.ACC_BOND_CUSTOMER_ID,
                        principalTable: "ACC_CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACC_BONDS_ACC_BOND_CUSTOMER_ID",
                table: "ACC_BONDS",
                column: "ACC_BOND_CUSTOMER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACC_BONDS");
        }
    }
}
