using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BattleLog.API.Migrations
{
    /// <inheritdoc />
    public partial class updatetobattle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Battles",
                newName: "BattleDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BattleDate",
                table: "Battles",
                newName: "Birthday");
        }
    }
}
