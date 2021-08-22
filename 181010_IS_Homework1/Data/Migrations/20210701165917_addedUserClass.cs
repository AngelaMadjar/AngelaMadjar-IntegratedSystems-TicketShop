using Microsoft.EntityFrameworkCore.Migrations;

namespace _181010_IS_Homework1.Data.Migrations
{
    public partial class addedUserClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketInShoppingCart_ShoppingCarts_CartId",
                table: "TicketInShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketInShoppingCart_Tickets_TicketId",
                table: "TicketInShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketInShoppingCart_TicketInShoppingCart_TicketInShoppingCartCartId_TicketInShoppingCartTicketId",
                table: "TicketInShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInShoppingCart",
                table: "TicketInShoppingCart");

            migrationBuilder.RenameTable(
                name: "TicketInShoppingCart",
                newName: "TicketsInShoppingCart");

            migrationBuilder.RenameIndex(
                name: "IX_TicketInShoppingCart_TicketInShoppingCartCartId_TicketInShoppingCartTicketId",
                table: "TicketsInShoppingCart",
                newName: "IX_TicketsInShoppingCart_TicketInShoppingCartCartId_TicketInShoppingCartTicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketInShoppingCart_TicketId",
                table: "TicketsInShoppingCart",
                newName: "IX_TicketsInShoppingCart_TicketId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserShoppingCartCartId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketsInShoppingCart",
                table: "TicketsInShoppingCart",
                columns: new[] { "CartId", "TicketId" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserShoppingCartCartId",
                table: "AspNetUsers",
                column: "UserShoppingCartCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShoppingCarts_UserShoppingCartCartId",
                table: "AspNetUsers",
                column: "UserShoppingCartCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketsInShoppingCart_ShoppingCarts_CartId",
                table: "TicketsInShoppingCart",
                column: "CartId",
                principalTable: "ShoppingCarts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketsInShoppingCart_Tickets_TicketId",
                table: "TicketsInShoppingCart",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketsInShoppingCart_TicketsInShoppingCart_TicketInShoppingCartCartId_TicketInShoppingCartTicketId",
                table: "TicketsInShoppingCart",
                columns: new[] { "TicketInShoppingCartCartId", "TicketInShoppingCartTicketId" },
                principalTable: "TicketsInShoppingCart",
                principalColumns: new[] { "CartId", "TicketId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShoppingCarts_UserShoppingCartCartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketsInShoppingCart_ShoppingCarts_CartId",
                table: "TicketsInShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketsInShoppingCart_Tickets_TicketId",
                table: "TicketsInShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketsInShoppingCart_TicketsInShoppingCart_TicketInShoppingCartCartId_TicketInShoppingCartTicketId",
                table: "TicketsInShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserShoppingCartCartId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketsInShoppingCart",
                table: "TicketsInShoppingCart");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserShoppingCartCartId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "TicketsInShoppingCart",
                newName: "TicketInShoppingCart");

            migrationBuilder.RenameIndex(
                name: "IX_TicketsInShoppingCart_TicketInShoppingCartCartId_TicketInShoppingCartTicketId",
                table: "TicketInShoppingCart",
                newName: "IX_TicketInShoppingCart_TicketInShoppingCartCartId_TicketInShoppingCartTicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketsInShoppingCart_TicketId",
                table: "TicketInShoppingCart",
                newName: "IX_TicketInShoppingCart_TicketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInShoppingCart",
                table: "TicketInShoppingCart",
                columns: new[] { "CartId", "TicketId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInShoppingCart_ShoppingCarts_CartId",
                table: "TicketInShoppingCart",
                column: "CartId",
                principalTable: "ShoppingCarts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInShoppingCart_Tickets_TicketId",
                table: "TicketInShoppingCart",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInShoppingCart_TicketInShoppingCart_TicketInShoppingCartCartId_TicketInShoppingCartTicketId",
                table: "TicketInShoppingCart",
                columns: new[] { "TicketInShoppingCartCartId", "TicketInShoppingCartTicketId" },
                principalTable: "TicketInShoppingCart",
                principalColumns: new[] { "CartId", "TicketId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
