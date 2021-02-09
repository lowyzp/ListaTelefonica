using Microsoft.EntityFrameworkCore.Migrations;

namespace ListaTelefonicaAPI.Migrations
{
    public partial class countrycodestableimplementation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryCodeId",
                table: "Phones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CountryCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCodes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_CountryCodeId",
                table: "Phones",
                column: "CountryCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_CountryCodes_CountryCodeId",
                table: "Phones",
                column: "CountryCodeId",
                principalTable: "CountryCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_CountryCodes_CountryCodeId",
                table: "Phones");

            migrationBuilder.DropTable(
                name: "CountryCodes");

            migrationBuilder.DropIndex(
                name: "IX_Phones_CountryCodeId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "CountryCodeId",
                table: "Phones");
        }
    }
}
