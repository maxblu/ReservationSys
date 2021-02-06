using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationSys.Api.Migrations
{
    public partial class IdNumberContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdNumber",
                table: "Contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Contacts");
        }
    }
}
