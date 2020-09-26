using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infrastructure.Persistence.Migrations
{
    public partial class AddNewPropertiestoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ACC_CUSTOMERS",
                keyColumn: "ID",
                keyValue: new Guid("988cc910-2246-433b-a382-ae5454a855aa"));

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ACC_CUSTOMERS",
                columns: new[] { "ID", "ACC_CUSTOMER_ADDRESS", "ACC_CUSTOMER_CITY", "ACC_CUSTOMER_COUNTRY", "ACC_CUSTOMER_CRT_DATE", "ACC_CUSTOMER_CRT_BY_USR_ID", "ACC_CUSTOMER_NAME_AR", "ACC_CUSTOMER_NAME_EN", "ACC_CUSTOMER_EMAIL", "ACC_CUSTOMER_FAX_NO", "ACC_CUSTOMER_UPD_DATE", "ACC_CUSTOMER_UPD_BY_USR_ID", "ACC_CUSTOMER_MOBILE_NO1", "ACC_CUSTOMER_MOBILE_NO2", "ACC_CUSTOMER_PHONE_NO", "ACC_CUSTOMER_TAX_NO" },
                values: new object[] { new Guid("6d8cdfa1-aaad-4c13-906d-6ba1d6733594"), "Macca St.", "Amman", "Jordan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "مكتب المدير", "Almodeer Office", null, null, null, null, "0795980824", null, null, "123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ACC_CUSTOMERS",
                keyColumn: "ID",
                keyValue: new Guid("6d8cdfa1-aaad-4c13-906d-6ba1d6733594"));

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "ACC_CUSTOMERS",
                columns: new[] { "ID", "ACC_CUSTOMER_ADDRESS", "ACC_CUSTOMER_CITY", "ACC_CUSTOMER_COUNTRY", "ACC_CUSTOMER_CRT_DATE", "ACC_CUSTOMER_CRT_BY_USR_ID", "ACC_CUSTOMER_NAME_AR", "ACC_CUSTOMER_NAME_EN", "ACC_CUSTOMER_EMAIL", "ACC_CUSTOMER_FAX_NO", "ACC_CUSTOMER_UPD_DATE", "ACC_CUSTOMER_UPD_BY_USR_ID", "ACC_CUSTOMER_MOBILE_NO1", "ACC_CUSTOMER_MOBILE_NO2", "ACC_CUSTOMER_PHONE_NO", "ACC_CUSTOMER_TAX_NO" },
                values: new object[] { new Guid("988cc910-2246-433b-a382-ae5454a855aa"), "Macca St.", "Amman", "Jordan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "مكتب المدير", "Almodeer Office", null, null, null, null, "0795980824", null, null, "123456" });
        }
    }
}
