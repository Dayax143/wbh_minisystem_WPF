using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fortest.Migrations
{
    /// <inheritdoc />
    public partial class update_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "new_table",
                columns: table => new
                {
                    lora_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cor_supply = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    refference = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    taken_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    receipt_rv = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    lora_serial = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    plate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    note = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    users = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    assigned_to = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_new_table", x => x.lora_id);
                });

            migrationBuilder.CreateTable(
                name: "tblLora",
                columns: table => new
                {
                    lora_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cor_supply = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    refference = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    taken_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    receipt_rv = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    lora_serial = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    plate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    note = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ref_user = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    assigned_to = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    if_deleted = table.Column<string>(name: "if_deleted ", type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLora", x => x.lora_id);
                });

            migrationBuilder.CreateTable(
                name: "TblMreader",
                columns: table => new
                {
                    MId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MReaderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadingArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMreader", x => x.MId);
                });

            migrationBuilder.CreateTable(
                name: "tblPlates",
                columns: table => new
                {
                    plate_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cor_supply = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    refference = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ref_user = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    if_deleted = table.Column<string>(name: "if_deleted ", type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPlates", x => x.plate_id);
                });

            migrationBuilder.CreateTable(
                name: "TblUser",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    userName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    passWord = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    usertype = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    recoveryQuestion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    recoveryAnswer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    userStatus = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUser", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblRfms",
                columns: table => new
                {
                    RfmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfmMac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MreaderId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRfms", x => x.RfmId);
                    table.ForeignKey(
                        name: "FK_TblRfms_TblMreader_MreaderId",
                        column: x => x.MreaderId,
                        principalTable: "TblMreader",
                        principalColumn: "MId");
                });

            migrationBuilder.CreateTable(
                name: "TblHistory",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MreaderId = table.Column<int>(type: "int", nullable: true),
                    ReaderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfmId = table.Column<int>(type: "int", nullable: true),
                    RfmMac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblHistory", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_TblHistory_TblMreader_MreaderId",
                        column: x => x.MreaderId,
                        principalTable: "TblMreader",
                        principalColumn: "MId");
                    table.ForeignKey(
                        name: "FK_TblHistory_TblRfms_RfmId",
                        column: x => x.RfmId,
                        principalTable: "TblRfms",
                        principalColumn: "RfmId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblHistory_MreaderId",
                table: "TblHistory",
                column: "MreaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TblHistory_RfmId",
                table: "TblHistory",
                column: "RfmId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRfms_MreaderId",
                table: "TblRfms",
                column: "MreaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "new_table");

            migrationBuilder.DropTable(
                name: "TblHistory");

            migrationBuilder.DropTable(
                name: "tblLora");

            migrationBuilder.DropTable(
                name: "tblPlates");

            migrationBuilder.DropTable(
                name: "TblUser");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "TblRfms");

            migrationBuilder.DropTable(
                name: "TblMreader");
        }
    }
}
