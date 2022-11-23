using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace iis.Migrations.PostgreSqlDb
{
    public partial class AddFKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "HealthCondition",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Walk_AnimalId",
                table: "Walk",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Walk_VolunteerId",
                table: "Walk",
                column: "VolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_VeterinaryRecord_AnimalId",
                table: "VeterinaryRecord",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AnimalId",
                table: "Photo",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_OccupationId",
                table: "Employee",
                column: "OccupationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Occupation_OccupationId",
                table: "Employee",
                column: "OccupationId",
                principalTable: "Occupation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthCondition_Animal_AnimalId",
                table: "HealthCondition",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Animal_AnimalId",
                table: "Photo",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VeterinaryRecord_Animal_AnimalId",
                table: "VeterinaryRecord",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Walk_Animal_AnimalId",
                table: "Walk",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Walk_Volunteer_VolunteerId",
                table: "Walk",
                column: "VolunteerId",
                principalTable: "Volunteer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Occupation_OccupationId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthCondition_Animal_AnimalId",
                table: "HealthCondition");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Animal_AnimalId",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_VeterinaryRecord_Animal_AnimalId",
                table: "VeterinaryRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Walk_Animal_AnimalId",
                table: "Walk");

            migrationBuilder.DropForeignKey(
                name: "FK_Walk_Volunteer_VolunteerId",
                table: "Walk");

            migrationBuilder.DropIndex(
                name: "IX_Walk_AnimalId",
                table: "Walk");

            migrationBuilder.DropIndex(
                name: "IX_Walk_VolunteerId",
                table: "Walk");

            migrationBuilder.DropIndex(
                name: "IX_VeterinaryRecord_AnimalId",
                table: "VeterinaryRecord");

            migrationBuilder.DropIndex(
                name: "IX_Photo_AnimalId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Employee_OccupationId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "HealthCondition",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
