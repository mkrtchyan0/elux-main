using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elux.Dal.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpertId = table.Column<Guid>(type: "uuid", nullable: false),
                    Day = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartingTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndingTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ApplicationExpertId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Experts_ApplicationExpertId",
                        column: x => x.ApplicationExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ApplicationExpertId",
                table: "Bookings",
                column: "ApplicationExpertId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
