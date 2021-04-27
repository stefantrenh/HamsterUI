using Microsoft.EntityFrameworkCore.Migrations;

namespace HamsterData.Migrations
{
    public partial class StoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var storedProcedure = @"CREATE PROCEDURE AddToHistoryLog(@hamsterId int,@acticitiesId int,@timestamp datetime)
                                    AS
                                    INSERT INTO HistoryLogs
                                    Values (@hamsterId,@acticitiesId,@timestamp);";
            migrationBuilder.Sql(storedProcedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
