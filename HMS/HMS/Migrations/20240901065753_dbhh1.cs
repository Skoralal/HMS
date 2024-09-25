using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class dbhh1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Good");

            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "Member");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HHLogin = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Login);
                    table.ForeignKey(
                        name: "FK_Member_HHs_HHLogin",
                        column: x => x.HHLogin,
                        principalTable: "HHs",
                        principalColumn: "Login");
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Consumed = table.Column<bool>(type: "bit", nullable: false),
                    Cooked = table.Column<bool>(type: "bit", nullable: false),
                    HHLogin = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MemberLogin = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recipe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dish_HHs_HHLogin",
                        column: x => x.HHLogin,
                        principalTable: "HHs",
                        principalColumn: "Login");
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DishID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HHLogin = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassiveConsumption = table.Column<double>(type: "float", nullable: false),
                    Recipe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Good", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Good_Dish_DishID",
                        column: x => x.DishID,
                        principalTable: "Dish",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Good_Good_ParentName",
                        column: x => x.ParentName,
                        principalTable: "Good",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Good_HHs_HHLogin",
                        column: x => x.HHLogin,
                        principalTable: "HHs",
                        principalColumn: "Login");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dish_HHLogin",
                table: "Dish",
                column: "HHLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_MemberLogin",
                table: "Dish",
                column: "MemberLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Good_DishID",
                table: "Good",
                column: "DishID");

            migrationBuilder.CreateIndex(
                name: "IX_Good_HHLogin",
                table: "Good",
                column: "HHLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Good_ParentName",
                table: "Good",
                column: "ParentName");

            migrationBuilder.CreateIndex(
                name: "IX_Member_HHLogin",
                table: "Member",
                column: "HHLogin");
        }
    }
}
