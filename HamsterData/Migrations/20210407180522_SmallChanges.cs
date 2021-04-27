using Microsoft.EntityFrameworkCore.Migrations;

namespace HamsterData.Migrations
{
    public partial class SmallChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryLogs_Hamsters_HamsterId",
                table: "HistoryLogs");

            migrationBuilder.AlterColumn<int>(
                name: "HamsterId",
                table: "HistoryLogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 1,
                column: "Phone",
                value: 763239566);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 2,
                column: "Phone",
                value: 760769371);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 3,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "LisaNilsson@Yahoo.com", 777576944 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 4,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "JanHallgren@Yahoo.com", 786970748 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 5,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "OttillaMurkwood@Yahoo.com", 786713080 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 6,
                column: "Phone",
                value: 768696031);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 7,
                column: "Phone",
                value: 781464637);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 8,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "PernillaWahlgren@Live.se", 799946964 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 9,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "BiancaIngrosso@Yahoo.com", 791845456 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 10,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "LorenzoLamas@Live.se", 760992104 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 11,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "BobbyEwing@Hotmail.com", 767557295 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 12,
                column: "Phone",
                value: 772112278);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 13,
                column: "Phone",
                value: 783447096);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 14,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "KimCarnes@Hotmail.com", 774368228 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 15,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "Morkof@Live.se", 774360692 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 16,
                column: "Phone",
                value: 797877088);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 17,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "GWHansson@Hotmail.com", 773507854 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 18,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "PiaHansson@Hotmail.com", 795328224 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 19,
                column: "Phone",
                value: 767896761);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 20,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "AnnaAl@Hotmail.com", 782618634 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 21,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "HansBjörk@Hotmail.com", 779633639 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 22,
                column: "Phone",
                value: 793577389);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 23,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "MiaEriksson@Yahoo.com", 774558066 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 24,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "AnnaLinström@Yahoo.com", 782614634 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 25,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "LennartBerg@Hotmail.com", 782291709 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 26,
                column: "Phone",
                value: 760402647);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryLogs_Hamsters_HamsterId",
                table: "HistoryLogs",
                column: "HamsterId",
                principalTable: "Hamsters",
                principalColumn: "HamsterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryLogs_Hamsters_HamsterId",
                table: "HistoryLogs");

            migrationBuilder.AlterColumn<int>(
                name: "HamsterId",
                table: "HistoryLogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 1,
                column: "Phone",
                value: 777020037);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 2,
                column: "Phone",
                value: 782269627);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 3,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "LisaNilsson@Hotmail.com", 765628751 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 4,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "JanHallgren@Hotmail.com", 788317156 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 5,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "OttillaMurkwood@Hotmail.com", 774262214 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 6,
                column: "Phone",
                value: 779131998);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 7,
                column: "Phone",
                value: 784477976);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 8,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "PernillaWahlgren@Yahoo.com", 764087496 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 9,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "BiancaIngrosso@Hotmail.com", 771878877 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 10,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "LorenzoLamas@Yahoo.com", 778292069 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 11,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "BobbyEwing@Yahoo.com", 797392135 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 12,
                column: "Phone",
                value: 772932425);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 13,
                column: "Phone",
                value: 799184280);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 14,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "KimCarnes@Live.se", 797361776 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 15,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "Morkof@Hotmail.com", 762335403 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 16,
                column: "Phone",
                value: 783535257);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 17,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "GWHansson@Live.se", 765522983 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 18,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "PiaHansson@Yahoo.com", 784874095 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 19,
                column: "Phone",
                value: 778233049);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 20,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "AnnaAl@Yahoo.com", 787354054 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 21,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "HansBjörk@Yahoo.com", 786130071 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 22,
                column: "Phone",
                value: 789211657);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 23,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "MiaEriksson@Live.se", 781900004 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 24,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "AnnaLinström@Hotmail.com", 774494047 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 25,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "LennartBerg@Live.se", 785033011 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 26,
                column: "Phone",
                value: 768953077);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryLogs_Hamsters_HamsterId",
                table: "HistoryLogs",
                column: "HamsterId",
                principalTable: "Hamsters",
                principalColumn: "HamsterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
