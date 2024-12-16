using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elux.Dal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDraftTable5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "BookServiceItemsDraft",
                newName: "CartDraftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartDraftId",
                table: "BookServiceItemsDraft",
                newName: "CartId");
        }
    }
}
