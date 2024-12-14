using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDeAulas.Migrations
{
    /// <inheritdoc />
    public partial class FixingReserves : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Classrooms_2",
                table: "Reserves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reserves",
                table: "Reserves");

            migrationBuilder.RenameColumn(
                name: "1",
                table: "Reserves",
                newName: "Hour");

            migrationBuilder.RenameColumn(
                name: "2",
                table: "Reserves",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "0",
                table: "Reserves",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_Reserves_2",
                table: "Reserves",
                newName: "IX_Reserves_RoomId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reserves",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reserves",
                table: "Reserves",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_Date_RoomId_Hour",
                table: "Reserves",
                columns: new[] { "Date", "RoomId", "Hour" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Classrooms_RoomId",
                table: "Reserves",
                column: "RoomId",
                principalTable: "Classrooms",
                principalColumn: "RoomNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Classrooms_RoomId",
                table: "Reserves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reserves",
                table: "Reserves");

            migrationBuilder.DropIndex(
                name: "IX_Reserves_Date_RoomId_Hour",
                table: "Reserves");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Reserves",
                newName: "2");

            migrationBuilder.RenameColumn(
                name: "Hour",
                table: "Reserves",
                newName: "1");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reserves",
                newName: "0");

            migrationBuilder.RenameIndex(
                name: "IX_Reserves_RoomId",
                table: "Reserves",
                newName: "IX_Reserves_2");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reserves",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reserves",
                table: "Reserves",
                columns: new[] { "0", "2", "1" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Classrooms_2",
                table: "Reserves",
                column: "2",
                principalTable: "Classrooms",
                principalColumn: "RoomNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
