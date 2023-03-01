using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCasingConventionUpdateUserAddGoogleAccessTokenNewTableUserJunctions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Users",
                newName: "firstName");

            migrationBuilder.AddColumn<string>(
                name: "gAccessToken",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserJunctions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstUserId = table.Column<int>(type: "integer", nullable: false),
                    secondUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJunctions", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserJunctions_Users_firstUserId",
                        column: x => x.firstUserId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJunctions_Users_secondUserId",
                        column: x => x.secondUserId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_gAccessToken",
                table: "Users",
                column: "gAccessToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserJunctions_firstUserId",
                table: "UserJunctions",
                column: "firstUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJunctions_secondUserId",
                table: "UserJunctions",
                column: "secondUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserJunctions");

            migrationBuilder.DropIndex(
                name: "IX_Users_gAccessToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "gAccessToken",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Users",
                newName: "first_name");
        }
    }
}
