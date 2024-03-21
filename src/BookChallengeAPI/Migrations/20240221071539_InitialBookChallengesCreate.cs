using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookChallengeAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialBookChallengesCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    NoOfBooks = table.Column<int>(type: "INTEGER", nullable: false),
                    NoOfUsers = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    NoOfChallenges = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Genre = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    Pages = table.Column<string>(type: "TEXT", nullable: true),
                    ChallengeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChallengeDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    NoOfBooks = table.Column<int>(type: "INTEGER", nullable: false),
                    NoOfUsers = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChallengeDto_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChallengeBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChallengeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChallengeBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChallengeBooks_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Genre = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    Pages = table.Column<string>(type: "TEXT", nullable: true),
                    ChallengeDtoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookDto_ChallengeDto_ChallengeDtoId",
                        column: x => x.ChallengeDtoId,
                        principalTable: "ChallengeDto",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ChallengeId", "Description", "Genre", "Language", "Pages", "Title", "Url", "Year" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", null, "Set in the summer of 1922 on Long Island and in New York City, this classic novel captures the essence of the Jazz Age with its lavish parties, love affairs, and societal commentary.", "Classic", "English", "180", "The Great Gatsby", "https://www.goodreads.com/book/show/4671.The_Great_Gatsby", 1925 },
                    { 2, "Sue Monk Kidd", null, "Set in South Carolina during the summer of 1964, this novel follows a young girl named Lily Owens as she embarks on a journey to uncover the truth about her mother's past and finds solace and healing in the company of beekeeping sisters.", "Fiction", "English", "302", "The Secret Life of Bees", "https://www.goodreads.com/book/show/37435.The_Secret_Life_of_Bees", 2001 },
                    { 3, "Emma Straub", null, "This novel takes place during a two-week family vacation in Mallorca, Spain, where secrets and tensions bubble to the surface as the Post family navigates love, betrayal, and redemption.", "Fiction", "English", "292", "The Vacationers", "https://www.goodreads.com/book/show/18641982-the-vacationers", 2014 },
                    { 4, "Erin Morgenstern", null, "This enchanting novel follows the mysterious Le Cirque des Rêves, a circus that arrives without warning and is only open at night. The story unfolds over many years, capturing the magic and romance of autumn.", "Fiction", "English", "506", "The Night Circus", "https://www.goodreads.com/book/show/9361589-the-night-circus", 2011 },
                    { 5, "Donna Tartt", null, "This atmospheric novel is set in a New England college town during the fall semester. It follows a group of eccentric classics students who become entangled in a dark and sinister secret.", "Classic", "English", "559", "The Secret History", null, 1992 }
                });

            migrationBuilder.InsertData(
                table: "Challenges",
                columns: new[] { "Id", "Description", "Name", "NoOfBooks", "NoOfUsers" },
                values: new object[,]
                {
                    { 1, "Read books set in summer", "summer reading", 5, 0 },
                    { 2, "Read books set in autumn", "autumn reading", 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "ChallengeBooks",
                columns: new[] { "Id", "BookId", "ChallengeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 2 },
                    { 5, 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookDto_ChallengeDtoId",
                table: "BookDto",
                column: "ChallengeDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ChallengeId",
                table: "Books",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeBooks_BookId",
                table: "ChallengeBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeBooks_ChallengeId",
                table: "ChallengeBooks",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeDto_UserId",
                table: "ChallengeDto",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookDto");

            migrationBuilder.DropTable(
                name: "ChallengeBooks");

            migrationBuilder.DropTable(
                name: "ChallengeDto");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Challenges");
        }
    }
}
