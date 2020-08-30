using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infrastructure.Persistence.Migrations
{
    public partial class AddTotalEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACC_TOTAL_ACCOUNTS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ACC_TOTAL_ACCOUNT_CRT_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_TOTAL_ACCOUNT_CRT_DATE = table.Column<DateTime>(nullable: false),
                    ACC_TOTAL_ACCOUNT_UPD_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_TOTAL_ACCOUNT_UPD_DATE = table.Column<DateTime>(nullable: true),
                    ACC_TOTAL_ACCOUNT_ID_BY_CUSTOMER = table.Column<int>(maxLength: 250, nullable: false),
                    ACC_TOTAL_ACCOUNT_NAME_AR = table.Column<string>(maxLength: 250, nullable: false),
                    ACC_TOTAL_ACCOUNT_NAME_EN = table.Column<string>(maxLength: 250, nullable: true),
                    ACC_TOTAL_ACCOUNT_CUSTOMER_ID = table.Column<Guid>(nullable: false),
                    ACC_TOTAL_ACCOUNT_GL_ID = table.Column<Guid>(nullable: false),
                    ACC_TOTAL_ACCOUNT_MAIN_ACCOUNT_ID = table.Column<Guid>(nullable: false),
                    ACC_TOTAL_ACCOUNT_IS_CLOSE = table.Column<bool>(nullable: false),
                    ACC_TOTAL_ACCOUNT_IS_ACTIVE = table.Column<bool>(nullable: false, defaultValue: true),
                    GeneralLedgerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACC_TOTAL_ACCOUNTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACC_TOTAL_ACCOUNTS_ACC_CUSTOMERS_ACC_TOTAL_ACCOUNT_CUSTOMER_ID",
                        column: x => x.ACC_TOTAL_ACCOUNT_CUSTOMER_ID,
                        principalTable: "ACC_CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACC_TOTAL_ACCOUNTS_ACC_GENERAL_LEDGERS_GeneralLedgerId",
                        column: x => x.GeneralLedgerId,
                        principalTable: "ACC_GENERAL_LEDGERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACC_TOTAL_ACCOUNTS_ACC_MAIN_ACCOUNTS_ACC_TOTAL_ACCOUNT_MAIN_ACCOUNT_ID",
                        column: x => x.ACC_TOTAL_ACCOUNT_MAIN_ACCOUNT_ID,
                        principalTable: "ACC_MAIN_ACCOUNTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACC_TOTAL_ACCOUNTS_ACC_TOTAL_ACCOUNT_CUSTOMER_ID",
                table: "ACC_TOTAL_ACCOUNTS",
                column: "ACC_TOTAL_ACCOUNT_CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_TOTAL_ACCOUNTS_GeneralLedgerId",
                table: "ACC_TOTAL_ACCOUNTS",
                column: "GeneralLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_TOTAL_ACCOUNTS_ACC_TOTAL_ACCOUNT_MAIN_ACCOUNT_ID",
                table: "ACC_TOTAL_ACCOUNTS",
                column: "ACC_TOTAL_ACCOUNT_MAIN_ACCOUNT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACC_TOTAL_ACCOUNTS");
        }
    }
}
