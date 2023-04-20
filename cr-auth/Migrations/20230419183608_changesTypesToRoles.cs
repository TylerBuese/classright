using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cr_auth.Migrations
{
    /// <inheritdoc />
    public partial class changesTypesToRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Types",
                table: "Users",
                newName: "Roles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Roles",
                table: "Users",
                newName: "Types");
        }
    }
}
