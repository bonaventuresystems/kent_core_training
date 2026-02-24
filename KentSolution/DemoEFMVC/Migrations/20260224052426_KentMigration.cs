using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEFMVC.Migrations
{
    /// <inheritdoc />
    public partial class KentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emp",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp", x => x.No);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjecID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjecID);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    TrainerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.TrainerID);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTrainer",
                columns: table => new
                {
                    SubjectsSubjecID = table.Column<int>(type: "int", nullable: false),
                    TrainersTrainerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTrainer", x => new { x.SubjectsSubjecID, x.TrainersTrainerID });
                    table.ForeignKey(
                        name: "FK_SubjectTrainer_Subject_SubjectsSubjecID",
                        column: x => x.SubjectsSubjecID,
                        principalTable: "Subject",
                        principalColumn: "SubjecID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTrainer_Trainer_TrainersTrainerID",
                        column: x => x.TrainersTrainerID,
                        principalTable: "Trainer",
                        principalColumn: "TrainerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTrainer_TrainersTrainerID",
                table: "SubjectTrainer",
                column: "TrainersTrainerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emp");

            migrationBuilder.DropTable(
                name: "SubjectTrainer");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Trainer");
        }
    }
}
