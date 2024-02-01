using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContainerToolDB.Migrations
{
    /// <inheritdoc />
    public partial class articleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageConversations_Conversations_ConversationId",
                table: "MessageConversations");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Files_AttachmentId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.RenameColumn(
                name: "ConversationId",
                table: "MessageConversations",
                newName: "OrderId");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Steps",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInformation",
                table: "Orders",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "AttachmentId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ArticleNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDirectLine = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsFastLine = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pallets = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_OrderId",
                table: "Articles",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageConversations_Orders_OrderId",
                table: "MessageConversations",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Files_AttachmentId",
                table: "Messages",
                column: "AttachmentId",
                principalTable: "Files",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageConversations_Orders_OrderId",
                table: "MessageConversations");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Files_AttachmentId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "AdditionalInformation",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "MessageConversations",
                newName: "ConversationId");

            migrationBuilder.AlterColumn<int>(
                name: "AttachmentId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversations_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_OrderId",
                table: "Conversations",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageConversations_Conversations_ConversationId",
                table: "MessageConversations",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Files_AttachmentId",
                table: "Messages",
                column: "AttachmentId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}