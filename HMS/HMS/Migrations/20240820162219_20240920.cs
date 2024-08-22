using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class _20240920 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Good_Good_GoodID",
                table: "Good");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Good",
                table: "Good");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Good");

            migrationBuilder.DropColumn(
                name: "HHOwner",
                table: "Good");

            migrationBuilder.RenameColumn(
                name: "GoodID",
                table: "Good",
                newName: "GoodName");

            migrationBuilder.RenameIndex(
                name: "IX_Good_GoodID",
                table: "Good",
                newName: "IX_Good_GoodName");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Good",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Good",
                table: "Good",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Good_Good_GoodName",
                table: "Good",
                column: "GoodName",
                principalTable: "Good",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Good_Good_GoodName",
                table: "Good");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Good",
                table: "Good");

            migrationBuilder.RenameColumn(
                name: "GoodName",
                table: "Good",
                newName: "GoodID");

            migrationBuilder.RenameIndex(
                name: "IX_Good_GoodName",
                table: "Good",
                newName: "IX_Good_GoodID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Good",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "Good",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HHOwner",
                table: "Good",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Good",
                table: "Good",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Good_Good_GoodID",
                table: "Good",
                column: "GoodID",
                principalTable: "Good",
                principalColumn: "ID");
        }
    }
}
