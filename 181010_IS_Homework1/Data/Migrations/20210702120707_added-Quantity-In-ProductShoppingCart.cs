using Microsoft.EntityFrameworkCore.Migrations;

namespace _181010_IS_Homework1.Data.Migrations
{
    public partial class addedQuantityInProductShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketsInShoppingCart_TicketsInShoppingCart_TicketInShoppingCartCartId_TicketInShoppingCartTicketId",
                table: "TicketsInShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_TicketsInShoppingCart_TicketInShoppingCartCartId_TicketInShoppingCartTicketId",
                table: "TicketsInShoppingCart");

            migrationBuilder.DropColumn(
                name: "TicketInShoppingCartCartId",
                table: "TicketsInShoppingCart");

            migrationBuilder.DropColumn(
                name: "TicketInShoppingCartTicketId",
                table: "TicketsInShoppingCart");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "TicketsInShoppingCart",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "TicketsInShoppingCart");

            migrationBuilder.AddColumn<int>(
                name: "TicketInShoppingCartCartId",
                table: "TicketsInShoppingCart",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketInShoppingCartTicketId",
                table: "TicketsInShoppingCart",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketsInShoppingCart_TicketInShoppingCartCartId_TicketInShoppingCartTicketId",
                table: "TicketsInShoppingCart",
                columns: new[] { "TicketInShoppingCartCartId", "TicketInShoppingCartTicketId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TicketsInShoppingCart_TicketsInShoppingCart_TicketInShoppingCartCartId_TicketInShoppingCartTicketId",
                table: "TicketsInShoppingCart",
                columns: new[] { "TicketInShoppingCartCartId", "TicketInShoppingCartTicketId" },
                principalTable: "TicketsInShoppingCart",
                principalColumns: new[] { "CartId", "TicketId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
