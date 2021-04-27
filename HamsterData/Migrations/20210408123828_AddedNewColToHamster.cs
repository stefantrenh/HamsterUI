using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HamsterData.Migrations
{
    public partial class AddedNewColToHamster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CheckedIn",
                table: "Hamsters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 1,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "KallegurraAktersnurra@Live.se", 784069182 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 2,
                column: "Phone",
                value: 762112010);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 3,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "LisaNilsson@Live.se", 769189451 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 4,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "JanHallgren@Live.se", 776309007 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 5,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "OttillaMurkwood@Live.se", 765759125 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 6,
                column: "Phone",
                value: 781109088);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 7,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "AnnaBook@Live.se", 789272912 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 8,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "PernillaWahlgren@Hotmail.com", 789992453 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 9,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "BiancaIngrosso@Live.se", 799324169 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 10,
                column: "Phone",
                value: 778314311);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 11,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "BobbyEwing@Yahoo.com", 793616485 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 12,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "HedyLamar@Yahoo.com", 778799921 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 13,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "BetteDavis@Yahoo.com", 767648251 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 14,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "KimCarnes@Yahoo.com", 797400223 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 15,
                column: "Phone",
                value: 789146089);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 16,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "MindyMendel@Hotmail.com", 766764279 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 17,
                column: "Phone",
                value: 796529157);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 18,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "PiaHansson@Yahoo.com", 786798448 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 19,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "BoEk@Live.se", 794442667 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 20,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "AnnaAl@Yahoo.com", 764223291 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 21,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "HansBjörk@Yahoo.com", 762955817 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 22,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "CaritaGran@Yahoo.com", 765305007 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 23,
                column: "Phone",
                value: 794859194);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 24,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "AnnaLinström@Live.se", 787546981 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 25,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "LennartBerg@Live.se", 784559784 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 26,
                column: "Phone",
                value: 794597446);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckedIn",
                table: "Hamsters");

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 1,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "KallegurraAktersnurra@Yahoo.com", 763239566 });

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
                columns: new[] { "Email", "Phone" },
                values: new object[] { "AnnaBook@Hotmail.com", 781464637 });

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
                column: "Phone",
                value: 760992104);

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
                columns: new[] { "Email", "Phone" },
                values: new object[] { "HedyLamar@Hotmail.com", 772112278 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 13,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "BetteDavis@Hotmail.com", 783447096 });

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
                column: "Phone",
                value: 774360692);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 16,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "MindyMendel@Yahoo.com", 797877088 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 17,
                column: "Phone",
                value: 773507854);

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
                columns: new[] { "Email", "Phone" },
                values: new object[] { "BoEk@Hotmail.com", 767896761 });

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
                columns: new[] { "Email", "Phone" },
                values: new object[] { "CaritaGran@Hotmail.com", 793577389 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: 23,
                column: "Phone",
                value: 774558066);

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
        }
    }
}
