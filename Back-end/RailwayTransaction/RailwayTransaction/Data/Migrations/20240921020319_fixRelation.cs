using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayTransaction.Migrations
{
    /// <inheritdoc />
    public partial class fixRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Trains_TrainID",
                table: "Schedules");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Trains_TrainID",
                table: "Schedules",
                column: "TrainID",
                principalTable: "Trains",
                principalColumn: "TrainID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Trains_TrainID",
                table: "Schedules");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Trains_TrainID",
                table: "Schedules",
                column: "TrainID",
                principalTable: "Trains",
                principalColumn: "TrainID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
