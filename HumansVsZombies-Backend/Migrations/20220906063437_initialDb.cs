using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HumansVsZombies_Backend.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GameState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NwLat = table.Column<double>(type: "float", nullable: true),
                    NwLng = table.Column<double>(type: "float", nullable: true),
                    SeLat = table.Column<double>(type: "float", nullable: true),
                    SeLng = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    MissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsHumanVisible = table.Column<bool>(type: "bit", nullable: false),
                    IsZombieVisible = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.MissionId);
                    table.ForeignKey(
                        name: "FK_Mission_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Squad",
                columns: table => new
                {
                    SquadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SquadName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsHuman = table.Column<bool>(type: "bit", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squad", x => x.SquadId);
                    table.ForeignKey(
                        name: "FK_Squad_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsHuman = table.Column<bool>(type: "bit", nullable: false),
                    IsPatientZero = table.Column<bool>(type: "bit", nullable: false),
                    BiteCode = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Player_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Player_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    IsHumanGlobal = table.Column<bool>(type: "bit", nullable: false),
                    IsZombieGlobal = table.Column<bool>(type: "bit", nullable: false),
                    ChatTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    SquadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_Chat_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chat_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chat_Squad_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squad",
                        principalColumn: "SquadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SquadMember",
                columns: table => new
                {
                    SquadMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    SquadId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquadMember", x => x.SquadMemberId);
                    table.ForeignKey(
                        name: "FK_SquadMember_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SquadMember_Squad_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squad",
                        principalColumn: "SquadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SquadCheckin",
                columns: table => new
                {
                    SquadCheckinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lng = table.Column<double>(type: "float", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    SquadId = table.Column<int>(type: "int", nullable: false),
                    SquadMemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquadCheckin", x => x.SquadCheckinId);
                    table.ForeignKey(
                        name: "FK_SquadCheckin_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SquadCheckin_Squad_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squad",
                        principalColumn: "SquadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SquadCheckin_SquadMember_SquadMemberId",
                        column: x => x.SquadMemberId,
                        principalTable: "SquadMember",
                        principalColumn: "SquadMemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "GameId", "GameName", "GameState", "NwLat", "NwLng", "SeLat", "SeLng" },
                values: new object[,]
                {
                    { 1, "Left for Dead", "Registration", -26.66386, 25.283757999999999, -16.66686, 17.96686 },
                    { 2, "Walking Dead", "In progress", -16.66386, 15.283758000000001, -6.6668599999999998, 7.9668599999999996 },
                    { 3, "Days Gone", "Complete", -20.263860000000001, 21.283358, -13.66686, 12.99686 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "FirstName", "IsAdmin", "LastName" },
                values: new object[,]
                {
                    { 1, "Rebecka", false, "Ocampo Sandgren" },
                    { 2, "Fadi", true, "Akkaoui" },
                    { 3, "Negin", true, "Bakhtiarirad" },
                    { 4, "Betiel", false, "Yohannes" }
                });

            migrationBuilder.InsertData(
                table: "Mission",
                columns: new[] { "MissionId", "Description", "EndTime", "GameId", "IsHumanVisible", "IsZombieVisible", "MissionName", "StartTime" },
                values: new object[,]
                {
                    { 1, "Try your best to collect five types of medicine. Good Luck!", new DateTime(2022, 11, 30, 18, 32, 20, 0, DateTimeKind.Unspecified), 1, true, false, "Collect medicine", new DateTime(2022, 11, 30, 17, 32, 20, 0, DateTimeKind.Unspecified) },
                    { 2, "Try your best to collect five types of powerpotion. Good Luck!", new DateTime(2022, 11, 30, 15, 32, 20, 0, DateTimeKind.Unspecified), 1, false, true, "Collect powerpotion", new DateTime(2022, 11, 30, 14, 32, 20, 0, DateTimeKind.Unspecified) },
                    { 3, "Try your best to collect as many weapons as possible. Good Luck!", new DateTime(2022, 11, 30, 21, 32, 20, 0, DateTimeKind.Unspecified), 2, true, false, "Collect weapons", new DateTime(2022, 11, 30, 20, 32, 20, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "PlayerId", "BiteCode", "GameId", "IsHuman", "IsPatientZero", "UserId" },
                values: new object[,]
                {
                    { 1, 20861, 1, true, false, 1 },
                    { 2, 12139, 1, false, true, 2 },
                    { 3, 22135, 2, false, false, 3 },
                    { 4, 13224, 3, true, false, 4 }
                });

            migrationBuilder.InsertData(
                table: "Squad",
                columns: new[] { "SquadId", "GameId", "IsHuman", "SquadName" },
                values: new object[,]
                {
                    { 1, 1, true, "Best squad ever" },
                    { 3, 1, false, "Gang gang" },
                    { 2, 2, false, "Better than best squad" },
                    { 4, 3, true, "The beasts" }
                });

            migrationBuilder.InsertData(
                table: "Chat",
                columns: new[] { "ChatId", "ChatTime", "GameId", "IsHumanGlobal", "IsZombieGlobal", "Message", "PlayerId", "SquadId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 6, 8, 34, 37, 524, DateTimeKind.Local).AddTicks(6830), 1, false, false, "glhf", 1, null },
                    { 2, new DateTime(2022, 9, 6, 8, 34, 37, 524, DateTimeKind.Local).AddTicks(7308), 1, true, false, "gg", 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "SquadMember",
                columns: new[] { "SquadMemberId", "PlayerId", "Rank", "SquadId" },
                values: new object[,]
                {
                    { 4, 1, 10, 4 },
                    { 2, 2, 5, 2 },
                    { 1, 3, 4, 1 },
                    { 3, 4, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "SquadCheckin",
                columns: new[] { "SquadCheckinId", "EndTime", "GameId", "Lat", "Lng", "SquadId", "SquadMemberId", "StartTime" },
                values: new object[] { 2, new DateTime(2022, 9, 6, 8, 44, 37, 523, DateTimeKind.Local).AddTicks(9282), 2, -26.66386, 25.283757999999999, 2, 2, new DateTime(2022, 9, 6, 8, 34, 37, 523, DateTimeKind.Local).AddTicks(9274) });

            migrationBuilder.InsertData(
                table: "SquadCheckin",
                columns: new[] { "SquadCheckinId", "EndTime", "GameId", "Lat", "Lng", "SquadId", "SquadMemberId", "StartTime" },
                values: new object[] { 3, new DateTime(2022, 9, 6, 8, 44, 37, 523, DateTimeKind.Local).AddTicks(9288), 2, -26.66386, 25.283757999999999, 2, 2, new DateTime(2022, 9, 6, 8, 34, 37, 523, DateTimeKind.Local).AddTicks(9286) });

            migrationBuilder.InsertData(
                table: "SquadCheckin",
                columns: new[] { "SquadCheckinId", "EndTime", "GameId", "Lat", "Lng", "SquadId", "SquadMemberId", "StartTime" },
                values: new object[] { 1, new DateTime(2022, 9, 6, 8, 44, 37, 523, DateTimeKind.Local).AddTicks(8245), 1, -26.66386, 25.283757999999999, 1, 1, new DateTime(2022, 9, 6, 8, 34, 37, 519, DateTimeKind.Local).AddTicks(3797) });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_GameId",
                table: "Chat",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_PlayerId",
                table: "Chat",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_SquadId",
                table: "Chat",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_GameId",
                table: "Mission",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameId",
                table: "Player",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_UserId",
                table: "Player",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_GameId",
                table: "Squad",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadCheckin_GameId",
                table: "SquadCheckin",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadCheckin_SquadId",
                table: "SquadCheckin",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadCheckin_SquadMemberId",
                table: "SquadCheckin",
                column: "SquadMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadMember_PlayerId",
                table: "SquadMember",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SquadMember_SquadId",
                table: "SquadMember",
                column: "SquadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "Mission");

            migrationBuilder.DropTable(
                name: "SquadCheckin");

            migrationBuilder.DropTable(
                name: "SquadMember");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Squad");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
