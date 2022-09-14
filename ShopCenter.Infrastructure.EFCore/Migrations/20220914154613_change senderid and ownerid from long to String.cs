using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopCenter.Infrastructure.EFCore.Migrations
{
    public partial class changesenderidandowneridfromlongtoString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Users_OwnerId1",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketMessage_Users_SenderId1",
                table: "TicketMessage");

            migrationBuilder.DropIndex(
                name: "IX_TicketMessage_SenderId1",
                table: "TicketMessage");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_OwnerId1",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SenderId1",
                table: "TicketMessage");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "TicketMessage",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Ticket",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<long>(
                name: "SenderId",
                table: "TicketMessage",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "SenderId1",
                table: "TicketMessage",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "OwnerId",
                table: "Ticket",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Ticket",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMessage_SenderId1",
                table: "TicketMessage",
                column: "SenderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OwnerId1",
                table: "Ticket",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Users_OwnerId1",
                table: "Ticket",
                column: "OwnerId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMessage_Users_SenderId1",
                table: "TicketMessage",
                column: "SenderId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
