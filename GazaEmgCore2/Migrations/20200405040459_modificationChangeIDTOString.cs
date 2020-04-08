using Microsoft.EntityFrameworkCore.Migrations;

namespace GazaEmgCore2.Migrations
{
    public partial class modificationChangeIDTOString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdentityNo",
                table: "QuarantinedPerson",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdentityNo",
                table: "QuarantinedPerson",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
