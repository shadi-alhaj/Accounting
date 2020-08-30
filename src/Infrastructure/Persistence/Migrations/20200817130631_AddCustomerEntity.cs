using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infrastructure.Persistence.Migrations
{
    public partial class AddCustomerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACC_CUSTOMERS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ACC_CUSTOMER_CRT_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_CUSTOMER_CRT_DATE = table.Column<DateTime>(nullable: false),
                    ACC_CUSTOMER_UPD_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_CUSTOMER_UPD_DATE = table.Column<DateTime>(nullable: true),
                    ACC_CUSTOMER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACC_CUSTOMER_NAME_AR = table.Column<string>(maxLength: 250, nullable: false),
                    ACC_CUSTOMER_NAME_EN = table.Column<string>(maxLength: 250, nullable: true),
                    ACC_CUSTOMER_TAX_NO = table.Column<string>(maxLength: 20, nullable: true),
                    ACC_CUSTOMER_FAX_NO = table.Column<string>(maxLength: 20, nullable: true),
                    ACC_CUSTOMER_PHONE_NO = table.Column<string>(maxLength: 20, nullable: true),
                    ACC_CUSTOMER_MOBILE_NO1 = table.Column<string>(maxLength: 14, nullable: true),
                    ACC_CUSTOMER_MOBILE_NO2 = table.Column<string>(maxLength: 14, nullable: true),
                    ACC_CUSTOMER_COUNTRY = table.Column<string>(maxLength: 100, nullable: true),
                    ACC_CUSTOMER_CITY = table.Column<string>(maxLength: 100, nullable: true),
                    ACC_CUSTOMER_ADDRESS = table.Column<string>(maxLength: 250, nullable: true),
                    ACC_CUSTOMER_EMAIL = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACC_CUSTOMERS", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACC_CUSTOMERS");
        }
    }
}
