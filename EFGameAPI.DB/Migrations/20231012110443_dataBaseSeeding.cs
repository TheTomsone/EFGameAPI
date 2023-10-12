using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFGameAPI.DB.Migrations
{
    /// <inheritdoc />
    public partial class dataBaseSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Resume = table.Column<string>(type: "VARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "VARBINARY(64)", nullable: false),
                    Salt = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RoleId = table.Column<int>(type: "INT", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameGenres",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenres", x => new { x.GameId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_GameGenres_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameGenres_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersGame",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersGame", x => new { x.UserId, x.GameId });
                    table.ForeignKey(
                        name: "FK_UsersGame_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersGame_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Resume", "Title" },
                values: new object[,]
                {
                    { 1, "The largest technical leap forward in Counter-Strike''s history, ensuring new features and updates for years to come.", "Counter-Strike 2" },
                    { 2, "In-development multiplayer, space trading and combat simulation game. The game is being developed and published by Cloud Imperium Games", "Star Citizen" },
                    { 3, "Role-playing video game developed and published by Larian Studios. It is the third main installment in the Baldur''s Gate series, based on the tabletop role-playing system of Dungeons & Dragons.", "Baldur's Gate 3" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Coop" },
                    { 4, "Early Access" },
                    { 5, "FPS" },
                    { 6, "Free to Play" },
                    { 7, "MMO" },
                    { 8, "Management" },
                    { 9, "Multi" },
                    { 10, "RPG" },
                    { 11, "Racing" },
                    { 12, "Simulation" },
                    { 13, "Solo" }
                });

            migrationBuilder.InsertData(
                table: "GameGenres",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 9 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 10 },
                    { 2, 13 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 7 },
                    { 3, 9 },
                    { 3, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_Title",
                table: "Game",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_GenreId",
                table: "GameGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Label",
                table: "Genre",
                column: "Label",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersGame_GameId",
                table: "UsersGame",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGenres");

            migrationBuilder.DropTable(
                name: "UsersGame");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
