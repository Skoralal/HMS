using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class ver2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HHs",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shops = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HHs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HHID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Login);
                    table.ForeignKey(
                        name: "FK_Member_HHs_HHID",
                        column: x => x.HHID,
                        principalTable: "HHs",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cooked = table.Column<bool>(type: "bit", nullable: false),
                    Consumed = table.Column<bool>(type: "bit", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Recipe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HHID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MemberLogin = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dish_HHs_HHID",
                        column: x => x.HHID,
                        principalTable: "HHs",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Dish_Member_MemberLogin",
                        column: x => x.MemberLogin,
                        principalTable: "Member",
                        principalColumn: "Login");
                });

            migrationBuilder.CreateTable(
                name: "Good",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HHOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<double>(type: "float", nullable: false),
                    PassiveConsumption = table.Column<double>(type: "float", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recipe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DishID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GoodID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HHID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Good", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Good_Dish_DishID",
                        column: x => x.DishID,
                        principalTable: "Dish",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Good_Good_GoodID",
                        column: x => x.GoodID,
                        principalTable: "Good",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Good_HHs_HHID",
                        column: x => x.HHID,
                        principalTable: "HHs",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dish_HHID",
                table: "Dish",
                column: "HHID");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_MemberLogin",
                table: "Dish",
                column: "MemberLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Good_DishID",
                table: "Good",
                column: "DishID");

            migrationBuilder.CreateIndex(
                name: "IX_Good_GoodID",
                table: "Good",
                column: "GoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Good_HHID",
                table: "Good",
                column: "HHID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_HHID",
                table: "Member",
                column: "HHID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Good");

            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "HHs");
        }
    }
}
