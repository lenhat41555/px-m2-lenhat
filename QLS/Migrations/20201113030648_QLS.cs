using Microsoft.EntityFrameworkCore.Migrations;

namespace QLS.Migrations
{
    public partial class QLS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBook = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    PublishingYear = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 1, "lịch sử" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 2, "toán" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 3, "văn" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Amount", "Author", "CategoryId", "Content", "NameBook", "PublishingYear" },
                values: new object[] { 1, 127, "le nhat", 1, "chien tranh", "lịch sử", 2020 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Amount", "Author", "CategoryId", "Content", "NameBook", "PublishingYear" },
                values: new object[] { 2, 167, "long", 2, "hàm", "toán", 2010 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Amount", "Author", "CategoryId", "Content", "NameBook", "PublishingYear" },
                values: new object[] { 3, 177, "tuan anh", 3, "thơ", "văn", 2009 });

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
