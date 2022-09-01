using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HumansVsZombies_Backend.Migrations
{
    public partial class initialmigration : Migration
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
                    NwLat = table.Column<double>(type: "float", nullable: false),
                    NwLng = table.Column<double>(type: "float", nullable: false),
                    SeLat = table.Column<double>(type: "float", nullable: false),
                    SeLng = table.Column<double>(type: "float", nullable: false),
                    GameId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Game_Game_GameId1",
                        column: x => x.GameId1,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
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
                    SquadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_Chat_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Kill",
                columns: table => new
                {
                    KillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOfDeath = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Story = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lng = table.Column<double>(type: "float", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    KillerId = table.Column<int>(type: "int", nullable: false),
                    VictimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kill", x => x.KillId);
                    table.ForeignKey(
                        name: "FK_Kill_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kill_Player_KillerId",
                        column: x => x.KillerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kill_Player_VictimId",
                        column: x => x.VictimId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SquadMember",
                columns: table => new
                {
                    SquadMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    SquadId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquadMember", x => x.SquadMemberId);
                    table.ForeignKey(
                        name: "FK_SquadMember_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SquadCheckin_SquadMember_SquadMemberId",
                        column: x => x.SquadMemberId,
                        principalTable: "SquadMember",
                        principalColumn: "SquadMemberId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Game_GameId1",
                table: "Game",
                column: "GameId1");

            migrationBuilder.CreateIndex(
                name: "IX_Kill_GameId",
                table: "Kill",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Kill_KillerId",
                table: "Kill",
                column: "KillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Kill_VictimId",
                table: "Kill",
                column: "VictimId");

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
                name: "IX_SquadMember_GameId",
                table: "SquadMember",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadMember_PlayerId",
                table: "SquadMember",
                column: "PlayerId");

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
                name: "Kill");

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
