using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPCoreApplication2023.Migrations
{
    /// <inheritdoc />
    public partial class movieaddedimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Movies");
        }
    }
}
