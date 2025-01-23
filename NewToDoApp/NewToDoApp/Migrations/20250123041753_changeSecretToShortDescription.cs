using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewToDoApp.Migrations
{
    /// <inheritdoc />
    public partial class changeSecretToShortDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Secret",
                table: "TodoItems",
                newName: "ShortDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "TodoItems",
                newName: "Secret");
        }
    }
}
