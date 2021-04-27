using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace HamsterData.Migrations
{
    public partial class initCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Cages",
                columns: table => new
                {
                    CageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cages", x => x.CageId);
                    table.CheckConstraint("CK_Cage_Size", "[Size] >= 0 AND [Size] <= 3");
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "WellnessCenters",
                columns: table => new
                {
                    WellnessCenterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WellnessCenters", x => x.WellnessCenterId);
                    table.CheckConstraint("CK_WellnessCenter_Size", "[Size] >= 0 AND [Size] <= 6");
                });

            migrationBuilder.CreateTable(
                name: "Hamsters",
                columns: table => new
                {
                    HamsterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    CageId = table.Column<int>(type: "int", nullable: true),
                    TimeWaited = table.Column<TimeSpan>(type: "time", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WellnessCenterId = table.Column<int>(type: "int", nullable: true),
                    ActivityId = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    HasWorkedOut = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamsters", x => x.HamsterId);
                    table.ForeignKey(
                        name: "FK_Hamsters_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hamsters_Cages_CageId",
                        column: x => x.CageId,
                        principalTable: "Cages",
                        principalColumn: "CageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hamsters_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hamsters_WellnessCenters_WellnessCenterId",
                        column: x => x.WellnessCenterId,
                        principalTable: "WellnessCenters",
                        principalColumn: "WellnessCenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoryLogs",
                columns: table => new
                {
                    HistoryLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HamsterId = table.Column<int>(type: "int", nullable: true),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryLogs", x => x.HistoryLogId);
                    table.ForeignKey(
                        name: "FK_HistoryLogs_Hamsters_HamsterId",
                        column: x => x.HamsterId,
                        principalTable: "Hamsters",
                        principalColumn: "HamsterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "Type" },
                values: new object[,]
                {
                    { 1, "Workout" },
                    { 2, "Move To Cage" },
                    { 3, "Arrival" },
                    { 4, "Checked Out" }
                });

            migrationBuilder.InsertData(
                table: "Cages",
                columns: new[] { "CageId", "IsMale", "Size" },
                values: new object[,]
                {
                    { 10, false, 0 },
                    { 8, false, 0 },
                    { 7, false, 0 },
                    { 6, false, 0 },
                    { 9, false, 0 },
                    { 4, true, 0 },
                    { 3, true, 0 },
                    { 2, true, 0 },
                    { 1, true, 0 },
                    { 5, true, 0 }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerId", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 16, "MindyMendel@Hotmail.com", "Mindy", "Mendel", 770971954 },
                    { 17, "GWHansson@Yahoo.com", "GW", "Hansson", 783562549 },
                    { 18, "PiaHansson@Yahoo.com", "Pia", "Hansson", 765430223 },
                    { 19, "BoEk@Yahoo.com", "Bo", "Ek", 794562456 },
                    { 20, "AnnaAl@Yahoo.com", "Anna", "Al", 772454069 },
                    { 22, "CaritaGran@Live.se", "Carita", "Gran", 770472523 },
                    { 23, "MiaEriksson@Live.se", "Mia", "Eriksson", 767032868 },
                    { 24, "AnnaLinström@Live.se", "Anna", "Linström", 775542481 },
                    { 25, "LennartBerg@Live.se", "Lennart", "Berg", 795990709 },
                    { 15, "Morkof@Yahoo.com", "Mork", "of", 791079263 },
                    { 21, "HansBjörk@Hotmail.com", "Hans", "Björk", 780414994 },
                    { 14, "KimCarnes@Live.se", "Kim", "Carnes", 775035950 },
                    { 7, "AnnaBook@Live.se", "Anna", "Book", 779493422 },
                    { 12, "HedyLamar@Hotmail.com", "Hedy", "Lamar", 784884480 },
                    { 11, "BobbyEwing@Hotmail.com", "Bobby", "Ewing", 785048707 },
                    { 10, "LorenzoLamas@Live.se", "Lorenzo", "Lamas", 789799255 },
                    { 9, "BiancaIngrosso@Yahoo.com", "Bianca", "Ingrosso", 772202138 },
                    { 8, "PernillaWahlgren@Live.se", "Pernilla", "Wahlgren", 769666870 },
                    { 26, "BoBergman@Live.se", "Bo", "Bergman", 785024079 },
                    { 6, "AnfersMurkwood@Yahoo.com", "Anfers", "Murkwood", 763455318 },
                    { 5, "OttillaMurkwood@Hotmail.com", "Ottilla", "Murkwood", 792021141 },
                    { 4, "JanHallgren@Live.se", "Jan", "Hallgren", 773850330 },
                    { 3, "LisaNilsson@Yahoo.com", "Lisa", "Nilsson", 794697551 },
                    { 2, "CarlHamilton@Live.se", "Carl", "Hamilton", 766588343 },
                    { 1, "KallegurraAktersnurra@Live.se", "Kallegurra", "Aktersnurra", 785425289 },
                    { 13, "BetteDavis@Hotmail.com", "Bette", "Davis", 780367026 }
                });

            migrationBuilder.InsertData(
                table: "WellnessCenters",
                columns: new[] { "WellnessCenterId", "Size" },
                values: new object[] { 1, 0 });

            migrationBuilder.InsertData(
                table: "Hamsters",
                columns: new[] { "HamsterId", "ActivityId", "Age", "CageId", "Gender", "HasWorkedOut", "Name", "OwnerId", "TimeWaited", "WellnessCenterId" },
                values: new object[,]
                {
                    { 1, null, 4, null, "M", false, "Rufus", 1, null, null },
                    { 28, null, 8, null, "M", false, "Marvel", 24, null, null },
                    { 27, null, 9, null, "K", false, "Mimmi", 23, null, null },
                    { 26, null, 110, null, "M", false, "Crawler", 22, null, null },
                    { 25, null, 12, null, "K", false, "Gittan", 21, null, null },
                    { 24, null, 14, null, "M", false, "Sauron", 20, null, null },
                    { 23, null, 15, null, "M", false, "Clint", 19, null, null },
                    { 22, null, 16, null, "K", false, "Neko", 18, null, null },
                    { 21, null, 16, null, "K", false, "Fiffi", 17, null, null },
                    { 20, null, 18, null, "K", false, "Ruby", 16, null, null },
                    { 19, null, 19, null, "K", false, "Kimber", 15, null, null },
                    { 18, null, 20, null, "K", false, "Amber", 14, null, null },
                    { 17, null, 21, null, "K", false, "Robin", 13, null, null },
                    { 16, null, 22, null, "M", false, "Bobo", 12, null, null },
                    { 15, null, 23, null, "M", false, "Beppe", 11, null, null },
                    { 14, null, 24, null, "M", false, "Bulle", 10, null, null },
                    { 13, null, 3, null, "K", false, "Malin", 9, null, null },
                    { 12, null, 3, null, "M", false, "Chivas", 8, null, null },
                    { 11, null, 4, null, "K", false, "Starlight", 7, null, null },
                    { 10, null, 4, null, "M", false, "Kurt", 7, null, null },
                    { 9, null, 5, null, "M", false, "Kalle", 6, null, null },
                    { 8, null, 6, null, "K", false, "Miss Diggy", 5, null, null },
                    { 7, null, 7, null, "K", false, "Mulan", 4, null, null },
                    { 6, null, 8, null, "K", false, "Sussi", 3, null, null },
                    { 5, null, 9, null, "M", false, "Sneaky", 3, null, null },
                    { 4, null, 10, null, "M", false, "Nibbler", 2, null, null },
                    { 3, null, 11, null, "M", false, "Fluff", 2, null, null },
                    { 2, null, 12, null, "K", false, "Lisa", 1, null, null },
                    { 29, null, 7, null, "M", false, "Storm", 25, null, null },
                    { 30, null, 6, null, "K", false, "Busan", 26, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_ActivityId",
                table: "Hamsters",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_CageId",
                table: "Hamsters",
                column: "CageId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_OwnerId",
                table: "Hamsters",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_WellnessCenterId",
                table: "Hamsters",
                column: "WellnessCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryLogs_HamsterId",
                table: "HistoryLogs",
                column: "HamsterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryLogs");

            migrationBuilder.DropTable(
                name: "Hamsters");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Cages");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "WellnessCenters");
        }
    }
}
