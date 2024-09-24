using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayTransaction.Migrations
{
    /// <inheritdoc />
    public partial class scheduleupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateOfTravel",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfTravel",
                table: "Schedules");
        }
    }
}
