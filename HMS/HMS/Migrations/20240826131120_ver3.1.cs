using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class ver31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Good_Good_parentId",
                table: "Good");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Good",
                table: "Good");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Good");

            migrationBuilder.RenameColumn(
                name: "parentId",
                table: "Good",
                newName: "ParentName");

            migrationBuilder.RenameIndex(
                name: "IX_Good_parentId",
                table: "Good",
                newName: "IX_Good_ParentName");

            migrationBuilder.AddColumn<string>(
                name: "SerializedDish",
                table: "HHs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SerializedGoods",
                table: "HHs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SerializedMember",
                table: "HHs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                name: "FK_Good_Good_ParentName",
                table: "Good",
                column: "ParentName",
                principalTable: "Good",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Good_Good_ParentName",
                table: "Good");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Good",
                table: "Good");

            migrationBuilder.DropColumn(
                name: "SerializedDish",
                table: "HHs");

            migrationBuilder.DropColumn(
                name: "SerializedGoods",
                table: "HHs");

            migrationBuilder.DropColumn(
                name: "SerializedMember",
                table: "HHs");

            migrationBuilder.RenameColumn(
                name: "ParentName",
                table: "Good",
                newName: "parentId");

            migrationBuilder.RenameIndex(
                name: "IX_Good_ParentName",
                table: "Good",
                newName: "IX_Good_parentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Good",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Good",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Good",
                table: "Good",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Good_Good_parentId",
                table: "Good",
                column: "parentId",
                principalTable: "Good",
                principalColumn: "Id");
        }
    }
}
