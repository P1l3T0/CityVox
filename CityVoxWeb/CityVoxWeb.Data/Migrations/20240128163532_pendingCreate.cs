using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityVoxWeb.Data.Migrations
{
    public partial class pendingCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PendingReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReportTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResolvedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MunicipalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PendingReports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PendingReports_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PendingReports_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PendingReports_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("446c78ea-0251-4b2c-809f-6f30ba8afcf9"),
                column: "ConcurrencyStamp",
                value: "b70edb10-7a82-4fd8-abf1-3f42794599c1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("99ae3bb9-5e34-42ce-92e0-ea07d45fe244"),
                column: "ConcurrencyStamp",
                value: "c8799530-8cce-43b5-9f6b-f8b7f936edac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f86b1ef8-08cd-49a0-8112-18ffb9fea577"),
                column: "ConcurrencyStamp",
                value: "bef25ee2-97ea-4a71-a3fa-0e6d09a01b38");

            migrationBuilder.CreateIndex(
                name: "IX_PendingReports_MunicipalityId",
                table: "PendingReports",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PendingReports_PostId",
                table: "PendingReports",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PendingReports_ReportId",
                table: "PendingReports",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_PendingReports_UserId",
                table: "PendingReports",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PendingReports");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("446c78ea-0251-4b2c-809f-6f30ba8afcf9"),
                column: "ConcurrencyStamp",
                value: "d2e9a802-0a4d-4492-92a3-17f005946eb2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("99ae3bb9-5e34-42ce-92e0-ea07d45fe244"),
                column: "ConcurrencyStamp",
                value: "b6603ddd-d5e1-47ea-b57e-173d16f80d08");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f86b1ef8-08cd-49a0-8112-18ffb9fea577"),
                column: "ConcurrencyStamp",
                value: "f62e3935-fc6a-4a9d-bd35-2beb9ebabb8d");
        }
    }
}
