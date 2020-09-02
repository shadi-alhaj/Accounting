using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infrastructure.Persistence.Migrations
{
    public partial class AddDetailAccountEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ACC_CUSTOMERS",
                keyColumn: "ID",
                keyValue: new Guid("1c16ab2f-a0e2-4878-aad8-6cb7771cb61e"));

            migrationBuilder.CreateTable(
                name: "ACC_DETAIL_ACCOUNTS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ACC_DETAIL_ACCOUNT_CRT_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_DETAIL_ACCOUNT_CRT_DATE = table.Column<DateTime>(nullable: false),
                    ACC_DETAIL_ACCOUNT_UPD_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_DETAIL_ACCOUNT_UPD_DATE = table.Column<DateTime>(nullable: true),
                    ACC_DETAIL_ACCOUNT_ID_BY_CUSTOMER = table.Column<int>(maxLength: 250, nullable: false),
                    ACC_DETAIL_ACCOUNT_NAME_AR = table.Column<string>(maxLength: 250, nullable: false),
                    ACC_DETAIL_ACCOUNT_NAME_EN = table.Column<string>(maxLength: 250, nullable: true),
                    ACC_DETAIL_ACCOUNT_CUSTOMER_ID = table.Column<Guid>(nullable: false),
                    ACC_DETAIL_ACCOUNT_GL_ID = table.Column<Guid>(nullable: false),
                    ACC_DETAIL_ACCOUNT_MAIN_ACCOUNT_ID = table.Column<Guid>(nullable: false),
                    ACC_DETAIL_ACCOUNT_TOTAL_ACCOUNT_ID = table.Column<Guid>(nullable: false),
                    ACC_DETAIL_ACCOUNT_IS_ACTIVE = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACC_DETAIL_ACCOUNTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACC_DETAIL_ACCOUNTS_ACC_CUSTOMERS_ACC_DETAIL_ACCOUNT_CUSTOMER_ID",
                        column: x => x.ACC_DETAIL_ACCOUNT_CUSTOMER_ID,
                        principalTable: "ACC_CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACC_DETAIL_ACCOUNTS_ACC_GENERAL_LEDGERS_ACC_DETAIL_ACCOUNT_GL_ID",
                        column: x => x.ACC_DETAIL_ACCOUNT_GL_ID,
                        principalTable: "ACC_GENERAL_LEDGERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACC_DETAIL_ACCOUNTS_ACC_MAIN_ACCOUNTS_ACC_DETAIL_ACCOUNT_MAIN_ACCOUNT_ID",
                        column: x => x.ACC_DETAIL_ACCOUNT_MAIN_ACCOUNT_ID,
                        principalTable: "ACC_MAIN_ACCOUNTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACC_DETAIL_ACCOUNTS_ACC_TOTAL_ACCOUNTS_ACC_DETAIL_ACCOUNT_TOTAL_ACCOUNT_ID",
                        column: x => x.ACC_DETAIL_ACCOUNT_TOTAL_ACCOUNT_ID,
                        principalTable: "ACC_TOTAL_ACCOUNTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ACC_CUSTOMERS",
                columns: new[] { "ID", "ACC_CUSTOMER_ADDRESS", "ACC_CUSTOMER_CITY", "ACC_CUSTOMER_COUNTRY", "ACC_CUSTOMER_CRT_DATE", "ACC_CUSTOMER_CRT_BY_USR_ID", "ACC_CUSTOMER_NAME_AR", "ACC_CUSTOMER_NAME_EN", "ACC_CUSTOMER_EMAIL", "ACC_CUSTOMER_FAX_NO", "ACC_CUSTOMER_UPD_DATE", "ACC_CUSTOMER_UPD_BY_USR_ID", "ACC_CUSTOMER_MOBILE_NO1", "ACC_CUSTOMER_MOBILE_NO2", "ACC_CUSTOMER_PHONE_NO", "ACC_CUSTOMER_TAX_NO" },
                values: new object[] { new Guid("c0f29a2c-97f7-4b66-970c-0c666b99050f"), "Macca St.", "Amman", "Jordan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "مكتب المدير", "Almodeer Office", null, null, null, null, "0795980824", null, null, "123456" });

            migrationBuilder.CreateIndex(
                name: "IX_ACC_DETAIL_ACCOUNTS_ACC_DETAIL_ACCOUNT_CUSTOMER_ID",
                table: "ACC_DETAIL_ACCOUNTS",
                column: "ACC_DETAIL_ACCOUNT_CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_DETAIL_ACCOUNTS_ACC_DETAIL_ACCOUNT_GL_ID",
                table: "ACC_DETAIL_ACCOUNTS",
                column: "ACC_DETAIL_ACCOUNT_GL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_DETAIL_ACCOUNTS_ACC_DETAIL_ACCOUNT_MAIN_ACCOUNT_ID",
                table: "ACC_DETAIL_ACCOUNTS",
                column: "ACC_DETAIL_ACCOUNT_MAIN_ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_DETAIL_ACCOUNTS_ACC_DETAIL_ACCOUNT_TOTAL_ACCOUNT_ID",
                table: "ACC_DETAIL_ACCOUNTS",
                column: "ACC_DETAIL_ACCOUNT_TOTAL_ACCOUNT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACC_DETAIL_ACCOUNTS");

            migrationBuilder.DeleteData(
                table: "ACC_CUSTOMERS",
                keyColumn: "ID",
                keyValue: new Guid("c0f29a2c-97f7-4b66-970c-0c666b99050f"));

            migrationBuilder.InsertData(
                table: "ACC_CUSTOMERS",
                columns: new[] { "ID", "ACC_CUSTOMER_ADDRESS", "ACC_CUSTOMER_CITY", "ACC_CUSTOMER_COUNTRY", "ACC_CUSTOMER_CRT_DATE", "ACC_CUSTOMER_CRT_BY_USR_ID", "ACC_CUSTOMER_NAME_AR", "ACC_CUSTOMER_NAME_EN", "ACC_CUSTOMER_EMAIL", "ACC_CUSTOMER_FAX_NO", "ACC_CUSTOMER_UPD_DATE", "ACC_CUSTOMER_UPD_BY_USR_ID", "ACC_CUSTOMER_MOBILE_NO1", "ACC_CUSTOMER_MOBILE_NO2", "ACC_CUSTOMER_PHONE_NO", "ACC_CUSTOMER_TAX_NO" },
                values: new object[] { new Guid("1c16ab2f-a0e2-4878-aad8-6cb7771cb61e"), "Macca St.", "Amman", "Jordan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "مكتب المدير", "Almodeer Office", null, null, null, null, "0795980824", null, null, "123456" });
        }
    }
}
