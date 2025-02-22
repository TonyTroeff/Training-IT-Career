using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalOrganizer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedUniqueIndicesForGroupsAndLabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaskGroups_UserId",
                table: "TaskGroups");

            migrationBuilder.CreateIndex(
                name: "IX_TaskGroups_UserId_Name",
                table: "TaskGroups",
                columns: new[] { "UserId", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaskGroups_UserId_Name",
                table: "TaskGroups");

            migrationBuilder.CreateIndex(
                name: "IX_TaskGroups_UserId",
                table: "TaskGroups",
                column: "UserId");
        }
    }
}
