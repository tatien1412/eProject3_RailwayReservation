using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayTransaction.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatType",
                table: "Seats");

            migrationBuilder.AddColumn<string>(
                name: "SeatType",
                table: "Compartments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatType",
                table: "Compartments");

            migrationBuilder.AddColumn<string>(
                name: "SeatType",
                table: "Seats",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
