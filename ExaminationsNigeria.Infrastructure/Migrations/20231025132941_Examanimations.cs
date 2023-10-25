using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationsNigeria.Infrastructure.Migrations
{
    public partial class Examanimations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastOnline",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ExaminationBodies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationBodies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExaminationBodyId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examinations_ExaminationBodies_ExaminationBodyId",
                        column: x => x.ExaminationBodyId,
                        principalTable: "ExaminationBodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExaminationQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionNumber = table.Column<int>(type: "int", nullable: true),
                    QuestionPoints = table.Column<int>(type: "int", nullable: false),
                    QuestionTypeId = table.Column<int>(type: "int", nullable: false),
                    ExaminationId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationQuestions_Examinations_ExaminationId",
                        column: x => x.ExaminationId,
                        principalTable: "Examinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExaminationQuestions_QuestionTypes_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExaminationSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamineeId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ExamineeId = table.Column<int>(type: "int", nullable: false),
                    ExaminationId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationSessions_AspNetUsers_ExamineeId1",
                        column: x => x.ExamineeId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExaminationSessions_Examinations_ExaminationId",
                        column: x => x.ExaminationId,
                        principalTable: "Examinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExaminationQuestionOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionTwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionFour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionFive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionAnswer = table.Column<int>(type: "int", nullable: false),
                    ExaminationQuestionId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationQuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationQuestionOptions_ExaminationQuestions_ExaminationQuestionId",
                        column: x => x.ExaminationQuestionId,
                        principalTable: "ExaminationQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExaminationAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeAnswered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExaminationQuestionId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    ExaminationSessionId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationAnswers_ExaminationQuestions_ExaminationQuestionId",
                        column: x => x.ExaminationQuestionId,
                        principalTable: "ExaminationQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExaminationAnswers_ExaminationSessions_ExaminationSessionId",
                        column: x => x.ExaminationSessionId,
                        principalTable: "ExaminationSessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExaminationResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoredPoints = table.Column<int>(type: "int", nullable: false),
                    TotalPoints = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExaminationSessionId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationResults_ExaminationSessions_ExaminationSessionId",
                        column: x => x.ExaminationSessionId,
                        principalTable: "ExaminationSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationAnswers_ExaminationQuestionId",
                table: "ExaminationAnswers",
                column: "ExaminationQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationAnswers_ExaminationSessionId",
                table: "ExaminationAnswers",
                column: "ExaminationSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationQuestionOptions_ExaminationQuestionId",
                table: "ExaminationQuestionOptions",
                column: "ExaminationQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationQuestions_ExaminationId",
                table: "ExaminationQuestions",
                column: "ExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationQuestions_QuestionTypeId",
                table: "ExaminationQuestions",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationResults_ExaminationSessionId",
                table: "ExaminationResults",
                column: "ExaminationSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_ExaminationBodyId",
                table: "Examinations",
                column: "ExaminationBodyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationSessions_ExaminationId",
                table: "ExaminationSessions",
                column: "ExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationSessions_ExamineeId1",
                table: "ExaminationSessions",
                column: "ExamineeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExaminationAnswers");

            migrationBuilder.DropTable(
                name: "ExaminationQuestionOptions");

            migrationBuilder.DropTable(
                name: "ExaminationResults");

            migrationBuilder.DropTable(
                name: "ExaminationQuestions");

            migrationBuilder.DropTable(
                name: "ExaminationSessions");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "ExaminationBodies");

            migrationBuilder.DropColumn(
                name: "JoinedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastOnline",
                table: "AspNetUsers");
        }
    }
}
