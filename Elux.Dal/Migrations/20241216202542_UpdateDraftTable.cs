using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elux.Dal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDraftTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookServiceItems_CartDrafts_CartDraftItemId",
                table: "BookServiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BookServiceItems_Carts_CartItemId",
                table: "BookServiceItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookServiceItems",
                table: "BookServiceItems");

            migrationBuilder.RenameTable(
                name: "BookServiceItems",
                newName: "BookServiceItem");

            migrationBuilder.RenameIndex(
                name: "IX_BookServiceItems_CartItemId",
                table: "BookServiceItem",
                newName: "IX_BookServiceItem_CartItemId");

            migrationBuilder.RenameIndex(
                name: "IX_BookServiceItems_CartDraftItemId",
                table: "BookServiceItem",
                newName: "IX_BookServiceItem_CartDraftItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookServiceItem",
                table: "BookServiceItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookServiceItem_CartDrafts_CartDraftItemId",
                table: "BookServiceItem",
                column: "CartDraftItemId",
                principalTable: "CartDrafts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookServiceItem_Carts_CartItemId",
                table: "BookServiceItem",
                column: "CartItemId",
                principalTable: "Carts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookServiceItem_CartDrafts_CartDraftItemId",
                table: "BookServiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BookServiceItem_Carts_CartItemId",
                table: "BookServiceItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookServiceItem",
                table: "BookServiceItem");

            migrationBuilder.RenameTable(
                name: "BookServiceItem",
                newName: "BookServiceItems");

            migrationBuilder.RenameIndex(
                name: "IX_BookServiceItem_CartItemId",
                table: "BookServiceItems",
                newName: "IX_BookServiceItems_CartItemId");

            migrationBuilder.RenameIndex(
                name: "IX_BookServiceItem_CartDraftItemId",
                table: "BookServiceItems",
                newName: "IX_BookServiceItems_CartDraftItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookServiceItems",
                table: "BookServiceItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookServiceItems_CartDrafts_CartDraftItemId",
                table: "BookServiceItems",
                column: "CartDraftItemId",
                principalTable: "CartDrafts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookServiceItems_Carts_CartItemId",
                table: "BookServiceItems",
                column: "CartItemId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
