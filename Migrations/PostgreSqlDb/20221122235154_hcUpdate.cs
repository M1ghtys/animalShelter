using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace iis.Migrations.PostgreSqlDb
{
    public partial class hcUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HealthCondition",
                table: "HealthCondition");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HealthCondition",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HealthCondition",
                table: "HealthCondition",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCondition_AnimalId",
                table: "HealthCondition",
                column: "AnimalId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HealthCondition",
                table: "HealthCondition");

            migrationBuilder.DropIndex(
                name: "IX_HealthCondition_AnimalId",
                table: "HealthCondition");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HealthCondition");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HealthCondition",
                table: "HealthCondition",
                column: "AnimalId");
        }
    }
}
