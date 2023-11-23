using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainWell___BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class DeleteUSerPhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_Users_UserId",
                table: "UserInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "UserInfo",
                newName: "UserInfos");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfo_UserId",
                table: "UserInfos",
                newName: "IX_UserInfos_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfos",
                table: "UserInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_Users_UserId",
                table: "UserInfos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_Users_UserId",
                table: "UserInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfos",
                table: "UserInfos");

            migrationBuilder.RenameTable(
                name: "UserInfos",
                newName: "UserInfo");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfos_UserId",
                table: "UserInfo",
                newName: "IX_UserInfo_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_Users_UserId",
                table: "UserInfo",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
