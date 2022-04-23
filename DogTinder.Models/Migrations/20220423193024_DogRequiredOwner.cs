using Microsoft.EntityFrameworkCore.Migrations;

namespace DogTinder.Models.Migrations
{
    public partial class DogRequiredOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDog_Dogs_DogId",
                table: "AppointmentDog");

            migrationBuilder.RenameColumn(
                name: "DogId",
                table: "AppointmentDog",
                newName: "DogsDogId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDog_DogId",
                table: "AppointmentDog",
                newName: "IX_AppointmentDog_DogsDogId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDog_Dogs_DogsDogId",
                table: "AppointmentDog",
                column: "DogsDogId",
                principalTable: "Dogs",
                principalColumn: "DogId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDog_Dogs_DogsDogId",
                table: "AppointmentDog");

            migrationBuilder.RenameColumn(
                name: "DogsDogId",
                table: "AppointmentDog",
                newName: "DogId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDog_DogsDogId",
                table: "AppointmentDog",
                newName: "IX_AppointmentDog_DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDog_Dogs_DogId",
                table: "AppointmentDog",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "DogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
