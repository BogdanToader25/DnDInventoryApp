using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDInventoryApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.AddColumn<byte[]>(
                name: "Salt",
                table: "AppUsers",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "AppUsers");

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "UserId", "Password", "Roles", "Username" },
                values: new object[] { 1, "Gamemaster25", "GameMaster", "BogdanT" });
        }
    }
}
