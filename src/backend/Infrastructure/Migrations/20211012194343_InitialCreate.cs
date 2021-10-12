using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    ReasonForTreatment = table.Column<string>(type: "TEXT", nullable: true),
                    HeathState = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    AccommodationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_Accommodation_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pet_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accommodation",
                columns: new[] { "Id", "Number", "State" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Accommodation",
                columns: new[] { "Id", "Number", "State" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.InsertData(
                table: "Accommodation",
                columns: new[] { "Id", "Number", "State" },
                values: new object[] { 3, 3, 1 });

            migrationBuilder.InsertData(
                table: "Accommodation",
                columns: new[] { "Id", "Number", "State" },
                values: new object[] { 4, 4, 1 });

            migrationBuilder.InsertData(
                table: "Accommodation",
                columns: new[] { "Id", "Number", "State" },
                values: new object[] { 5, 5, 1 });

            migrationBuilder.InsertData(
                table: "Accommodation",
                columns: new[] { "Id", "Number", "State" },
                values: new object[] { 6, 6, 1 });

            migrationBuilder.InsertData(
                table: "Accommodation",
                columns: new[] { "Id", "Number", "State" },
                values: new object[] { 8, 8, 1 });

            migrationBuilder.InsertData(
                table: "Accommodation",
                columns: new[] { "Id", "Number", "State" },
                values: new object[] { 7, 7, 1 });

            migrationBuilder.InsertData(
                table: "Accommodation",
                columns: new[] { "Id", "Number", "State" },
                values: new object[] { 9, 9, 1 });

            migrationBuilder.InsertData(
                table: "Accommodation",
                columns: new[] { "Id", "Number", "State" },
                values: new object[] { 10, 10, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_AccommodationId",
                table: "Pet",
                column: "AccommodationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pet_OwnerId",
                table: "Pet",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Accommodation");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
