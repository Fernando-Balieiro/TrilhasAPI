using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaminhadasAPI.Migrations
{
    /// <inheritdoc />
    public partial class TrocadoParametroDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descrition",
                table: "Walks",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Walks",
                newName: "Descrition");
        }
    }
}
