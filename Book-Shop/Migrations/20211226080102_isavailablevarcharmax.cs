using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Shop.Migrations
{
    public partial class isavailablevarcharmax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsAvailable",
                table: "Books",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Books",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");
        }
    }
}
