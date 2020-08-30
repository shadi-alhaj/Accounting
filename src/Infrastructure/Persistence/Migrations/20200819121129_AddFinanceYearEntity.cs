using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infrastructure.Persistence.Migrations
{
    public partial class AddFinanceYearEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACC_FINANCE_YEARS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ACC_FINANCE_YEAR_CRT_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_FINANCE_YEAR_CRT_DATE = table.Column<DateTime>(nullable: false),
                    ACC_FINANCE_YEAR_UPD_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_FINANCE_YEAR_UPD_DATE = table.Column<DateTime>(nullable: true),
                    ACC_FINANCE_YEAR_YEAR = table.Column<int>(nullable: false),
                    ACC_FINANCE_YEAR_IS_ACTIVE = table.Column<bool>(nullable: false, defaultValue: true),
                    ACC_FINANCE_YEAR_CUSTOMER_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACC_FINANCE_YEARS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACC_FINANCE_YEARS_ACC_CUSTOMERS_ACC_FINANCE_YEAR_CUSTOMER_ID",
                        column: x => x.ACC_FINANCE_YEAR_CUSTOMER_ID,
                        principalTable: "ACC_CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACC_FINANCE_YEARS_ACC_FINANCE_YEAR_CUSTOMER_ID",
                table: "ACC_FINANCE_YEARS",
                column: "ACC_FINANCE_YEAR_CUSTOMER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACC_FINANCE_YEARS");
        }
    }
}
