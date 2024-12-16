using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elux.Dal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDraftTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookServiceItems_CartDrafts_CartDraftItemId",
                table: "BookServiceItems");

            migrationBuilder.DropIndex(
                name: "IX_BookServiceItems_CartDraftItemId",
                table: "BookServiceItems");

            migrationBuilder.DropColumn(
                name: "CartDraftItemId",
                table: "BookServiceItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CartDraftItemId",
                table: "BookServiceItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookServiceItems_CartDraftItemId",
                table: "BookServiceItems",
                column: "CartDraftItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookServiceItems_CartDrafts_CartDraftItemId",
                table: "BookServiceItems",
                column: "CartDraftItemId",
                principalTable: "CartDrafts",
                principalColumn: "Id");
        }
    }
}
