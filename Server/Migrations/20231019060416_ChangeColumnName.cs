using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Users_UserID",
                table: "Boards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boards",
                table: "Boards");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Boards",
                newName: "boards");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "users",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "users",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "boards",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "boards",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "boards",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "PublishedOn",
                table: "boards",
                newName: "published_on");

            migrationBuilder.RenameColumn(
                name: "BoardID",
                table: "boards",
                newName: "board_id");

            migrationBuilder.RenameIndex(
                name: "IX_Boards_UserID",
                table: "boards",
                newName: "IX_boards_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_boards",
                table: "boards",
                column: "board_id");

            migrationBuilder.AddForeignKey(
                name: "FK_boards_users_user_id",
                table: "boards",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_boards_users_user_id",
                table: "boards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_boards",
                table: "boards");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "boards",
                newName: "Boards");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Boards",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Boards",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Boards",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "published_on",
                table: "Boards",
                newName: "PublishedOn");

            migrationBuilder.RenameColumn(
                name: "board_id",
                table: "Boards",
                newName: "BoardID");

            migrationBuilder.RenameIndex(
                name: "IX_boards_user_id",
                table: "Boards",
                newName: "IX_Boards_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boards",
                table: "Boards",
                column: "BoardID");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Users_UserID",
                table: "Boards",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
