using Microsoft.EntityFrameworkCore.Migrations;

namespace _181010_IS_Homework1.Repository.Migrations
{
    public partial class quantityaddedinticketInOrdermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "TicketsInOrder",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "TicketsInOrder");
        }
    }
}
