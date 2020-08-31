using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infrastructure.Persistence.Migrations
{
    public partial class CustomerSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ACC_CUSTOMERS",
                columns: new[] { "ID", "ACC_CUSTOMER_ADDRESS", "ACC_CUSTOMER_CITY", "ACC_CUSTOMER_COUNTRY", "ACC_CUSTOMER_CRT_DATE", "ACC_CUSTOMER_CRT_BY_USR_ID", "ACC_CUSTOMER_NAME_AR", "ACC_CUSTOMER_NAME_EN", "ACC_CUSTOMER_EMAIL", "ACC_CUSTOMER_FAX_NO", "ACC_CUSTOMER_UPD_DATE", "ACC_CUSTOMER_UPD_BY_USR_ID", "ACC_CUSTOMER_MOBILE_NO1", "ACC_CUSTOMER_MOBILE_NO2", "ACC_CUSTOMER_PHONE_NO", "ACC_CUSTOMER_TAX_NO" },
                values: new object[] { new Guid("1c16ab2f-a0e2-4878-aad8-6cb7771cb61e"), "Macca St.", "Amman", "Jordan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "مكتب المدير", "Almodeer Office", null, null, null, null, "0795980824", null, null, "123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ACC_CUSTOMERS",
                keyColumn: "ID",
                keyValue: new Guid("1c16ab2f-a0e2-4878-aad8-6cb7771cb61e"));
        }
    }
}
