using Microsoft.EntityFrameworkCore.Migrations;

namespace DogTinder.Models.Migrations
{
    public partial class FixAppointmentFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Appointments_AppointmentID",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_AppointmentID",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "AppointmentID",
                table: "Dogs");

            migrationBuilder.AddColumn<int>(
                name: "DogID",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DogID",
                table: "Appointments",
                column: "DogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Dogs_DogID",
                table: "Appointments",
                column: "DogID",
                principalTable: "Dogs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Dogs_DogID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DogID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DogID",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentID",
                table: "Dogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_AppointmentID",
                table: "Dogs",
                column: "AppointmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Appointments_AppointmentID",
                table: "Dogs",
                column: "AppointmentID",
                principalTable: "Appointments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
