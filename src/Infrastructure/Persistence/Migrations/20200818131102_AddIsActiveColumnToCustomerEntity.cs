using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infrastructure.Persistence.Migrations
{
    public partial class AddIsActiveColumnToCustomerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ACC_CUSTOMER_IS_ACTIVE",
                table: "ACC_CUSTOMERS",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACC_CUSTOMER_IS_ACTIVE",
                table: "ACC_CUSTOMERS");
        }
    }
}
