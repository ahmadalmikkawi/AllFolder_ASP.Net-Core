using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store.Migrations
{
    public partial class DBMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create Table Author With Constraints
            migrationBuilder.CreateTable(
                name: "DBAuthor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBAuthor", x => x.id);
                });

            //========================================================================

            // Create Table Book With Constraints
            migrationBuilder.CreateTable(
                name: "DBBook",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    descreption = table.Column<string>(nullable: true),
                    authorid = table.Column<int>(nullable: true),
                    UrlFile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBBook", x => x.id);
                    table.ForeignKey(
                        name: "FK_DBBook_DBAuthor_authorid",
                        column: x => x.authorid,
                        principalTable: "DBAuthor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });


            //========================================================================

            migrationBuilder.CreateIndex(
                name: "IX_DBBook_authorid",
                table: "DBBook",
                column: "authorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBBook");

            migrationBuilder.DropTable(
                name: "DBAuthor");
        }
    }
}
