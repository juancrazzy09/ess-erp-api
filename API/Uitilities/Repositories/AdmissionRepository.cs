using API.Models;
using API.Uitilities.DTOs;
using API.Uitilities.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace API.Uitilities.Repositories
{
    public class AdmissionRepository : IAdmissionRepository
    {
        private readonly DBContext db;
        private readonly IConfiguration configuration;
        public AdmissionRepository(DBContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }
        public async Task<StudentDtos?> InsertStudentOnlineApp(StudentDtos student)
        {
            try
            {
                var userExist = db.StudentTable.Any(x => x.Fname == student.Fname && x.Mname == student.Mname && x.Lname == student.Lname);
                if (userExist)
                {
                    return null;
                }
                else
                {
                    //Condition for the others in religion
                    if(student.ReligionId.ToString() == "18")
                    {
                        //Insert new religion but it wont populate in dropdown 
                        ReligionTable religion = new ReligionTable
                        {
                            ReligionName = student.ReligionName,
                            DateCreated = student.DateCreated,
                            ActiveStatus = "P"
                        };
                        db.ReligionTable.Add(religion);
                        await db.SaveChangesAsync();
                        student.ReligionId = religion.ReligionId;

                        //Insert student with new religion name and id
                        StudentTable user = new StudentTable
                        {
                            Fname = student.Fname,
                            Mname = student.Mname,
                            Lname = student.Lname,
                            CampusId = student.CampusId,
                            LevelId = student.LevelId,
                            DivId = student.DivId,
                            StrandId = student.StrandId,
                            StudentType = "New",
                            NationalityId = student.NationalityId,
                            ReligionId = student.ReligionId,
                            Gender = student.Gender,
                            DateOfBirth = student.DateOfBirth,
                            ActiveStatus = "P",
                            DateCreated = DateTime.Now
                        };
                        db.StudentTable.Add(user);
                        await db.SaveChangesAsync();
                        student.StudentId = user.StudentId;
                    }
                    else
                    {
                        //Insert Student Online Application
                        StudentTable user = new StudentTable
                        {
                            Fname = student.Fname,
                            Mname = student.Mname,
                            Lname = student.Lname,
                            CampusId = student.CampusId,
                            LevelId = student.LevelId,
                            DivId = student.DivId,
                            StrandId = student.StrandId,
                            StudentType = "New",
                            NationalityId = student.NationalityId,
                            ReligionId = student.ReligionId,
                            Gender = student.Gender,
                            DateOfBirth = student.DateOfBirth,
                            ActiveStatus = "P",
                            DateCreated = DateTime.Now
                        };
                        db.StudentTable.Add(user);
                        await db.SaveChangesAsync();
                        student.StudentId = user.StudentId;
                    }

                    //Insert Application of student in Application Table
                    StudentAppTable application = new StudentAppTable
                    {
                        StudentId = student.StudentId,
                        AppNumber = DateTime.Now.ToString("yyyyMMdd") + "-0" + student.StudentId,
                        ActiveStatus = "P",
                        DateCreated = DateTime.Now
                    };
                    db.StudentAppTable.Add(application);
                    await db.SaveChangesAsync();
                    //Insert Student Files from Online Application
                    StudentAppFilesTable studentFiles = new StudentAppFilesTable
                    {
                        StudentId = student.StudentId,
                        StudentPic2x2 = student.StudentId + "_" + student.StudentPic2x2,
                        StudentBirthCert = student.StudentId + "_" + student.StudentBirthCert,
                        StudentBaptismal = student.StudentId + "_" + student.StudentBaptismal,
                        GoodMoral = student.StudentId + "_" + student.GoodMoral,
                        CurrentReportCard = student.StudentId + "_" + student.CurrentReportCard,
                        DateCreated = DateTime.Now
                    };
                    db.StudentAppFilesTable.Add(studentFiles);
                    await db.SaveChangesAsync();
                    //Insert doc files to Student Docs Table
                    StudentDocsTable studentSubmittedFiles = new StudentDocsTable
                    {
                        StudentId = studentFiles.StudentId,
                        TwoByTwoPhoto = studentFiles.StudentPic2x2,
                        TwoByTwoPhotoSubmitted = DateTime.Now,
                        GoodMoral = studentFiles.GoodMoral,
                        GoodMoralSubmitted = DateTime.Now,
                        LatestReportCard = studentFiles.CurrentReportCard,
                        LatestReportCardSubmitted = DateTime.Now,
                        DateCreated = DateTime.Now,
                        ActiveStatus = "Y"
                    };
                    db.StudentDocstable.Add(studentSubmittedFiles);
                    await db.SaveChangesAsync();
                    //Insert father's data of student in Table
                    FathersTable father = new FathersTable
                    {
                        StudentId = student.StudentId,
                        Fname = student.F_Fname,
                        Mname = student.F_Mname,
                        Lname = student.F_Lname,
                        Occupation = student.FathersOccupation,
                        Email = student.FathersEmail,
                        MobilePhoneNo = student.FathersPhone,
                        DateCreated = DateTime.Now,
                        ActiveStatus = "P",
                    };
                    db.FathersTable.Add(father);
                    await db.SaveChangesAsync();
                    //Insert mother's data of student in Table
                    MothersTable mother = new MothersTable
                    {
                        StudentId = student.StudentId,
                        Fname = student.M_Fname,
                        Mname = student.M_Mname,
                        Lname = student.M_Lname,
                        Occupation = student.MothersOccupation,
                        Email = student.MothersEmail,
                        MobilePhoneNo = student.MothersPhone,
                        DateCreated = DateTime.Now,
                        ActiveStatus = "P",
                    };
                    db.MothersTable.Add(mother);
                    await db.SaveChangesAsync();
                    //Insert student's guardian in Table
                    GuardianTable guardian = new GuardianTable
                    {
                        StudentId = student.StudentId,
                        Fname = student.M_Fname,
                        Mname = student.M_Mname,
                        Lname = student.M_Lname,
                        Email = student.ContactPersonEmail,
                        MobilePhoneNo = student.MobilePhoneNo,
                        HomePhoneNo = student.HomePhoneNo,
                        ProvinceId = student.ProvinceId,
                        MunicipalityId = student.MunicipalityId,
                        BrgyId = student.BrgyId,
                        DateCreated = DateTime.Now,
                        ActiveStatus = "P",
                    };
                    db.GuardianTable.Add(guardian);
                    await db.SaveChangesAsync();

                    //Insert student to UserTable (Master Table for all users)
                    //UserTable userDetails = new UserTable
                    //{
                    //    UserId = student.StudentId,
                    //    Fname = student.Fname,
                    //    Mname = student.Mname,
                    //    Lname = student.Lname,
                    //    Email = string.Concat(
                    //            student.Lname?.Trim().ToLower(), ".",
                    //            student.Fname?.Trim().ToLower(), "@ess.edu.ph"
                    //            ),
                    //    Password = student.DateOfBirth?.ToString("yyyy-MM-dd"),
                    //    DateCreated = DateTime.Now,
                    //    ActiveStatus = "P",
                    //    UserRole = "student",
                    //};
                    //db.UsersTable.Add(userDetails);
                    //await db.SaveChangesAsync();
                    return student;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the user: " + ex.Message);
            }
        }
        public async Task<List<StudentDtos>> GetOnlineApplicationByStudent(
           string keyword, int page = 1, int pageSize = 10 )
        {
            try
            {
                //query to get the student detail with 4 student tables
                var studentDetails = await ( from studentTable in db.StudentTable
                                      join studentFile in db.StudentAppFilesTable
                                          on studentTable.StudentId equals studentFile.StudentId
                                      join studentApplication in db.StudentAppTable
                                          on studentTable.StudentId equals studentApplication.StudentId
                                      join campusTable in db.CampusTable
                                          on studentTable.CampusId equals campusTable.CampusId
                                      join levelTable in db.LevelTable
                                          on studentTable.LevelId equals levelTable.LevelId
                                      join divisionTable in db.DivisionTable
                                          on studentTable.DivId equals divisionTable.DivId
                                      join strandTable in db.StrandTable
                                          on studentTable.StrandId equals strandTable.StrandId
                                      join nationalityTable in db.NationalityTable
                                          on studentTable.NationalityId equals nationalityTable.NationalityId
                                      join religionTable in db.ReligionTable
                                          on studentTable.ReligionId equals religionTable.ReligionId
                                       select new
                                       {
                                           StudentId = studentTable.StudentId,
                                           StudentNumber = studentTable.StudentNumber,
                                           Fname = studentTable.Fname,
                                           Mname = studentTable.Mname,
                                           Lname = studentTable.Lname,
                                           CampusId = studentTable.CampusId,
                                           CampusName = campusTable.CampusName,
                                           LevelId = levelTable.LevelId,
                                           LevelName = levelTable.LevelName,
                                           DivisionId = divisionTable.DivId,
                                           DivisionName = divisionTable.DivName,
                                           StrandId = strandTable.StrandId,
                                           StrandName = strandTable.StrandName,
                                           StudentType = studentTable.StudentType,
                                           NationalityId = nationalityTable.NationalityId,
                                           NationalityName = nationalityTable.NationalityName,
                                           ReligionId = religionTable.ReligionId,
                                           ReligionName = religionTable.ReligionName,
                                           Gender = studentTable.Gender,
                                           DateOfBirth = studentTable.DateOfBirth,
                                           PlaceOfBirth = studentTable.PlaceOfBirth,
                                           ActiveStatus = studentTable.ActiveStatus,
                                           DateCreated = studentTable.DateCreated,
                                       }
                                      ).ToListAsync();
                //query for parent info of student
                var parentsDetails = await (from fathersTable in db.FathersTable
                                            join mothersTable in db.MothersTable
                                               on fathersTable.StudentId equals mothersTable.StudentId
                                            select new
                                            {
                                                StudentId = fathersTable.StudentId,
                                                FatherId = fathersTable.FatherId,
                                                FathersName = fathersTable.Lname + ", " + fathersTable.Fname + " " + fathersTable.Mname,
                                                FathersOccupation = fathersTable.Occupation,
                                                FathersEmail = fathersTable.Email,
                                                FathersPhone = fathersTable.MobilePhoneNo,
                                                MotherId = mothersTable.MotherId,
                                                MothersMaidenName = mothersTable.Lname + ", " + mothersTable.Fname + " " + mothersTable.Mname,
                                                MothersOccupation = mothersTable.Occupation,
                                                MothersPhone = mothersTable.MobilePhoneNo,
                                            }
                                     )
                                     .ToListAsync();
                //query for guardian detail
                var guardianDetails = await ( from guardianTable in db.GuardianTable
                                              join provinceTable in db.ProvincesTable
                                                on guardianTable.ProvinceId equals provinceTable.ProvinceId
                                              join municipalityTable in db.MunicipalityTable
                                                on guardianTable.MunicipalityId equals municipalityTable.MunicipalityId
                                              join brgyTable in db.BarangayTable
                                                on guardianTable.BrgyId equals brgyTable.BrgyId
                                              select new
                                              {
                                                  GuardianId = guardianTable.GuardianId,
                                                  StudentId = guardianTable.StudentId,
                                                  GuardianFullname = guardianTable.Lname + ", " + guardianTable.Fname + " " + guardianTable.Mname,
                                                  GuardianEmail = guardianTable.Email,
                                                  GuardianRelationship = guardianTable.Relationship,
                                                  GuardianAddress = provinceTable.ProvinceName + ", " 
                                                                    + municipalityTable.MunicipalityName + ", "
                                                                    + brgyTable.BrgyName + ", "
                                                                    + guardianTable.HomeStreetAddress
                                              }
                                            ).ToListAsync();
                //joining all queries and paginate it to prevent to crash the API
                var finalQuery = (from studentFinalTable in studentDetails
                                   join parentFinaltable in parentsDetails
                                       on studentFinalTable.StudentId equals parentFinaltable.StudentId
                                   join guardianFinalTable in guardianDetails
                                       on studentFinalTable.StudentId equals guardianFinalTable.StudentId
                                   select new StudentDtos
                                   {
                                       StudentId = studentFinalTable.StudentId,
                                       StudentNumber = studentFinalTable.StudentNumber,
                                       Fname = studentFinalTable.Fname,
                                       Mname = studentFinalTable.Mname,
                                       Lname = studentFinalTable.Lname,
                                       CampusId = studentFinalTable.CampusId,
                                       CampusName = studentFinalTable.CampusName,
                                       LevelId = studentFinalTable.LevelId,
                                       LevelName = studentFinalTable.LevelName,
                                       DivId = studentFinalTable.DivisionId,
                                       DivName = studentFinalTable.DivisionName,
                                       StrandId = studentFinalTable.StrandId,
                                       StrandName = studentFinalTable.StrandName,
                                       StudentType = studentFinalTable.StudentType,
                                       NationalityId = studentFinalTable.NationalityId,
                                       NationalityName = studentFinalTable.NationalityName,
                                       ReligionId = studentFinalTable.ReligionId,
                                       ReligionName = studentFinalTable.ReligionName,
                                       Gender = studentFinalTable.Gender,
                                       DateOfBirth = studentFinalTable.DateOfBirth,
                                       PlaceOfBirth = studentFinalTable.PlaceOfBirth,
                                       FathersName = parentFinaltable.FathersName,
                                       FathersOccupation = parentFinaltable.FathersOccupation,
                                       FathersEmail = parentFinaltable.FathersEmail,
                                       FathersPhone = parentFinaltable.FathersPhone,
                                       MothersMaidenName = parentFinaltable.MothersMaidenName,
                                       MothersOccupation = parentFinaltable.MothersOccupation,
                                       MothersPhone = parentFinaltable.MothersPhone,
                                       ContactPerson = guardianFinalTable.GuardianFullname,
                                       ContactPersonEmail = guardianFinalTable.GuardianEmail,
                                       CPRelationship = guardianFinalTable.GuardianRelationship,
                                       CPPresentAddress = guardianFinalTable.GuardianAddress,
                                       ActiveStatus = studentFinalTable.ActiveStatus,
                                       DateCreated = studentFinalTable.DateCreated,
                                   }
                                  )
                                  .Skip((page - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToList(); ;

                return finalQuery;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}