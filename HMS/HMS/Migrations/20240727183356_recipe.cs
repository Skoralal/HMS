using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class recipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Recipe",
                table: "DBDishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recipe",
                table: "DBDishes");
        }
    }
}
