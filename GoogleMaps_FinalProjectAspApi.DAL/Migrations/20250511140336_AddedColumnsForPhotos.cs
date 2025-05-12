using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleMaps_FinalProjectAspApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumnsForPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUri",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PhotoUri",
                table: "Places");
        }
    }
}
