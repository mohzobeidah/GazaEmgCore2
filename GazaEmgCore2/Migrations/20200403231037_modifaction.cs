using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GazaEmgCore2.Migrations
{
    public partial class modifaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_QuarantinedPersons_QuarantinedPersonId",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_QuarantinedPersons_ArrivingPointDetails_ArrivingPointDetailID",
                table: "QuarantinedPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_QuarantinedPersons_ArrivingPoints_ArrivingPointId",
                table: "QuarantinedPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_QuarantinedPersons_Cities_Governorate",
                table: "QuarantinedPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_QuarantinedPersons_Governorates_Governorate",
                table: "QuarantinedPersons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuarantinedPersons",
                table: "QuarantinedPersons");

            migrationBuilder.RenameTable(
                name: "QuarantinedPersons",
                newName: "QuarantinedPerson");

            migrationBuilder.RenameIndex(
                name: "IX_QuarantinedPersons_Governorate",
                table: "QuarantinedPerson",
                newName: "IX_QuarantinedPerson_Governorate");

            migrationBuilder.RenameIndex(
                name: "IX_QuarantinedPersons_ArrivingPointId",
                table: "QuarantinedPerson",
                newName: "IX_QuarantinedPerson_ArrivingPointId");

            migrationBuilder.RenameIndex(
                name: "IX_QuarantinedPersons_ArrivingPointDetailID",
                table: "QuarantinedPerson",
                newName: "IX_QuarantinedPerson_ArrivingPointDetailID");

            migrationBuilder.AddColumn<string>(
                name: "CountryOfReturn",
                table: "QuarantinedPerson",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentityNo",
                table: "QuarantinedPerson",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "nationality",
                table: "QuarantinedPerson",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuarantinedPerson",
                table: "QuarantinedPerson",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventType = table.Column<string>(nullable: true),
                    TableName = table.Column<string>(nullable: true),
                    ColumnName = table.Column<string>(nullable: true),
                    RecordId = table.Column<int>(nullable: false),
                    OriginalValue = table.Column<string>(nullable: true),
                    NewValue = table.Column<string>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_QuarantinedPerson_QuarantinedPersonId",
                table: "Movements",
                column: "QuarantinedPersonId",
                principalTable: "QuarantinedPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuarantinedPerson_ArrivingPointDetails_ArrivingPointDetailID",
                table: "QuarantinedPerson",
                column: "ArrivingPointDetailID",
                principalTable: "ArrivingPointDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuarantinedPerson_ArrivingPoints_ArrivingPointId",
                table: "QuarantinedPerson",
                column: "ArrivingPointId",
                principalTable: "ArrivingPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuarantinedPerson_Cities_Governorate",
                table: "QuarantinedPerson",
                column: "Governorate",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuarantinedPerson_Governorates_Governorate",
                table: "QuarantinedPerson",
                column: "Governorate",
                principalTable: "Governorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_QuarantinedPerson_QuarantinedPersonId",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_QuarantinedPerson_ArrivingPointDetails_ArrivingPointDetailID",
                table: "QuarantinedPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_QuarantinedPerson_ArrivingPoints_ArrivingPointId",
                table: "QuarantinedPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_QuarantinedPerson_Cities_Governorate",
                table: "QuarantinedPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_QuarantinedPerson_Governorates_Governorate",
                table: "QuarantinedPerson");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuarantinedPerson",
                table: "QuarantinedPerson");

            migrationBuilder.DropColumn(
                name: "CountryOfReturn",
                table: "QuarantinedPerson");

            migrationBuilder.DropColumn(
                name: "IdentityNo",
                table: "QuarantinedPerson");

            migrationBuilder.DropColumn(
                name: "nationality",
                table: "QuarantinedPerson");

            migrationBuilder.RenameTable(
                name: "QuarantinedPerson",
                newName: "QuarantinedPersons");

            migrationBuilder.RenameIndex(
                name: "IX_QuarantinedPerson_Governorate",
                table: "QuarantinedPersons",
                newName: "IX_QuarantinedPersons_Governorate");

            migrationBuilder.RenameIndex(
                name: "IX_QuarantinedPerson_ArrivingPointId",
                table: "QuarantinedPersons",
                newName: "IX_QuarantinedPersons_ArrivingPointId");

            migrationBuilder.RenameIndex(
                name: "IX_QuarantinedPerson_ArrivingPointDetailID",
                table: "QuarantinedPersons",
                newName: "IX_QuarantinedPersons_ArrivingPointDetailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuarantinedPersons",
                table: "QuarantinedPersons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_QuarantinedPersons_QuarantinedPersonId",
                table: "Movements",
                column: "QuarantinedPersonId",
                principalTable: "QuarantinedPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuarantinedPersons_ArrivingPointDetails_ArrivingPointDetailID",
                table: "QuarantinedPersons",
                column: "ArrivingPointDetailID",
                principalTable: "ArrivingPointDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuarantinedPersons_ArrivingPoints_ArrivingPointId",
                table: "QuarantinedPersons",
                column: "ArrivingPointId",
                principalTable: "ArrivingPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuarantinedPersons_Cities_Governorate",
                table: "QuarantinedPersons",
                column: "Governorate",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuarantinedPersons_Governorates_Governorate",
                table: "QuarantinedPersons",
                column: "Governorate",
                principalTable: "Governorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
