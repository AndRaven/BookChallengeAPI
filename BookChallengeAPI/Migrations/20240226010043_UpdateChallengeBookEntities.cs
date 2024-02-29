using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookChallengeAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChallengeBookEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChallengeBooks",
                table: "ChallengeBooks");

            migrationBuilder.DropIndex(
                name: "IX_ChallengeBooks_BookId",
                table: "ChallengeBooks");

            migrationBuilder.DeleteData(
                table: "ChallengeBooks",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ChallengeBooks",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ChallengeBooks",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ChallengeBooks",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ChallengeBooks",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ChallengeBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChallengeBooks",
                table: "ChallengeBooks",
                columns: new[] { "BookId", "ChallengeId" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Url",
                value: "https://www.goodreads.com/book/show/29044.The_Secret_History");

            migrationBuilder.InsertData(
                table: "ChallengeBooks",
                columns: new[] { "BookId", "ChallengeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChallengeBooks",
                table: "ChallengeBooks");

            migrationBuilder.DeleteData(
                table: "ChallengeBooks",
                keyColumns: new[] { "BookId", "ChallengeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ChallengeBooks",
                keyColumns: new[] { "BookId", "ChallengeId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ChallengeBooks",
                keyColumns: new[] { "BookId", "ChallengeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ChallengeBooks",
                keyColumns: new[] { "BookId", "ChallengeId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ChallengeBooks",
                keyColumns: new[] { "BookId", "ChallengeId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ChallengeBooks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChallengeBooks",
                table: "ChallengeBooks",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Url",
                value: null);

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
                name: "IX_ChallengeBooks_BookId",
                table: "ChallengeBooks",
                column: "BookId");
        }
    }
}
