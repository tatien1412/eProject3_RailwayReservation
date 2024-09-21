using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayTransaction.Migrations
{
    /// <inheritdoc />
    public partial class cash_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CashTransactionID",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CashTransactions",
                columns: table => new
                {
                    CashTransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOftransaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashReceived = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashRefunded = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashTransactions", x => x.CashTransactionID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CashTransactionID",
                table: "Reservations",
                column: "CashTransactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_CashTransactions_CashTransactionID",
                table: "Reservations",
                column: "CashTransactionID",
                principalTable: "CashTransactions",
                principalColumn: "CashTransactionID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_CashTransactions_CashTransactionID",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "CashTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CashTransactionID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CashTransactionID",
                table: "Reservations");
        }
    }
}
