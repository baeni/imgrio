using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace imgrio_api.Migrations
{
    /// <inheritdoc />
    public partial class RenameProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadedBy",
                table: "UserFiles",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "UploadedAt",
                table: "UserFiles",
                newName: "DateOfCreation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfCreation",
                table: "UserFiles",
                newName: "UploadedAt");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "UserFiles",
                newName: "UploadedBy");
        }
    }
}
