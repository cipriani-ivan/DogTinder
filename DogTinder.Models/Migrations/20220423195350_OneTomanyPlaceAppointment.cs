using Microsoft.EntityFrameworkCore.Migrations;

namespace DogTinder.Models.Migrations
{
    public partial class OneTomanyPlaceAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Places_PlaceId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PlaceId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PlaceId",
                table: "Appointments",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Places_PlaceId",
                table: "Appointments",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Places_PlaceId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PlaceId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PlaceId",
                table: "Appointments",
                column: "PlaceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Places_PlaceId",
                table: "Appointments",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
