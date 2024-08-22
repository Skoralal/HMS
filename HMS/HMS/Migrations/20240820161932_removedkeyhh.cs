using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class removedkeyhh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_HHs_HHID",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Good_HHs_HHID",
                table: "Good");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_HHs_HHID",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HHs",
                table: "HHs");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "HHs");

            migrationBuilder.RenameColumn(
                name: "HHID",
                table: "Member",
                newName: "HHLogin");

            migrationBuilder.RenameIndex(
                name: "IX_Member_HHID",
                table: "Member",
                newName: "IX_Member_HHLogin");

            migrationBuilder.RenameColumn(
                name: "HHID",
                table: "Good",
                newName: "HHLogin");

            migrationBuilder.RenameIndex(
                name: "IX_Good_HHID",
                table: "Good",
                newName: "IX_Good_HHLogin");

            migrationBuilder.RenameColumn(
                name: "HHID",
                table: "Dish",
                newName: "HHLogin");

            migrationBuilder.RenameIndex(
                name: "IX_Dish_HHID",
                table: "Dish",
                newName: "IX_Dish_HHLogin");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "HHs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Good",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HHs",
                table: "HHs",
                column: "Login");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_HHs_HHLogin",
                table: "Dish",
                column: "HHLogin",
                principalTable: "HHs",
                principalColumn: "Login");

            migrationBuilder.AddForeignKey(
                name: "FK_Good_HHs_HHLogin",
                table: "Good",
                column: "HHLogin",
                principalTable: "HHs",
                principalColumn: "Login");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_HHs_HHLogin",
                table: "Member",
                column: "HHLogin",
                principalTable: "HHs",
                principalColumn: "Login");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_HHs_HHLogin",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Good_HHs_HHLogin",
                table: "Good");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_HHs_HHLogin",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HHs",
                table: "HHs");

            migrationBuilder.RenameColumn(
                name: "HHLogin",
                table: "Member",
                newName: "HHID");

            migrationBuilder.RenameIndex(
                name: "IX_Member_HHLogin",
                table: "Member",
                newName: "IX_Member_HHID");

            migrationBuilder.RenameColumn(
                name: "HHLogin",
                table: "Good",
                newName: "HHID");

            migrationBuilder.RenameIndex(
                name: "IX_Good_HHLogin",
                table: "Good",
                newName: "IX_Good_HHID");

            migrationBuilder.RenameColumn(
                name: "HHLogin",
                table: "Dish",
                newName: "HHID");

            migrationBuilder.RenameIndex(
                name: "IX_Dish_HHLogin",
                table: "Dish",
                newName: "IX_Dish_HHID");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "HHs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "HHs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Good",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HHs",
                table: "HHs",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_HHs_HHID",
                table: "Dish",
                column: "HHID",
                principalTable: "HHs",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Good_HHs_HHID",
                table: "Good",
                column: "HHID",
                principalTable: "HHs",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_HHs_HHID",
                table: "Member",
                column: "HHID",
                principalTable: "HHs",
                principalColumn: "ID");
        }
    }
}
