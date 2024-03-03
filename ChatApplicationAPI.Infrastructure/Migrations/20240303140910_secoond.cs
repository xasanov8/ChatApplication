using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApplicationAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class secoond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeId",
                table: "SendMessages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SendMessages");

            migrationBuilder.AddColumn<string>(
                name: "MeUsername",
                table: "SendMessages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YouUsername",
                table: "SendMessages",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeUsername",
                table: "SendMessages");

            migrationBuilder.DropColumn(
                name: "YouUsername",
                table: "SendMessages");

            migrationBuilder.AddColumn<int>(
                name: "MeId",
                table: "SendMessages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SendMessages",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
