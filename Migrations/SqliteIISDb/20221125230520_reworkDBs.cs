using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iis.Migrations.SqliteIISDb
{
    public partial class reworkDBs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Occupation_OccupationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Walk_AspNetUsers_VolunteerId1",
                table: "Walk");

            migrationBuilder.DropTable(
                name: "HealthCondition");

            migrationBuilder.DropTable(
                name: "Occupation");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OccupationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VolunteerId",
                table: "Walk");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OccupationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RecruitedDay",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "VolunteerId1",
                table: "Walk",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Walk_VolunteerId1",
                table: "Walk",
                newName: "IX_Walk_UserId1");

            migrationBuilder.AlterColumn<Guid>(
                name: "AnimalId",
                table: "Walk",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Walk",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Walk",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AnimalId",
                table: "VeterinaryRecord",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "VeterinaryRecord",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AnimalId",
                table: "Photo",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Photo",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Animal",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<bool>(
                name: "Castration",
                table: "Animal",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Animal",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Handicapped",
                table: "Animal",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Tattoo",
                table: "Animal",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Vaccinated",
                table: "Animal",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Walk_AspNetUsers_UserId1",
                table: "Walk",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walk_AspNetUsers_UserId1",
                table: "Walk");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Walk");

            migrationBuilder.DropColumn(
                name: "Castration",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "Handicapped",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "Tattoo",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "Vaccinated",
                table: "Animal");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Walk",
                newName: "VolunteerId1");

            migrationBuilder.RenameIndex(
                name: "IX_Walk_UserId1",
                table: "Walk",
                newName: "IX_Walk_VolunteerId1");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Walk",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Walk",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "VolunteerId",
                table: "Walk",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "VeterinaryRecord",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "VeterinaryRecord",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Photo",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Photo",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OccupationId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecruitedDay",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Animal",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "HealthCondition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false),
                    Castration = table.Column<bool>(type: "INTEGER", nullable: false),
                    Handicapped = table.Column<bool>(type: "INTEGER", nullable: false),
                    Others = table.Column<string>(type: "TEXT", nullable: true),
                    Tattoo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Vaccinated = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCondition_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Occupation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Pay = table.Column<double>(type: "REAL", nullable: false),
                    Permissions = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OccupationId",
                table: "AspNetUsers",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCondition_AnimalId",
                table: "HealthCondition",
                column: "AnimalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Occupation_OccupationId",
                table: "AspNetUsers",
                column: "OccupationId",
                principalTable: "Occupation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Walk_AspNetUsers_VolunteerId1",
                table: "Walk",
                column: "VolunteerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
