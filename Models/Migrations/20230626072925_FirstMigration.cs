using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace norbit.crm.strashko.careertasks.backend.Models.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "CreatedOn", "ModifiedOn", "Name" },
                values: new object[] { new Guid("5485236e-bcfb-4d35-b9fb-b5798d542a91"), 0, new DateTime(2023, 6, 26, 12, 29, 25, 212, DateTimeKind.Local).AddTicks(6199), new DateTime(2023, 6, 26, 12, 29, 25, 212, DateTimeKind.Local).AddTicks(6209), "TestName1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
