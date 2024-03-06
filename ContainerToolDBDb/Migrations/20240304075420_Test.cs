using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContainerToolDB.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "ArticlesInDispatchRequests");

            migrationBuilder.DropTable(
                name: "PlanningSTS");

            migrationBuilder.DropTable(
                name: "STSArticles");

            migrationBuilder.DropTable(
                name: "DispachDateRequests");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropColumn(
                name: "ApprovedByCrCs",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApprovedByCrCsTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApprovedByCrTl",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApprovedByCrTlTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApprovedByPpCs",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApprovedByPpCsTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApprovedByPpPp",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApprovedByPpPpTime",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "ApprovedByCrTl",
                table: "TLInquiries",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedByCrTlTime",
                table: "TLInquiries",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PpId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ApprovedByCrCs",
                table: "CSInquiries",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedByCrCsTime",
                table: "CSInquiries",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDirectLine",
                table: "CSInquiries",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFastLine",
                table: "CSInquiries",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ArticlesCR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ArticleNumber = table.Column<int>(type: "int", nullable: false),
                    CsinquiryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlesCR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticlesCR_CSInquiries_CsinquiryId",
                        column: x => x.CsinquiryId,
                        principalTable: "CSInquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductionPlannings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApprovedByPPCS = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ApprovedByPPPP = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ApprovedByPPCSTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovedByPPPPTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionPlannings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ArticlesPP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ArticleNumber = table.Column<int>(type: "int", nullable: false),
                    MinHeightRequired = table.Column<int>(type: "int", nullable: false),
                    DesiredDeliveryDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ShortText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Factory = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nozzle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductionOrder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlannedOrder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InquiryForFixedOrder = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    InquiryForQuotation = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Pallets = table.Column<int>(type: "int", nullable: false),
                    ProductionPlanningId = table.Column<int>(type: "int", nullable: false),
                    Plant = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductionPlanningId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlesPP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticlesPP_ProductionPlannings_ProductionPlanningId",
                        column: x => x.ProductionPlanningId,
                        principalTable: "ProductionPlannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticlesPP_ProductionPlannings_ProductionPlanningId1",
                        column: x => x.ProductionPlanningId1,
                        principalTable: "ProductionPlannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PPId",
                table: "Orders",
                column: "PpId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticlesCR_CsinquiryId",
                table: "ArticlesCR",
                column: "CsinquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticlesPP_ProductionPlanningId",
                table: "ArticlesPP",
                column: "ProductionPlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticlesPP_ProductionPlanningId1",
                table: "ArticlesPP",
                column: "ProductionPlanningId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ProductionPlannings_TLId",
                table: "Orders",
                column: "TLId",
                principalTable: "ProductionPlannings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ProductionPlannings_TLId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ArticlesCR");

            migrationBuilder.DropTable(
                name: "ArticlesPP");

            migrationBuilder.DropTable(
                name: "ProductionPlannings");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PPId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApprovedByCrTl",
                table: "TLInquiries");

            migrationBuilder.DropColumn(
                name: "ApprovedByCrTlTime",
                table: "TLInquiries");

            migrationBuilder.DropColumn(
                name: "PpId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApprovedByCrCs",
                table: "CSInquiries");

            migrationBuilder.DropColumn(
                name: "ApprovedByCrCsTime",
                table: "CSInquiries");

            migrationBuilder.DropColumn(
                name: "IsDirectLine",
                table: "CSInquiries");

            migrationBuilder.DropColumn(
                name: "IsFastLine",
                table: "CSInquiries");

            migrationBuilder.AddColumn<bool>(
                name: "ApprovedByCrCs",
                table: "Orders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedByCrCsTime",
                table: "Orders",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ApprovedByCrTl",
                table: "Orders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedByCrTlTime",
                table: "Orders",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ApprovedByPpCs",
                table: "Orders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedByPpCsTime",
                table: "Orders",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ApprovedByPpPp",
                table: "Orders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedByPpPpTime",
                table: "Orders",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CsinquiryId = table.Column<int>(type: "int", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArticleNumber = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DesiredDeliveryDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Factory = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InquiryForFixedOrder = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    InquiryForQuotation = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDirectLine = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsFastLine = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MinHeigthRequired = table.Column<int>(type: "int", nullable: false),
                    Nozzle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pallets = table.Column<int>(type: "int", nullable: false),
                    PlannedOrder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Plant = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductionOrder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_CSInquiries_CsinquiryId",
                        column: x => x.CsinquiryId,
                        principalTable: "CSInquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DispachDateRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Annotation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Information = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkerId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispachDateRequests", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlanningSTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Annotation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Information = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkerId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningSTS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ArticlesInDispatchRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DispachDateRequestId = table.Column<int>(type: "int", nullable: false),
                    AmountNeeded = table.Column<int>(type: "int", nullable: false),
                    Articlenumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AskedDeal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DispachDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FixOrder = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MinLotSize = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Neededby = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlesInDispatchRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticlesInDispatchRequests_DispachDateRequests_DispachDateRe~",
                        column: x => x.DispachDateRequestId,
                        principalTable: "DispachDateRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "STSArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Info = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Jet = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Planinquiry = table.Column<int>(type: "int", nullable: false),
                    Productioninquiry = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STSArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_STSArticles_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_OrderId",
                table: "Articles",
                column: "CsinquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticlesInDispatchRequests_DispachDateRequestId",
                table: "ArticlesInDispatchRequests",
                column: "DispachDateRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_STSArticles_PlantId",
                table: "STSArticles",
                column: "PlantId");
        }
    }
}
