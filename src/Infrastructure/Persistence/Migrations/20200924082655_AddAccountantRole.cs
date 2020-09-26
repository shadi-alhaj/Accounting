using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infrastructure.Persistence.Migrations
{
    public partial class AddAccountantRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ACC_CUSTOMERS",
                keyColumn: "ID",
                keyValue: new Guid("b92511fe-9d92-4146-abea-a318dee8c6d8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9776ae5-22d8-472c-8246-4f50f67469dd");

            migrationBuilder.InsertData(
                table: "ACC_CUSTOMERS",
                columns: new[] { "ID", "ACC_CUSTOMER_ADDRESS", "ACC_CUSTOMER_CITY", "ACC_CUSTOMER_COUNTRY", "ACC_CUSTOMER_CRT_DATE", "ACC_CUSTOMER_CRT_BY_USR_ID", "ACC_CUSTOMER_NAME_AR", "ACC_CUSTOMER_NAME_EN", "ACC_CUSTOMER_EMAIL", "ACC_CUSTOMER_FAX_NO", "ACC_CUSTOMER_UPD_DATE", "ACC_CUSTOMER_UPD_BY_USR_ID", "ACC_CUSTOMER_MOBILE_NO1", "ACC_CUSTOMER_MOBILE_NO2", "ACC_CUSTOMER_PHONE_NO", "ACC_CUSTOMER_TAX_NO" },
                values: new object[] { new Guid("0af666a4-ab63-4c42-b2c6-9e23193a4ced"), "Macca St.", "Amman", "Jordan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "مكتب المدير", "Almodeer Office", null, null, null, null, "0795980824", null, null, "123456" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41643a25-f95b-4707-9dac-d3689bc7d7fc", "6648ab0f-a9e2-422a-b70a-59eee6456705", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c468e8a7-cd7a-4f43-9a7b-952860fc64e2", "9e336dc5-ab4f-4fcd-8dc2-9cb6310325d4", "Accountant", "ACCOUNTANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ACC_CUSTOMERS",
                keyColumn: "ID",
                keyValue: new Guid("0af666a4-ab63-4c42-b2c6-9e23193a4ced"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41643a25-f95b-4707-9dac-d3689bc7d7fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c468e8a7-cd7a-4f43-9a7b-952860fc64e2");

            migrationBuilder.InsertData(
                table: "ACC_CUSTOMERS",
                columns: new[] { "ID", "ACC_CUSTOMER_ADDRESS", "ACC_CUSTOMER_CITY", "ACC_CUSTOMER_COUNTRY", "ACC_CUSTOMER_CRT_DATE", "ACC_CUSTOMER_CRT_BY_USR_ID", "ACC_CUSTOMER_NAME_AR", "ACC_CUSTOMER_NAME_EN", "ACC_CUSTOMER_EMAIL", "ACC_CUSTOMER_FAX_NO", "ACC_CUSTOMER_UPD_DATE", "ACC_CUSTOMER_UPD_BY_USR_ID", "ACC_CUSTOMER_MOBILE_NO1", "ACC_CUSTOMER_MOBILE_NO2", "ACC_CUSTOMER_PHONE_NO", "ACC_CUSTOMER_TAX_NO" },
                values: new object[] { new Guid("b92511fe-9d92-4146-abea-a318dee8c6d8"), "Macca St.", "Amman", "Jordan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "مكتب المدير", "Almodeer Office", null, null, null, null, "0795980824", null, null, "123456" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9776ae5-22d8-472c-8246-4f50f67469dd", "debbb28f-be95-4ceb-9a97-59dffcc537d7", "Admin", "ADMIN" });
        }
    }
}
