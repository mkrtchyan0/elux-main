using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elux.Dal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDraftTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookServiceItems_Carts_CartItemId",
                table: "BookServiceItems");

            migrationBuilder.DropIndex(
                name: "IX_BookServiceItems_CartItemId",
                table: "BookServiceItems");

            migrationBuilder.DropColumn(
                name: "CartItemId",
                table: "BookServiceItems");

            migrationBuilder.RenameColumn(
                name: "CartDraftId",
                table: "BookServiceItems",
                newName: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "BookServiceItems",
                newName: "CartDraftId");

            migrationBuilder.AddColumn<Guid>(
                name: "CartItemId",
                table: "BookServiceItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookServiceItems_CartItemId",
                table: "BookServiceItems",
                column: "CartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookServiceItems_Carts_CartItemId",
                table: "BookServiceItems",
                column: "CartItemId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
