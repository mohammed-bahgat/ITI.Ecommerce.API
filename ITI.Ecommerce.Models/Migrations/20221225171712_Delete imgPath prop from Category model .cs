using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI.Ecommerce.Models.Migrations
{
    public partial class DeleteimgPathpropfromCategorymodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
