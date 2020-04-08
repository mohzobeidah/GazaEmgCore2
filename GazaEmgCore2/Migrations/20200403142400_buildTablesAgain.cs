using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GazaEmgCore2.Migrations
{
    public partial class buildTablesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HealthCenterId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ArrivingPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrivingPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governorates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthCenters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ManagerId = table.Column<string>(nullable: true),
                    startDate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    SecuityCount = table.Column<int>(nullable: false),
                    MedicsCount = table.Column<int>(nullable: false),
                    WorkersCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCenters_AspNetUsers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArrivingPointDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ArrivingPointsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrivingPointDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArrivingPointDetails_ArrivingPoints_ArrivingPointsId",
                        column: x => x.ArrivingPointsId,
                        principalTable: "ArrivingPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    GovernorateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuarantinedPersons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDType = table.Column<int>(nullable: false),
                    Fname = table.Column<string>(nullable: true),
                    Sname = table.Column<string>(nullable: true),
                    Tname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    PhoneNo = table.Column<string>(nullable: true),
                    HealthStatus = table.Column<string>(nullable: true),
                    Governorate = table.Column<int>(nullable: false),
                    City = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    ArrivingPointId = table.Column<int>(nullable: false),
                    ArrivingPointDetailID = table.Column<int>(nullable: false),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    InsertUser = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdatetUser = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuarantinedPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuarantinedPersons_ArrivingPointDetails_ArrivingPointDetailID",
                        column: x => x.ArrivingPointDetailID,
                        principalTable: "ArrivingPointDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuarantinedPersons_ArrivingPoints_ArrivingPointId",
                        column: x => x.ArrivingPointId,
                        principalTable: "ArrivingPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuarantinedPersons_Cities_Governorate",
                        column: x => x.Governorate,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuarantinedPersons_Governorates_Governorate",
                        column: x => x.Governorate,
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuarantinedPersonId = table.Column<int>(nullable: false),
                    HealthCenterId = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    HealthStatus = table.Column<string>(nullable: true),
                    Order = table.Column<string>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdatetUser = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movements_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movements_QuarantinedPersons_QuarantinedPersonId",
                        column: x => x.QuarantinedPersonId,
                        principalTable: "QuarantinedPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HealthCenterId",
                table: "AspNetUsers",
                column: "HealthCenterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArrivingPointDetails_ArrivingPointsId",
                table: "ArrivingPointDetails",
                column: "ArrivingPointsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_GovernorateId",
                table: "Cities",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCenters_ManagerId",
                table: "HealthCenters",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_HealthCenterId",
                table: "Movements",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_QuarantinedPersonId",
                table: "Movements",
                column: "QuarantinedPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_QuarantinedPersons_ArrivingPointDetailID",
                table: "QuarantinedPersons",
                column: "ArrivingPointDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_QuarantinedPersons_ArrivingPointId",
                table: "QuarantinedPersons",
                column: "ArrivingPointId");

            migrationBuilder.CreateIndex(
                name: "IX_QuarantinedPersons_Governorate",
                table: "QuarantinedPersons",
                column: "Governorate");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_HealthCenters_HealthCenterId",
                table: "AspNetUsers",
                column: "HealthCenterId",
                principalTable: "HealthCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_HealthCenters_HealthCenterId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.DropTable(
                name: "HealthCenters");

            migrationBuilder.DropTable(
                name: "QuarantinedPersons");

            migrationBuilder.DropTable(
                name: "ArrivingPointDetails");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "ArrivingPoints");

            migrationBuilder.DropTable(
                name: "Governorates");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HealthCenterId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HealthCenterId",
                table: "AspNetUsers");
        }
    }
}
