using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProgettoSettimanale3_BU2.Migrations
{
    /// <inheritdoc />
    public partial class modifiedArtistDeleteBehaviour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "f8e053ce-224e-4681-8f19-99e62ebd8221", "f8e053ce-224e-4681-8f19-99e62ebd8221", "User", "USER" },
                    { "fda8bf1e-e8ea-4314-b8da-aff190a1a8fc", "fda8bf1e-e8ea-4314-b8da-aff190a1a8fc", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8e053ce-224e-4681-8f19-99e62ebd8221");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fda8bf1e-e8ea-4314-b8da-aff190a1a8fc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "278bc659-36d3-4b45-906d-84a9aee8bea4", "278bc659-36d3-4b45-906d-84a9aee8bea4", "Admin", "ADMIN" },
                    { "e245435e-6e9f-4b76-8d21-287d50c7b3bb", "e245435e-6e9f-4b76-8d21-287d50c7b3bb", "User", "USER" }
                });
        }
    }
}
