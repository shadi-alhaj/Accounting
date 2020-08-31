using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infrastructure.Persistence.Migrations
{
    public partial class Init : Migration
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
                    ACC_CUSTOMER_EMAIL = table.Column<string>(maxLength: 100, nullable: true),
                    ACC_CUSTOMER_IS_ACTIVE = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACC_CUSTOMERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Colour = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ACC_BONDS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ACC_BOND_CRT_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_BOND_CRT_DATE = table.Column<DateTime>(nullable: false),
                    ACC_BOND_UPD_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_BOND_UPD_DATE = table.Column<DateTime>(nullable: true),
                    ACC_BOND_USER_ID = table.Column<int>(nullable: false),
                    ACC_BOND_INTIAL_SNO = table.Column<int>(nullable: false),
                    ACC_BOND_NAME_AR = table.Column<string>(maxLength: 250, nullable: false),
                    ACC_BOND_NAME_EN = table.Column<string>(maxLength: 250, nullable: true),
                    ACC_BOND_IS_ACTIVE = table.Column<bool>(nullable: false, defaultValue: true),
                    ACC_BOND_CUSTOMER_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACC_BONDS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACC_BONDS_ACC_CUSTOMERS_ACC_BOND_CUSTOMER_ID",
                        column: x => x.ACC_BOND_CUSTOMER_ID,
                        principalTable: "ACC_CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ACC_GENERAL_LEDGERS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ACC_GL_CRT_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_GL_CRT_DATE = table.Column<DateTime>(nullable: false),
                    ACC_GL_UPD_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_GL_UPD_DATE = table.Column<DateTime>(nullable: true),
                    ACC_GL_ID_BY_CUSTOMER = table.Column<int>(maxLength: 250, nullable: false),
                    ACC_GL_NAME_AR = table.Column<string>(maxLength: 250, nullable: false),
                    ACC_GL_NAME_EN = table.Column<string>(maxLength: 250, nullable: true),
                    ACC_GL_CUSTOMER_ID = table.Column<Guid>(nullable: false),
                    ACC_GL_IS_ACTIVE = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACC_GENERAL_LEDGERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACC_GENERAL_LEDGERS_ACC_CUSTOMERS_ACC_GL_CUSTOMER_ID",
                        column: x => x.ACC_GL_CUSTOMER_ID,
                        principalTable: "ACC_CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    ListId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Done = table.Column<bool>(nullable: false),
                    Reminder = table.Column<DateTime>(nullable: true),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItems_TodoLists_ListId",
                        column: x => x.ListId,
                        principalTable: "TodoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ACC_MAIN_ACCOUNTS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ACC_MAIN_ACCOUNT_CRT_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_MAIN_ACCOUNT_CRT_DATE = table.Column<DateTime>(nullable: false),
                    ACC_MAIN_ACCOUNT_UPD_BY_USR_ID = table.Column<string>(nullable: true),
                    ACC_MAIN_ACCOUNT_UPD_DATE = table.Column<DateTime>(nullable: true),
                    ACC_MAIN_ACCOUNT_ID_BY_CUSTOMER = table.Column<int>(maxLength: 250, nullable: false),
                    ACC_MAIN_ACCOUNT_NAME_AR = table.Column<string>(maxLength: 250, nullable: false),
                    ACC_MAIN_ACCOUNT_NAME_EN = table.Column<string>(maxLength: 250, nullable: true),
                    ACC_MAIN_ACCOUNT_CUSTOMER_ID = table.Column<Guid>(nullable: false),
                    ACC_MAIN_ACCOUNT_GL_ID = table.Column<Guid>(nullable: false),
                    ACC_MAIN_ACCOUNT_IS_ACTIVE = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACC_MAIN_ACCOUNTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACC_MAIN_ACCOUNTS_ACC_CUSTOMERS_ACC_MAIN_ACCOUNT_CUSTOMER_ID",
                        column: x => x.ACC_MAIN_ACCOUNT_CUSTOMER_ID,
                        principalTable: "ACC_CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACC_MAIN_ACCOUNTS_ACC_GENERAL_LEDGERS_ACC_MAIN_ACCOUNT_GL_ID",
                        column: x => x.ACC_MAIN_ACCOUNT_GL_ID,
                        principalTable: "ACC_GENERAL_LEDGERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    ACC_TOTAL_ACCOUNT_IS_ACTIVE = table.Column<bool>(nullable: false, defaultValue: true)
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
                        name: "FK_ACC_TOTAL_ACCOUNTS_ACC_GENERAL_LEDGERS_ACC_TOTAL_ACCOUNT_GL_ID",
                        column: x => x.ACC_TOTAL_ACCOUNT_GL_ID,
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
                name: "IX_ACC_BONDS_ACC_BOND_CUSTOMER_ID",
                table: "ACC_BONDS",
                column: "ACC_BOND_CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_FINANCE_YEARS_ACC_FINANCE_YEAR_CUSTOMER_ID",
                table: "ACC_FINANCE_YEARS",
                column: "ACC_FINANCE_YEAR_CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_GENERAL_LEDGERS_ACC_GL_CUSTOMER_ID",
                table: "ACC_GENERAL_LEDGERS",
                column: "ACC_GL_CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_MAIN_ACCOUNTS_ACC_MAIN_ACCOUNT_CUSTOMER_ID",
                table: "ACC_MAIN_ACCOUNTS",
                column: "ACC_MAIN_ACCOUNT_CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_MAIN_ACCOUNTS_ACC_MAIN_ACCOUNT_GL_ID",
                table: "ACC_MAIN_ACCOUNTS",
                column: "ACC_MAIN_ACCOUNT_GL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_TOTAL_ACCOUNTS_ACC_TOTAL_ACCOUNT_CUSTOMER_ID",
                table: "ACC_TOTAL_ACCOUNTS",
                column: "ACC_TOTAL_ACCOUNT_CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_TOTAL_ACCOUNTS_ACC_TOTAL_ACCOUNT_GL_ID",
                table: "ACC_TOTAL_ACCOUNTS",
                column: "ACC_TOTAL_ACCOUNT_GL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_TOTAL_ACCOUNTS_ACC_TOTAL_ACCOUNT_MAIN_ACCOUNT_ID",
                table: "ACC_TOTAL_ACCOUNTS",
                column: "ACC_TOTAL_ACCOUNT_MAIN_ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ListId",
                table: "TodoItems",
                column: "ListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACC_BONDS");

            migrationBuilder.DropTable(
                name: "ACC_FINANCE_YEARS");

            migrationBuilder.DropTable(
                name: "ACC_TOTAL_ACCOUNTS");

            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "ACC_MAIN_ACCOUNTS");

            migrationBuilder.DropTable(
                name: "TodoLists");

            migrationBuilder.DropTable(
                name: "ACC_GENERAL_LEDGERS");

            migrationBuilder.DropTable(
                name: "ACC_CUSTOMERS");
        }
    }
}
