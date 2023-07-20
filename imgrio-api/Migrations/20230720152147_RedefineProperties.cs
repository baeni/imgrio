using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace imgrio_api.Migrations
{
    /// <inheritdoc />
    public partial class RedefineProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UploadedFiles",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "IsExternal",
                table: "UploadedFiles",
                newName: "IsSelfHosted");

            migrationBuilder.RenameColumn(
                name: "ExternalUri",
                table: "UploadedFiles",
                newName: "Url");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "UploadedFiles",
                newName: "ExternalUri");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "UploadedFiles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "IsSelfHosted",
                table: "UploadedFiles",
                newName: "IsExternal");
        }
    }
}
