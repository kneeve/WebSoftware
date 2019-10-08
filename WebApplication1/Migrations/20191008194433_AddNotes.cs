using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class AddNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseNotes",
                columns: table => new
                {
                    CourseNoteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Note = table.Column<string>(nullable: true),
                    CourseInstanceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseNotes", x => x.CourseNoteID);
                    table.ForeignKey(
                        name: "FK_CourseNotes_Courses_CourseInstanceID",
                        column: x => x.CourseInstanceID,
                        principalTable: "Courses",
                        principalColumn: "CourseInstanceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningOutcomeNotes",
                columns: table => new
                {
                    LearningOutcomeNoteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Note = table.Column<string>(nullable: true),
                    LearningOutcomesID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningOutcomeNotes", x => x.LearningOutcomeNoteID);
                    table.ForeignKey(
                        name: "FK_LearningOutcomeNotes_LearningOutcomes_LearningOutcomesID",
                        column: x => x.LearningOutcomesID,
                        principalTable: "LearningOutcomes",
                        principalColumn: "LearningOutcomesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseNotes_CourseInstanceID",
                table: "CourseNotes",
                column: "CourseInstanceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcomeNotes_LearningOutcomesID",
                table: "LearningOutcomeNotes",
                column: "LearningOutcomesID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseNotes");

            migrationBuilder.DropTable(
                name: "LearningOutcomeNotes");
        }
    }
}
