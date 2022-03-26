using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YellowPage.Api.Migrations
{
    public partial class UserTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "Business",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddedById",
                table: "Person",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Business_AddedById",
                table: "Business",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Business_User_AddedById",
                table: "Business",
                column: "AddedById",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_User_AddedById",
                table: "Person",
                column: "AddedById",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Business_User_AddedById",
                table: "Business");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_User_AddedById",
                table: "Person");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Person_AddedById",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Business_AddedById",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Business");
        }
    }
}
