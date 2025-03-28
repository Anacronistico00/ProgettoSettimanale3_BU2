using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProgettoSettimanale3_BU2.Migrations
{
    /// <inheritdoc />
    public partial class AddedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "812bc849-8c54-416a-9a1f-ae55c332d307");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "963701b2-85a3-41e0-af68-285548ae8471");

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genere = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Biografia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistaId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titolo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Luogo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ArtistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventoId);
                    table.ForeignKey(
                        name: "FK_Events_Artists_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artists",
                        principalColumn: "ArtistaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    BigliettoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataAcquisto = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.BigliettoId);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Events_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Events",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bbfc10ab-ec95-4435-8707-f0505a511c5c", "bbfc10ab-ec95-4435-8707-f0505a511c5c", "Admin", "ADMIN" },
                    { "ce4e678b-2cf8-496e-800d-5070c52ba50c", "ce4e678b-2cf8-496e-800d-5070c52ba50c", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ArtistaId",
                table: "Events",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventoId",
                table: "Tickets",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbfc10ab-ec95-4435-8707-f0505a511c5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce4e678b-2cf8-496e-800d-5070c52ba50c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "812bc849-8c54-416a-9a1f-ae55c332d307", "812bc849-8c54-416a-9a1f-ae55c332d307", "Admin", "ADMIN" },
                    { "963701b2-85a3-41e0-af68-285548ae8471", "963701b2-85a3-41e0-af68-285548ae8471", "User", "USER" }
                });
        }
    }
}
