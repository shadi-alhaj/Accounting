using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infrastructure.Persistence.Migrations
{
    public partial class AddDailyTransactionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ACC_DETAIL_ACCOUNTS_ACC_TOTAL_ACCOUNTS_ACC_DETAIL_ACCOUNT_TOTAL_ACCOUNT_ID",
                table: "ACC_DETAIL_ACCOUNTS");

            migrationBuilder.DeleteData(
                table: "ACC_CUSTOMERS",
                keyColumn: "ID",
                keyValue: new Guid("c0f29a2c-97f7-4b66-970c-0c666b99050f"));

            migrationBuilder.CreateTable(
                name: "ACC_DAILY_TRANSACTIONS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ACC_DAILY_TRANSACTION_CRT_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_DAILY_TRANSACTION_CRT_DATE = table.Column<DateTime>(nullable: false),
                    ACC_DAILY_TRANSACTION_UPD_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_DAILY_TRANSACTION_UPD_DATE = table.Column<DateTime>(nullable: true),
                    ACC_DAILY_TRANSACTION_ID_BY_CUSTOMER = table.Column<int>(nullable: false),
                    ACC_DAILY_TRANSACTION_BOND_SNO = table.Column<int>(nullable: false),
                    ACC_DAILY_TRANSACTION_DATE = table.Column<DateTime>(nullable: false),
                    ACC_DAILY_TRANSACTION_MONTH = table.Column<int>(nullable: false),
                    ACC_DAILY_TRANSACTION_YEAR = table.Column<int>(nullable: false),
                    ACC_DAILY_TRANSACTION_DEBIT_AMOUNT = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    ACC_DAILY_TRANSACTION_CREDIT_AMOUNT = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    ACC_DAILY_TRANSACTION_DESCRIPTION = table.Column<string>(maxLength: 250, nullable: false),
                    ACC_DAILY_TRANSACTION_IS_ACTIVE = table.Column<bool>(nullable: false, defaultValue: true),
                    ACC_DAILY_TRANSACTION_CUSTOMER_ID = table.Column<Guid>(nullable: false),
                    ACC_DAILY_TRANSACTION_BOND_ID = table.Column<Guid>(nullable: false),
                    ACC_DAILY_TRANSACTION_DETAIL_ACCOUNT_ID = table.Column<Guid>(nullable: false),
                    ACC_DAILY_TRANSACTION_TOTAL_ACCOUNT_ID = table.Column<Guid>(nullable: false),
                    ACC_DAILY_TRANSACTION_MAIN_ACCOUNT_ID = table.Column<Guid>(nullable: false),
                    ACC_DAILY_TRANSACTION_GL_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACC_DAILY_TRANSACTIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACC_DAILY_TRANSACTIONS_ACC_BONDS_ACC_DAILY_TRANSACTION_BOND_ID",
                        column: x => x.ACC_DAILY_TRANSACTION_BOND_ID,
                        principalTable: "ACC_BONDS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACC_DAILY_TRANSACTIONS_ACC_CUSTOMERS_ACC_DAILY_TRANSACTION_CUSTOMER_ID",
                        column: x => x.ACC_DAILY_TRANSACTION_CUSTOMER_ID,
                        principalTable: "ACC_CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACC_DAILY_TRANSACTIONS_ACC_DETAIL_ACCOUNTS_ACC_DAILY_TRANSACTION_DETAIL_ACCOUNT_ID",
                        column: x => x.ACC_DAILY_TRANSACTION_DETAIL_ACCOUNT_ID,
                        principalTable: "ACC_DETAIL_ACCOUNTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACC_DAILY_TRANSACTIONS_ACC_GENERAL_LEDGERS_ACC_DAILY_TRANSACTION_GL_ID",
                        column: x => x.ACC_DAILY_TRANSACTION_GL_ID,
                        principalTable: "ACC_GENERAL_LEDGERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACC_DAILY_TRANSACTIONS_ACC_MAIN_ACCOUNTS_ACC_DAILY_TRANSACTION_MAIN_ACCOUNT_ID",
                        column: x => x.ACC_DAILY_TRANSACTION_MAIN_ACCOUNT_ID,
                        principalTable: "ACC_MAIN_ACCOUNTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACC_DAILY_TRANSACTIONS_ACC_TOTAL_ACCOUNTS_ACC_DAILY_TRANSACTION_TOTAL_ACCOUNT_ID",
                        column: x => x.ACC_DAILY_TRANSACTION_TOTAL_ACCOUNT_ID,
                        principalTable: "ACC_TOTAL_ACCOUNTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ACC_CUSTOMERS",
                columns: new[] { "ID", "ACC_CUSTOMER_ADDRESS", "ACC_CUSTOMER_CITY", "ACC_CUSTOMER_COUNTRY", "ACC_CUSTOMER_CRT_DATE", "ACC_CUSTOMER_CRT_BY_USR_ID", "ACC_CUSTOMER_NAME_AR", "ACC_CUSTOMER_NAME_EN", "ACC_CUSTOMER_EMAIL", "ACC_CUSTOMER_FAX_NO", "ACC_CUSTOMER_UPD_DATE", "ACC_CUSTOMER_UPD_BY_USR_ID", "ACC_CUSTOMER_MOBILE_NO1", "ACC_CUSTOMER_MOBILE_NO2", "ACC_CUSTOMER_PHONE_NO", "ACC_CUSTOMER_TAX_NO" },
                values: new object[] { new Guid("988cc910-2246-433b-a382-ae5454a855aa"), "Macca St.", "Amman", "Jordan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "مكتب المدير", "Almodeer Office", null, null, null, null, "0795980824", null, null, "123456" });

            migrationBuilder.CreateIndex(
                name: "IX_ACC_DAILY_TRANSACTIONS_ACC_DAILY_TRANSACTION_BOND_ID",
                table: "ACC_DAILY_TRANSACTIONS",
                column: "ACC_DAILY_TRANSACTION_BOND_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_DAILY_TRANSACTIONS_ACC_DAILY_TRANSACTION_CUSTOMER_ID",
                table: "ACC_DAILY_TRANSACTIONS",
                column: "ACC_DAILY_TRANSACTION_CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_DAILY_TRANSACTIONS_ACC_DAILY_TRANSACTION_DETAIL_ACCOUNT_ID",
                table: "ACC_DAILY_TRANSACTIONS",
                column: "ACC_DAILY_TRANSACTION_DETAIL_ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_DAILY_TRANSACTIONS_ACC_DAILY_TRANSACTION_GL_ID",
                table: "ACC_DAILY_TRANSACTIONS",
                column: "ACC_DAILY_TRANSACTION_GL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_DAILY_TRANSACTIONS_ACC_DAILY_TRANSACTION_MAIN_ACCOUNT_ID",
                table: "ACC_DAILY_TRANSACTIONS",
                column: "ACC_DAILY_TRANSACTION_MAIN_ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_DAILY_TRANSACTIONS_ACC_DAILY_TRANSACTION_TOTAL_ACCOUNT_ID",
                table: "ACC_DAILY_TRANSACTIONS",
                column: "ACC_DAILY_TRANSACTION_TOTAL_ACCOUNT_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ACC_DETAIL_ACCOUNTS_ACC_TOTAL_ACCOUNTS_ACC_DETAIL_ACCOUNT_TOTAL_ACCOUNT_ID",
                table: "ACC_DETAIL_ACCOUNTS",
                column: "ACC_DETAIL_ACCOUNT_TOTAL_ACCOUNT_ID",
                principalTable: "ACC_TOTAL_ACCOUNTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ACC_DETAIL_ACCOUNTS_ACC_TOTAL_ACCOUNTS_ACC_DETAIL_ACCOUNT_TOTAL_ACCOUNT_ID",
                table: "ACC_DETAIL_ACCOUNTS");

            migrationBuilder.DropTable(
                name: "ACC_DAILY_TRANSACTIONS");

            migrationBuilder.DeleteData(
                table: "ACC_CUSTOMERS",
                keyColumn: "ID",
                keyValue: new Guid("988cc910-2246-433b-a382-ae5454a855aa"));

            migrationBuilder.InsertData(
                table: "ACC_CUSTOMERS",
                columns: new[] { "ID", "ACC_CUSTOMER_ADDRESS", "ACC_CUSTOMER_CITY", "ACC_CUSTOMER_COUNTRY", "ACC_CUSTOMER_CRT_DATE", "ACC_CUSTOMER_CRT_BY_USR_ID", "ACC_CUSTOMER_NAME_AR", "ACC_CUSTOMER_NAME_EN", "ACC_CUSTOMER_EMAIL", "ACC_CUSTOMER_FAX_NO", "ACC_CUSTOMER_UPD_DATE", "ACC_CUSTOMER_UPD_BY_USR_ID", "ACC_CUSTOMER_MOBILE_NO1", "ACC_CUSTOMER_MOBILE_NO2", "ACC_CUSTOMER_PHONE_NO", "ACC_CUSTOMER_TAX_NO" },
                values: new object[] { new Guid("c0f29a2c-97f7-4b66-970c-0c666b99050f"), "Macca St.", "Amman", "Jordan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "مكتب المدير", "Almodeer Office", null, null, null, null, "0795980824", null, null, "123456" });

            migrationBuilder.AddForeignKey(
                name: "FK_ACC_DETAIL_ACCOUNTS_ACC_TOTAL_ACCOUNTS_ACC_DETAIL_ACCOUNT_TOTAL_ACCOUNT_ID",
                table: "ACC_DETAIL_ACCOUNTS",
                column: "ACC_DETAIL_ACCOUNT_TOTAL_ACCOUNT_ID",
                principalTable: "ACC_TOTAL_ACCOUNTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
