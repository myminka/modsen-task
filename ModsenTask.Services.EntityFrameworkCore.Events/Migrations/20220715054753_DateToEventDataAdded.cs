using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModsenTask.Services.EntityFrameworkCore.Events.Migrations
{
    public partial class DateToEventDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresses_eventDatas_event_data_id",
                table: "addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_eventDatas",
                table: "eventDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                table: "addresses");

            migrationBuilder.RenameTable(
                name: "eventDatas",
                newName: "EventDatas");

            migrationBuilder.RenameTable(
                name: "addresses",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_addresses_event_data_id",
                table: "Addresses",
                newName: "IX_Addresses_event_data_id");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "EventDatas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventDatas",
                table: "EventDatas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_EventDatas_event_data_id",
                table: "Addresses",
                column: "event_data_id",
                principalTable: "EventDatas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_EventDatas_event_data_id",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventDatas",
                table: "EventDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "date",
                table: "EventDatas");

            migrationBuilder.RenameTable(
                name: "EventDatas",
                newName: "eventDatas");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_event_data_id",
                table: "addresses",
                newName: "IX_addresses_event_data_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_eventDatas",
                table: "eventDatas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                table: "addresses",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_eventDatas_event_data_id",
                table: "addresses",
                column: "event_data_id",
                principalTable: "eventDatas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
