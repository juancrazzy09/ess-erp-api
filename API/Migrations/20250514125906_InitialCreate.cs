using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarangayTable",
                columns: table => new
                {
                    BrgyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipalityId = table.Column<long>(type: "bigint", nullable: true),
                    BrgyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarangayTable", x => x.BrgyId);
                });

            migrationBuilder.CreateTable(
                name: "CampusTable",
                columns: table => new
                {
                    CampusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampusTable", x => x.CampusId);
                });

            migrationBuilder.CreateTable(
                name: "DivisionTable",
                columns: table => new
                {
                    DivId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionTable", x => x.DivId);
                });

            migrationBuilder.CreateTable(
                name: "EducBGTable",
                columns: table => new
                {
                    EducBgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducBgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducBGTable", x => x.EducBgId);
                });

            migrationBuilder.CreateTable(
                name: "FathersTable",
                columns: table => new
                {
                    FatherId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: true),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReligionId = table.Column<long>(type: "bigint", nullable: true),
                    NationalityId = table.Column<long>(type: "bigint", nullable: true),
                    EducationalLevelId = table.Column<long>(type: "bigint", nullable: true),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployersAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Monthlyincome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LifeStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAlumnae = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolGraduated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FathersTable", x => x.FatherId);
                });

            migrationBuilder.CreateTable(
                name: "GuardianTable",
                columns: table => new
                {
                    GuardianId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: true),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isVerified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationShip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<long>(type: "bigint", nullable: true),
                    MunicipalityId = table.Column<long>(type: "bigint", nullable: true),
                    BrgyId = table.Column<long>(type: "bigint", nullable: true),
                    HomeStreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuardianTable", x => x.GuardianId);
                });

            migrationBuilder.CreateTable(
                name: "LevelTable",
                columns: table => new
                {
                    LevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivId = table.Column<int>(type: "int", nullable: true),
                    LevelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelTable", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "MothersTable",
                columns: table => new
                {
                    MotherId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: true),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReligionId = table.Column<long>(type: "bigint", nullable: true),
                    NationalityId = table.Column<long>(type: "bigint", nullable: true),
                    EducationalLevelId = table.Column<long>(type: "bigint", nullable: true),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployersAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Monthlyincome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LifeStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAlumnae = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolGraduated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MothersTable", x => x.MotherId);
                });

            migrationBuilder.CreateTable(
                name: "MunicipalityTable",
                columns: table => new
                {
                    MunicipalityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceId = table.Column<long>(type: "bigint", nullable: true),
                    MunicipalityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MunicipalityTable", x => x.MunicipalityId);
                });

            migrationBuilder.CreateTable(
                name: "NationalityTable",
                columns: table => new
                {
                    NationalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalityTable", x => x.NationalityId);
                });

            migrationBuilder.CreateTable(
                name: "ProvincesTable",
                columns: table => new
                {
                    ProvinceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvincesTable", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "ReligionTable",
                columns: table => new
                {
                    ReligionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReligionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReligionTable", x => x.ReligionId);
                });

            migrationBuilder.CreateTable(
                name: "StrandTable",
                columns: table => new
                {
                    StrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrandTable", x => x.StrandId);
                });

            migrationBuilder.CreateTable(
                name: "StudentAppFilesTable",
                columns: table => new
                {
                    FileId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: true),
                    StudentPic2x2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentBirthCert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentBaptismal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodMoral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentReportCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAppFilesTable", x => x.FileId);
                });

            migrationBuilder.CreateTable(
                name: "StudentAppTable",
                columns: table => new
                {
                    AppId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: true),
                    AppNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAppTable", x => x.AppId);
                });

            migrationBuilder.CreateTable(
                name: "StudentDocstable",
                columns: table => new
                {
                    DocsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: true),
                    TwoByTwoPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoByTwoPhotoSubmitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GoodMoral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodMoralSubmitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LatestReportCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestReportCardSubmitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ECD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ECDSubmitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GradeTenCert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeTenCertSubmitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Form137 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Form137Submitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GradeNineRepCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeNineRepCardSubmitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SSP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSPSubmitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PassPort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassPortSubmitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NCAE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NCAESubmitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PSA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PSASubmitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QVACert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QVACertSubmitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QVR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QVRSubmitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDocstable", x => x.DocsId);
                });

            migrationBuilder.CreateTable(
                name: "StudentTable",
                columns: table => new
                {
                    StudentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampusId = table.Column<int>(type: "int", nullable: true),
                    LevelId = table.Column<int>(type: "int", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    StrandId = table.Column<int>(type: "int", nullable: true),
                    StudentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    ReligionId = table.Column<long>(type: "bigint", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTable", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "UsersTable",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialRole = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTable", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarangayTable");

            migrationBuilder.DropTable(
                name: "CampusTable");

            migrationBuilder.DropTable(
                name: "DivisionTable");

            migrationBuilder.DropTable(
                name: "EducBGTable");

            migrationBuilder.DropTable(
                name: "FathersTable");

            migrationBuilder.DropTable(
                name: "GuardianTable");

            migrationBuilder.DropTable(
                name: "LevelTable");

            migrationBuilder.DropTable(
                name: "MothersTable");

            migrationBuilder.DropTable(
                name: "MunicipalityTable");

            migrationBuilder.DropTable(
                name: "NationalityTable");

            migrationBuilder.DropTable(
                name: "ProvincesTable");

            migrationBuilder.DropTable(
                name: "ReligionTable");

            migrationBuilder.DropTable(
                name: "StrandTable");

            migrationBuilder.DropTable(
                name: "StudentAppFilesTable");

            migrationBuilder.DropTable(
                name: "StudentAppTable");

            migrationBuilder.DropTable(
                name: "StudentDocstable");

            migrationBuilder.DropTable(
                name: "StudentTable");

            migrationBuilder.DropTable(
                name: "UsersTable");
        }
    }
}
