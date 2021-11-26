using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApiData.Migrations
{
    public partial class TheMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    LengthInSeconds = table.Column<int>(type: "int", nullable: false),
                    AlbumId = table.Column<long>(type: "bigint", nullable: false),
                    ArtistId = table.Column<long>(type: "bigint", nullable: false),
                    GenreId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistSong",
                columns: table => new
                {
                    PlaylistId = table.Column<long>(type: "bigint", nullable: false),
                    SongId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistSong", x => new { x.PlaylistId, x.SongId });
                    table.ForeignKey(
                        name: "FK_PlaylistSong_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistSong_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Title", "Year" },
                values: new object[,]
                {
                    { 1L, "The Eminem Show", 2002 },
                    { 2L, "Feels So Good", 2002 },
                    { 3L, "Smash", 1994 },
                    { 4L, "The House", 2010 }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Eminem" },
                    { 2L, "Atomic Kitten" },
                    { 3L, "The Offspring" },
                    { 4L, "Katie Melua" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Rap rock" },
                    { 2L, "Pop" },
                    { 3L, "Punk rock" },
                    { 4L, "Progressive rock" }
                });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 5, 10, 20, 24, 1, 946, DateTimeKind.Local).AddTicks(3389), "Cool playlist" },
                    { 2L, new DateTime(2021, 8, 18, 20, 24, 1, 959, DateTimeKind.Local).AddTicks(8339), "Songs to listen to" },
                    { 3L, new DateTime(2021, 10, 7, 20, 24, 1, 959, DateTimeKind.Local).AddTicks(8365), "Music" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "AlbumId", "ArtistId", "GenreId", "LengthInSeconds", "Title" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, 1L, 251, "Business" },
                    { 2L, 1L, 1L, 1L, 323, "Square Dance" },
                    { 3L, 1L, 1L, 1L, 226, "Soldier" },
                    { 4L, 1L, 1L, 1L, 309, "Say What You Say" },
                    { 5L, 2L, 2L, 2L, 196, "It's OK!" },
                    { 6L, 2L, 2L, 2L, 210, "Feels So Good" },
                    { 7L, 2L, 2L, 2L, 240, "Walking on the Water" },
                    { 8L, 3L, 3L, 3L, 223, "Bad Habit" },
                    { 9L, 3L, 3L, 3L, 197, "Come Out and Play" },
                    { 10L, 3L, 3L, 3L, 642, "Smash" },
                    { 11L, 4L, 4L, 4L, 243, "The Flood" },
                    { 12L, 4L, 4L, 4L, 207, "A Happy Place" },
                    { 13L, 4L, 4L, 4L, 227, "A Moment of Madness" },
                    { 14L, 4L, 4L, 4L, 224, "Twisted" }
                });

            migrationBuilder.InsertData(
                table: "PlaylistSong",
                columns: new[] { "PlaylistId", "SongId" },
                values: new object[,]
                {
                    { 2L, 1L },
                    { 3L, 1L },
                    { 3L, 2L },
                    { 3L, 3L },
                    { 2L, 4L },
                    { 1L, 5L },
                    { 1L, 6L },
                    { 2L, 7L },
                    { 3L, 8L },
                    { 2L, 9L },
                    { 2L, 10L },
                    { 3L, 11L },
                    { 1L, 12L },
                    { 3L, 12L },
                    { 3L, 13L },
                    { 2L, 14L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSong_SongId",
                table: "PlaylistSong",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistSong");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
