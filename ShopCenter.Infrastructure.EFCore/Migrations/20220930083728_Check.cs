using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopCenter.Infrastructure.EFCore.Migrations
{
    public partial class Check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Users_UserId",
                table: "Seller");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Users_UserId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketMessage_Ticket_TicketId",
                table: "TicketMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketMessage_Users_UserId",
                table: "TicketMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketMessage",
                table: "TicketMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.RenameTable(
                name: "TicketMessage",
                newName: "TicketMessages");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "Seller",
                newName: "Sellers");

            migrationBuilder.RenameIndex(
                name: "IX_TicketMessage_UserId",
                table: "TicketMessages",
                newName: "IX_TicketMessages_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketMessage_TicketId",
                table: "TicketMessages",
                newName: "IX_TicketMessages_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_UserId",
                table: "Tickets",
                newName: "IX_Tickets_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Seller_UserId",
                table: "Sellers",
                newName: "IX_Sellers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketMessages",
                table: "TicketMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Users_UserId",
                table: "Sellers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMessages_Tickets_TicketId",
                table: "TicketMessages",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMessages_Users_UserId",
                table: "TicketMessages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Users_UserId",
                table: "Sellers");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketMessages_Tickets_TicketId",
                table: "TicketMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketMessages_Users_UserId",
                table: "TicketMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketMessages",
                table: "TicketMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "TicketMessages",
                newName: "TicketMessage");

            migrationBuilder.RenameTable(
                name: "Sellers",
                newName: "Seller");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UserId",
                table: "Ticket",
                newName: "IX_Ticket_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketMessages_UserId",
                table: "TicketMessage",
                newName: "IX_TicketMessage_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketMessages_TicketId",
                table: "TicketMessage",
                newName: "IX_TicketMessage_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Sellers_UserId",
                table: "Seller",
                newName: "IX_Seller_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketMessage",
                table: "TicketMessage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Users_UserId",
                table: "Seller",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Users_UserId",
                table: "Ticket",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMessage_Ticket_TicketId",
                table: "TicketMessage",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMessage_Users_UserId",
                table: "TicketMessage",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
