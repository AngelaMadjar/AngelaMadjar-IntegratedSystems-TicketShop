using Microsoft.EntityFrameworkCore.Migrations;

namespace _181010_IS_Homework1.Data.Migrations
{
    public partial class aditionalforeignkeysadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_OrderedById",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketInOrder_Order_OrderId",
                table: "TicketInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketInOrder_Tickets_TicketId",
                table: "TicketInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInOrder",
                table: "TicketInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "TicketInOrder",
                newName: "TicketsInOrder");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_TicketInOrder_TicketId",
                table: "TicketsInOrder",
                newName: "IX_TicketsInOrder_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_OrderedById",
                table: "Orders",
                newName: "IX_Orders_OrderedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketsInOrder",
                table: "TicketsInOrder",
                columns: new[] { "OrderId", "TicketId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_OrderedById",
                table: "Orders",
                column: "OrderedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketsInOrder_Orders_OrderId",
                table: "TicketsInOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketsInOrder_Tickets_TicketId",
                table: "TicketsInOrder",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OrderedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketsInOrder_Orders_OrderId",
                table: "TicketsInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketsInOrder_Tickets_TicketId",
                table: "TicketsInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketsInOrder",
                table: "TicketsInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "TicketsInOrder",
                newName: "TicketInOrder");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_TicketsInOrder_TicketId",
                table: "TicketInOrder",
                newName: "IX_TicketInOrder_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderedById",
                table: "Order",
                newName: "IX_Order_OrderedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInOrder",
                table: "TicketInOrder",
                columns: new[] { "OrderId", "TicketId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_OrderedById",
                table: "Order",
                column: "OrderedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInOrder_Order_OrderId",
                table: "TicketInOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInOrder_Tickets_TicketId",
                table: "TicketInOrder",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
