using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopCenter.Infrastructure.EFCore.Migrations
{
    public partial class changeownerandsenderrelationtouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Users_OwnerId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketMessage_Users_SenderId",
                table: "TicketMessage");

            migrationBuilder.DropIndex(
                name: "IX_TicketMessage_SenderId",
                table: "TicketMessage");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_OwnerId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "TicketMessage");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TicketMessage",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Ticket",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMessage_UserId",
                table: "TicketMessage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Users_UserId",
                table: "Ticket",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMessage_Users_UserId",
                table: "TicketMessage",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Users_UserId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketMessage_Users_UserId",
                table: "TicketMessage");

            migrationBuilder.DropIndex(
                name: "IX_TicketMessage_UserId",
                table: "TicketMessage");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TicketMessage",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "TicketMessage",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Ticket",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMessage_SenderId",
                table: "TicketMessage",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OwnerId",
                table: "Ticket",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Users_OwnerId",
                table: "Ticket",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMessage_Users_SenderId",
                table: "TicketMessage",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
