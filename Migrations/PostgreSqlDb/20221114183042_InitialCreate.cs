using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace iis.Migrations.PostgreSqlDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChipNumber = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Breed = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Birth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateOfArrival = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    About = table.Column<string>(type: "text", nullable: true),
                    Reserved = table.Column<bool>(type: "boolean", nullable: false),
                    Friendly = table.Column<int>(type: "integer", nullable: false),
                    ForBeginners = table.Column<bool>(type: "boolean", nullable: false),
                    Territory = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");
        }
    }
}
