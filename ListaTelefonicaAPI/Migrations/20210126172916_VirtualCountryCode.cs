using Microsoft.EntityFrameworkCore.Migrations;

namespace ListaTelefonicaAPI.Migrations
{
    public partial class VirtualCountryCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_CountryCodes_CountryCodeId",
                table: "Phones");

            migrationBuilder.AlterColumn<int>(
                name: "CountryCodeId",
                table: "Phones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_CountryCodes_CountryCodeId",
                table: "Phones",
                column: "CountryCodeId",
                principalTable: "CountryCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_CountryCodes_CountryCodeId",
                table: "Phones");

            migrationBuilder.AlterColumn<int>(
                name: "CountryCodeId",
                table: "Phones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_CountryCodes_CountryCodeId",
                table: "Phones",
                column: "CountryCodeId",
                principalTable: "CountryCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
