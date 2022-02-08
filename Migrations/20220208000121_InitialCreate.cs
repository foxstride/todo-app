using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Finished = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "Created", "Description", "Finished", "Title", "Updated" },
                values: new object[] { new Guid("00a87186-4c77-4402-82c6-8136b4b954bd"), new DateTime(2022, 2, 7, 17, 1, 21, 513, DateTimeKind.Local).AddTicks(8218), "The Second Description", false, "Second Todo Item", new DateTime(2022, 2, 7, 17, 1, 21, 513, DateTimeKind.Local).AddTicks(8220) });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "Created", "Description", "Finished", "Title", "Updated" },
                values: new object[] { new Guid("2a329d6a-876c-4027-8df8-7c4521839368"), new DateTime(2022, 2, 7, 4, 30, 0, 0, DateTimeKind.Unspecified), "Make a Todo app for Tonic", false, "Code Interview", new DateTime(2022, 2, 7, 4, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "Created", "Description", "Finished", "Title", "Updated" },
                values: new object[] { new Guid("457bedde-eddd-493f-b92e-7f29d6cefad6"), new DateTime(2022, 2, 7, 17, 1, 21, 513, DateTimeKind.Local).AddTicks(8143), "The First Description", true, "First Todo Item", new DateTime(2022, 2, 7, 17, 1, 21, 513, DateTimeKind.Local).AddTicks(8179) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");
        }
    }
}
