using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreAgency.Migrations
{
    public partial class ORM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgencyId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AgencyId",
                table: "Customers",
                column: "AgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Agencies_AgencyId",
                table: "Customers",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Agencies_AgencyId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AgencyId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "Customers");
        }
    }
}
