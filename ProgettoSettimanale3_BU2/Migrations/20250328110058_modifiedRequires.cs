using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProgettoSettimanale3_BU2.Migrations
{
    /// <inheritdoc />
    public partial class modifiedRequires : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "278bc659-36d3-4b45-906d-84a9aee8bea4", "278bc659-36d3-4b45-906d-84a9aee8bea4", "Admin", "ADMIN" },
                    { "e245435e-6e9f-4b76-8d21-287d50c7b3bb", "e245435e-6e9f-4b76-8d21-287d50c7b3bb", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "278bc659-36d3-4b45-906d-84a9aee8bea4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e245435e-6e9f-4b76-8d21-287d50c7b3bb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bbfc10ab-ec95-4435-8707-f0505a511c5c", "bbfc10ab-ec95-4435-8707-f0505a511c5c", "Admin", "ADMIN" },
                    { "ce4e678b-2cf8-496e-800d-5070c52ba50c", "ce4e678b-2cf8-496e-800d-5070c52ba50c", "User", "USER" }
                });
        }
    }
}
