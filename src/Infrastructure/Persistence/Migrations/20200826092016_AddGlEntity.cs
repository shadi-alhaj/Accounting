using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infrastructure.Persistence.Migrations
{
    public partial class AddGlEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_ACC_GENERAL_LEDGERS_ACC_GL_CUSTOMER_ID",
                table: "ACC_GENERAL_LEDGERS",
                column: "ACC_GL_CUSTOMER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACC_GENERAL_LEDGERS");
        }
    }
}
