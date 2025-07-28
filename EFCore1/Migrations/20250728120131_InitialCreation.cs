using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 450, nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    PublisherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryGames",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryGames", x => new { x.CategoryId, x.GameId });
                    table.ForeignKey(
                        name: "FK_CategoryGames_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { -5, "Sports" },
                    { -4, "Strategy" },
                    { -3, "RPG" },
                    { -2, "Adventure" },
                    { -1, "Action" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { -10, "Capcom" },
                    { -9, "Sega" },
                    { -8, "Bandai Namco" },
                    { -7, "Square Enix" },
                    { -6, "Microsoft Gaming" },
                    { -5, "Sony Interactive Entertainment" },
                    { -4, "Nintendo" },
                    { -3, "Activision Blizzard" },
                    { -2, "Ubisoft" },
                    { -1, "Electronic Arts" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name", "Price", "PublisherId" },
                values: new object[,]
                {
                    { -10, "Resident Evil 4 Remake", 49.990000000000002, -8 },
                    { -9, "Final Fantasy XVI", 69.989999999999995, -7 },
                    { -8, "The Legend of Zelda: Tears of the Kingdom", 59.990000000000002, -6 },
                    { -7, "Starfield", 59.990000000000002, -5 },
                    { -6, "Horizon Forbidden West", 49.990000000000002, -4 },
                    { -5, "God of War: Ragnarök", 69.989999999999995, -4 },
                    { -4, "Elden Ring", 49.990000000000002, -3 },
                    { -3, "Red Dead Redemption 2", 59.990000000000002, -2 },
                    { -2, "Cyberpunk 2077", 39.990000000000002, -1 },
                    { -1, "The Witcher 3: Wild Hunt", 29.989999999999998, -1 }
                });

            migrationBuilder.InsertData(
                table: "CategoryGames",
                columns: new[] { "CategoryId", "GameId" },
                values: new object[,]
                {
                    { -5, -10 },
                    { -5, -5 },
                    { -4, -9 },
                    { -4, -4 },
                    { -3, -8 },
                    { -3, -3 },
                    { -2, -7 },
                    { -2, -2 },
                    { -1, -6 },
                    { -1, -1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGames_GameId",
                table: "CategoryGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Name",
                table: "Games",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_PublisherId",
                table: "Games",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryGames");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
