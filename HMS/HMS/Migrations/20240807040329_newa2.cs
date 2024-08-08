using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class newa2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goods1",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<double>(type: "float", nullable: false),
                    PassiveConsumption = table.Column<double>(type: "float", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recipe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Good1ID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods1", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Goods1_Goods1_Good1ID",
                        column: x => x.Good1ID,
                        principalTable: "Goods1",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goods1_Good1ID",
                table: "Goods1",
                column: "Good1ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goods1");
        }
    }
}
