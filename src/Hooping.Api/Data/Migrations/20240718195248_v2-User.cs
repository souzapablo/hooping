using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hooping.Api.Data.Migrations;

/// <inheritdoc />
public partial class v2User : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<long>(
            name: "UserId",
            table: "Suppliers",
            type: "bigint",
            nullable: false,
            defaultValue: 0L);

        migrationBuilder.CreateTable(
            name: "User",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Email = table.Column<string>(type: "text", nullable: false),
                PasswordHash = table.Column<string>(type: "text", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_User", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Suppliers_UserId",
            table: "Suppliers",
            column: "UserId");

        migrationBuilder.AddForeignKey(
            name: "FK_Suppliers_User_UserId",
            table: "Suppliers",
            column: "UserId",
            principalTable: "User",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Suppliers_User_UserId",
            table: "Suppliers");

        migrationBuilder.DropTable(
            name: "User");

        migrationBuilder.DropIndex(
            name: "IX_Suppliers_UserId",
            table: "Suppliers");

        migrationBuilder.DropColumn(
            name: "UserId",
            table: "Suppliers");
    }
}
