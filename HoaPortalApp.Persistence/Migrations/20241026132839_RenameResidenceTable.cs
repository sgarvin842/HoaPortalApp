using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoaPortalApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameResidenceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__ownderResidence",
                table: "_ownderResidence");

            migrationBuilder.RenameTable(
                name: "_ownderResidence",
                newName: "_ownerResidences");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ownerResidences",
                table: "_ownerResidences",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__ownerResidences",
                table: "_ownerResidences");

            migrationBuilder.RenameTable(
                name: "_ownerResidences",
                newName: "_ownderResidence");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ownderResidence",
                table: "_ownderResidence",
                column: "Id");
        }
    }
}
