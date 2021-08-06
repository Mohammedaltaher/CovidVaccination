using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidVaccination.Migrations
{
    public partial class addVaccination1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Patients_PatientId",
                table: "Vaccinations");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Vaccinations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Patients_PatientId",
                table: "Vaccinations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Patients_PatientId",
                table: "Vaccinations");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Vaccinations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Patients_PatientId",
                table: "Vaccinations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
