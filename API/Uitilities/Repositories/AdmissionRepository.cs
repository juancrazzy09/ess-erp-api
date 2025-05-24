using API.Models;
using API.Uitilities.DTOs;
using API.Uitilities.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

                    ////Insert student to UserTable (Master Table for all users)
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
        public async Task<OnlineStudentAppDtos> GetOnlineApplicationByStudentCount()
        {
            try
            {
                var statusCounts = await db.StudentAppTable
                                        .GroupBy(x => x.ActiveStatus)
                                        .Select(g => new { Status = g.Key, Count = g.Count() })
                                        .ToListAsync();

                int pendingCount = statusCounts.FirstOrDefault(x => x.Status == "P")?.Count ?? 0;
                int ongoingCount = statusCounts.FirstOrDefault(x => x.Status == "O")?.Count ?? 0;
                int enrolledCount = statusCounts.FirstOrDefault(x => x.Status == "Y")?.Count ?? 0;
                int totalCount = pendingCount + ongoingCount + enrolledCount;

                OnlineStudentAppDtos resCount = new OnlineStudentAppDtos
                {
                    PendingCount = pendingCount,
                    OngoingCount = ongoingCount,
                    EnrolledCount = enrolledCount,
                    TotalCount = totalCount
                };

                return resCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<StudentDtos>> GenerateApplicationTable(int page, int pageSize, string search, string status)
        {
            try
            {
                var query = from studentTable in db.StudentTable
                            join studentFile in db.StudentAppFilesTable
                                on studentTable.StudentId equals studentFile.StudentId into fileJoin
                            from studentFile in fileJoin.DefaultIfEmpty()

                            join studentApplication in db.StudentAppTable
                                on studentTable.StudentId equals studentApplication.StudentId into appJoin
                            from studentApplication in appJoin.DefaultIfEmpty()

                            join campusTable in db.CampusTable
                                on studentTable.CampusId equals campusTable.CampusId into campusJoin
                            from campusTable in campusJoin.DefaultIfEmpty()

                            join levelTable in db.LevelTable
                                on studentTable.LevelId equals levelTable.LevelId into levelJoin
                            from levelTable in levelJoin.DefaultIfEmpty()

                            join divisionTable in db.DivisionTable
                                on studentTable.DivId equals divisionTable.DivId into divisionJoin
                            from divisionTable in divisionJoin.DefaultIfEmpty()

                            join strandTable in db.StrandTable
                                on studentTable.StrandId equals strandTable.StrandId into strandJoin
                            from strandTable in strandJoin.DefaultIfEmpty()

                            where studentApplication.ActiveStatus == status

                            select new StudentDtos
                            {
                                StudentId = studentTable.StudentId,
                                ApplicationNumber = studentApplication.AppNumber,
                                Fname = studentTable.Fname,
                                Mname = studentTable.Mname,
                                Lname = studentTable.Lname,
                                CampusName = campusTable.CampusName,
                                LevelName = levelTable.LevelName,
                                DivName = divisionTable.DivName,
                                StrandName = strandTable.StrandName,
                                StudentType = studentTable.StudentType,
                                DateCreated = studentApplication.DateCreated,
                                DateModified = studentTable.DateModified,
                            };
                var totalRecords = query.Count();
                var paginatedList = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                return paginatedList;
                //return new DataTableResponseDto<StudentDtos>
                //{
                //    Draw = req.Draw,
                //    RecordsTotal = totalRecords,
                //    RecordsFiltered = totalRecords, // You can update this if filtering is applied
                //    Data = paginatedList
                //};
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<StudentDtos>> GetStudentById(long StudentId)
        {
            try
            {
                //query to get the student detail with 4 student tables
                var studentDetails = await (
                    from studentTable in db.StudentTable
                    where studentTable.StudentId == StudentId

                    join studentFile in db.StudentAppFilesTable
                        on studentTable.StudentId equals studentFile.StudentId into fileJoin
                    from studentFile in fileJoin.DefaultIfEmpty()

                    join studentApplication in db.StudentAppTable
                        on studentTable.StudentId equals studentApplication.StudentId into appJoin
                    from studentApplication in appJoin.DefaultIfEmpty()

                    join campusTable in db.CampusTable
                        on studentTable.CampusId equals campusTable.CampusId into campusJoin
                    from campusTable in campusJoin.DefaultIfEmpty()

                    join levelTable in db.LevelTable
                        on studentTable.LevelId equals levelTable.LevelId into levelJoin
                    from levelTable in levelJoin.DefaultIfEmpty()

                    join divisionTable in db.DivisionTable
                        on studentTable.DivId equals divisionTable.DivId into divisionJoin
                    from divisionTable in divisionJoin.DefaultIfEmpty()

                    join strandTable in db.StrandTable
                        on studentTable.StrandId equals strandTable.StrandId into strandJoin
                    from strandTable in strandJoin.DefaultIfEmpty()

                    join nationalityTable in db.NationalityTable
                        on studentTable.NationalityId equals nationalityTable.NationalityId into natJoin
                    from nationalityTable in natJoin.DefaultIfEmpty()

                    join religionTable in db.ReligionTable
                        on studentTable.ReligionId equals religionTable.ReligionId into religionJoin
                    from religionTable in religionJoin.DefaultIfEmpty()

                    select new
                    {
                        StudentId = studentTable.StudentId,
                        ApplicationNumber = studentApplication.AppNumber,
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
                        DateCreated = studentTable.DateCreated
                    }
                ).ToListAsync();

                //query for parent info of student
                var parentsDetails = await (
                    from fathersTable in db.FathersTable

                    join mothersTable in db.MothersTable
                        on fathersTable.StudentId equals mothersTable.StudentId into motherJoin
                    from mothersTable in motherJoin.DefaultIfEmpty() // LEFT JOIN

                    select new
                    {
                        StudentId = fathersTable.StudentId,
                        FatherId = fathersTable.FatherId,
                        F_Fname = fathersTable.Fname,
                        F_Mname = fathersTable.Mname,
                        F_Lname = fathersTable.Lname,
                        FathersName = fathersTable.Lname + ", " + fathersTable.Fname + " " + fathersTable.Mname,
                        FathersOccupation = fathersTable.Occupation,
                        FathersEmail = fathersTable.Email,
                        FathersPhone = fathersTable.MobilePhoneNo,
                        MotherId = mothersTable.MotherId,
                        M_Fname = mothersTable.Fname,
                        M_Mname = mothersTable.Mname,
                        M_Lname = mothersTable.Lname,
                        MothersMaidenName = mothersTable.Lname + ", " + mothersTable.Fname + " " + mothersTable.Mname,
                        MothersOccupation = mothersTable.Occupation,
                        MothersPhone = mothersTable.MobilePhoneNo
                    }
                ).ToListAsync();

                //query for guardian detail
                var guardianDetails = await (
                    from guardianTable in db.GuardianTable

                    join provinceTable in db.ProvincesTable
                        on guardianTable.ProvinceId equals provinceTable.ProvinceId into provinceJoin
                    from provinceTable in provinceJoin.DefaultIfEmpty()

                    join municipalityTable in db.MunicipalityTable
                        on guardianTable.MunicipalityId equals municipalityTable.MunicipalityId into muniJoin
                    from municipalityTable in muniJoin.DefaultIfEmpty()

                    join brgyTable in db.BarangayTable
                        on guardianTable.BrgyId equals brgyTable.BrgyId into brgyJoin
                    from brgyTable in brgyJoin.DefaultIfEmpty()

                    select new
                    {
                        GuardianId = guardianTable.GuardianId,
                        StudentId = guardianTable.StudentId,
                        C_Fname = guardianTable.Fname,
                        C_Mname = guardianTable.Mname,
                        C_Lname = guardianTable.Lname,
                        GuardianFullname = guardianTable.Lname + ", " + guardianTable.Fname + " " + guardianTable.Mname,
                        GuardianEmail = guardianTable.Email,
                        GuardianRelationship = guardianTable.Relationship,
                        HomePhoneNo = guardianTable.HomePhoneNo,
                        MobilePhoneNo = guardianTable.MobilePhoneNo,
                        GuardianAddress =
                            provinceTable.ProvinceName + ", " +
                            municipalityTable.MunicipalityName + ", " +
                            brgyTable.BrgyName,
                        GuardianHomeStreetAddress = guardianTable.HomeStreetAddress,
                    }
                ).ToListAsync();

                //joining all queries and paginate it to prevent to crash the API
                var finalQuery = (
                    from student in studentDetails

                    join parent in parentsDetails
                        on student.StudentId equals parent.StudentId into parentJoin
                    from parent in parentJoin.DefaultIfEmpty()

                    join guardian in guardianDetails
                        on student.StudentId equals guardian.StudentId into guardianJoin
                    from guardian in guardianJoin.DefaultIfEmpty()

                    select new StudentDtos
                    {
                        StudentId = student.StudentId,
                        ApplicationNumber = student.ApplicationNumber,
                        StudentNumber = student.StudentNumber,
                        Fname = student.Fname,
                        Mname = student.Mname,
                        Lname = student.Lname,
                        CampusId = student.CampusId,
                        CampusName = student.CampusName,
                        LevelId = student.LevelId,
                        LevelName = student.LevelName,
                        DivId = student.DivisionId,
                        DivName = student.DivisionName,
                        StrandId = student.StrandId,
                        StrandName = student.StrandName,
                        StudentType = student.StudentType,
                        NationalityId = student.NationalityId,
                        NationalityName = student.NationalityName,
                        ReligionId = student.ReligionId,
                        ReligionName = student.ReligionName,
                        Gender = student.Gender,
                        DateOfBirth = student.DateOfBirth,
                        PlaceOfBirth = student.PlaceOfBirth,
                        F_Fname = parent?.F_Fname,
                        F_Mname = parent?.F_Mname,
                        F_Lname = parent?.F_Lname,
                        FathersName = parent?.FathersName,
                        FathersOccupation = parent?.FathersOccupation,
                        FathersEmail = parent?.FathersEmail,
                        FathersPhone = parent?.FathersPhone,
                        M_Fname = parent?.M_Fname,
                        M_Mname = parent?.M_Mname,
                        M_Lname = parent?.M_Lname,
                        MothersMaidenName = parent?.MothersMaidenName,
                        MothersOccupation = parent?.MothersOccupation,
                        MothersPhone = parent?.MothersPhone,
                        C_Fname = guardian?.C_Fname,
                        C_Mname = guardian?.C_Mname,
                        C_Lname = guardian?.C_Lname,
                        ContactPerson = guardian?.GuardianFullname,
                        ContactPersonEmail = guardian?.GuardianEmail,
                        CPRelationship = guardian?.GuardianRelationship,
                        HomePhoneNo = guardian?.HomePhoneNo,
                        MobilePhoneNo = guardian?.MobilePhoneNo,
                        CPPresentAddress = guardian?.GuardianAddress,
                        HomeStreetAddress = guardian?.GuardianHomeStreetAddress,
                        ActiveStatus = student.ActiveStatus,
                        DateCreated = student.DateCreated
                    }
                ).ToList();

                return finalQuery;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}