using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationSys.Api.Migrations
{
    public partial class Reservation_Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var sql = @"
            IF OBJECT_ID('ReservationDelete', 'P') IS NOT NULL
            DROP PROC ReservationDelete
            GO
 
            CREATE PROCEDURE [dbo].[ReservationDelete]
                @ReservationId varchar(20)
            AS
            BEGIN
                SET NOCOUNT ON;
                DELETE FROM [dbo].[Reservations] WHERE Id=@ReservationId
            END";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC GetGuestsForDate");
        }
    }
}
