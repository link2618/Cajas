using Microsoft.EntityFrameworkCore.Migrations;

namespace cajasqlserver.Migrations
{
    public partial class MigracionForanea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tcaja_ttipocaja_rtipocajaidtipocaja",
                table: "tcaja");

            migrationBuilder.DropForeignKey(
                name: "FK_tcarpeta_tcaja_rcajaidtcaja",
                table: "tcarpeta");

            migrationBuilder.DropIndex(
                name: "IX_tcarpeta_rcajaidtcaja",
                table: "tcarpeta");

            migrationBuilder.DropIndex(
                name: "IX_tcaja_rtipocajaidtipocaja",
                table: "tcaja");

            migrationBuilder.DropColumn(
                name: "rcajaidtcaja",
                table: "tcarpeta");

            migrationBuilder.DropColumn(
                name: "rtipocajaidtipocaja",
                table: "tcaja");

            migrationBuilder.CreateIndex(
                name: "IX_tcarpeta_caja",
                table: "tcarpeta",
                column: "caja");

            migrationBuilder.CreateIndex(
                name: "IX_tcaja_tipo",
                table: "tcaja",
                column: "tipo");

            migrationBuilder.AddForeignKey(
                name: "FK_tcaja_ttipocaja_tipo",
                table: "tcaja",
                column: "tipo",
                principalTable: "ttipocaja",
                principalColumn: "idtipocaja",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tcarpeta_tcaja_caja",
                table: "tcarpeta",
                column: "caja",
                principalTable: "tcaja",
                principalColumn: "idtcaja",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tcaja_ttipocaja_tipo",
                table: "tcaja");

            migrationBuilder.DropForeignKey(
                name: "FK_tcarpeta_tcaja_caja",
                table: "tcarpeta");

            migrationBuilder.DropIndex(
                name: "IX_tcarpeta_caja",
                table: "tcarpeta");

            migrationBuilder.DropIndex(
                name: "IX_tcaja_tipo",
                table: "tcaja");

            migrationBuilder.AddColumn<int>(
                name: "rcajaidtcaja",
                table: "tcarpeta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "rtipocajaidtipocaja",
                table: "tcaja",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tcarpeta_rcajaidtcaja",
                table: "tcarpeta",
                column: "rcajaidtcaja");

            migrationBuilder.CreateIndex(
                name: "IX_tcaja_rtipocajaidtipocaja",
                table: "tcaja",
                column: "rtipocajaidtipocaja");

            migrationBuilder.AddForeignKey(
                name: "FK_tcaja_ttipocaja_rtipocajaidtipocaja",
                table: "tcaja",
                column: "rtipocajaidtipocaja",
                principalTable: "ttipocaja",
                principalColumn: "idtipocaja",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tcarpeta_tcaja_rcajaidtcaja",
                table: "tcarpeta",
                column: "rcajaidtcaja",
                principalTable: "tcaja",
                principalColumn: "idtcaja",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
