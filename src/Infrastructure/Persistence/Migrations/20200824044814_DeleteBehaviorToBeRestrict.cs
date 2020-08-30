using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infrastructure.Persistence.Migrations
{
    public partial class DeleteBehaviorToBeRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ACC_BONDS_ACC_CUSTOMERS_ACC_BOND_CUSTOMER_ID",
                table: "ACC_BONDS");

            migrationBuilder.DropForeignKey(
                name: "FK_ACC_FINANCE_YEARS_ACC_CUSTOMERS_ACC_FINANCE_YEAR_CUSTOMER_ID",
                table: "ACC_FINANCE_YEARS");

            migrationBuilder.AddColumn<bool>(
                name: "ACC_BOND_IS_ACTIVE",
                table: "ACC_BONDS",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ACC_BONDS_ACC_CUSTOMERS_ACC_BOND_CUSTOMER_ID",
                table: "ACC_BONDS",
                column: "ACC_BOND_CUSTOMER_ID",
                principalTable: "ACC_CUSTOMERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ACC_FINANCE_YEARS_ACC_CUSTOMERS_ACC_FINANCE_YEAR_CUSTOMER_ID",
                table: "ACC_FINANCE_YEARS",
                column: "ACC_FINANCE_YEAR_CUSTOMER_ID",
                principalTable: "ACC_CUSTOMERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ACC_BONDS_ACC_CUSTOMERS_ACC_BOND_CUSTOMER_ID",
                table: "ACC_BONDS");

            migrationBuilder.DropForeignKey(
                name: "FK_ACC_FINANCE_YEARS_ACC_CUSTOMERS_ACC_FINANCE_YEAR_CUSTOMER_ID",
                table: "ACC_FINANCE_YEARS");

            migrationBuilder.DropColumn(
                name: "ACC_BOND_IS_ACTIVE",
                table: "ACC_BONDS");

            migrationBuilder.AddForeignKey(
                name: "FK_ACC_BONDS_ACC_CUSTOMERS_ACC_BOND_CUSTOMER_ID",
                table: "ACC_BONDS",
                column: "ACC_BOND_CUSTOMER_ID",
                principalTable: "ACC_CUSTOMERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ACC_FINANCE_YEARS_ACC_CUSTOMERS_ACC_FINANCE_YEAR_CUSTOMER_ID",
                table: "ACC_FINANCE_YEARS",
                column: "ACC_FINANCE_YEAR_CUSTOMER_ID",
                principalTable: "ACC_CUSTOMERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
