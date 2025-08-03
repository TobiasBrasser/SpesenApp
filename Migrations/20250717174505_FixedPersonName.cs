using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpesenApp.Migrations
{
    /// <inheritdoc />
    public partial class FixedPersonName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Personen",
                newName: "Vorname");

            migrationBuilder.AddColumn<string>(
                name: "Nachname",
                table: "Personen",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nachname",
                table: "Personen");

            migrationBuilder.RenameColumn(
                name: "Vorname",
                table: "Personen",
                newName: "Name");
        }
    }
}
