using Microsoft.EntityFrameworkCore.Migrations;

namespace iis.Migrations.SqliteIISDb
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
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

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
