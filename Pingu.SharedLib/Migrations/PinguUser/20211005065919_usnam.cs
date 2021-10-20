using Microsoft.EntityFrameworkCore.Migrations;

namespace xPingu.SharedLib.Migrations.PinguUser
{
    public partial class usnam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "usrname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usrname",
                table: "AspNetUsers");
        }
    }
}
