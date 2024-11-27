using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoaPortalApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameResidenceTableAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__ownerResidences",
                table: "_ownerResidences");

            migrationBuilder.RenameTable(
                name: "_ownerResidences",
                newName: "OwnerResidences");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnerResidences",
                table: "OwnerResidences",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnerResidences",
                table: "OwnerResidences");

            migrationBuilder.RenameTable(
                name: "OwnerResidences",
                newName: "_ownerResidences");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ownerResidences",
                table: "_ownerResidences",
                column: "Id");
        }
    }
}
