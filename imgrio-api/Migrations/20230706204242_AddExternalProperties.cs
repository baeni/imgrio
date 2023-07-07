using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace imgrio_api.Migrations
{
    /// <inheritdoc />
    public partial class AddExternalProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExternalUri",
                table: "UploadedFiles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsExternal",
                table: "UploadedFiles",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalUri",
                table: "UploadedFiles");

            migrationBuilder.DropColumn(
                name: "IsExternal",
                table: "UploadedFiles");
        }
    }
}
