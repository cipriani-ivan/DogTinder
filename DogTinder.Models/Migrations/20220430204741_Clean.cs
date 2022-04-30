using Microsoft.EntityFrameworkCore.Migrations;

namespace DogTinder.Models.Migrations
{
    public partial class Clean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Owners_OwnerId",
                table: "Dogs");

            migrationBuilder.DropTable(
                name: "AppointmentDog");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Places",
                newName: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Dogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Dogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_AppointmentId",
                table: "Dogs",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Appointments_AppointmentId",
                table: "Dogs",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Owners_OwnerId",
                table: "Dogs",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Appointments_AppointmentId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Owners_OwnerId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_AppointmentId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Dogs");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Places",
                newName: "Adress");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Dogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AppointmentDog",
                columns: table => new
                {
                    AppointmentsAppointmentId = table.Column<int>(type: "int", nullable: false),
                    DogsDogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDog", x => new { x.AppointmentsAppointmentId, x.DogsDogId });
                    table.ForeignKey(
                        name: "FK_AppointmentDog_Appointments_AppointmentsAppointmentId",
                        column: x => x.AppointmentsAppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentDog_Dogs_DogsDogId",
                        column: x => x.DogsDogId,
                        principalTable: "Dogs",
                        principalColumn: "DogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDog_DogsDogId",
                table: "AppointmentDog",
                column: "DogsDogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Owners_OwnerId",
                table: "Dogs",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
