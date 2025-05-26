using API.Uitilities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Uitilities.Repositories
{
    public interface IAdmissionRepository
    {
        Task<StudentDtos?> InsertStudentOnlineApp(StudentDtos student);
        Task<OnlineStudentAppDtos> GetOnlineApplicationByStudentCount();
        Task<List<StudentDtos>> GenerateApplicationTable(int page, int pageSize, string search, string status);
        Task<List<StudentDtos>> GetStudentById(long StudentId);
        Task<List<GPADtos>> InsertGpaOfStudent(List<GPADtos> reqList);
        Task<List<GPADtos>> GetStudentGpaById(long StudentID);
        Task<List<DocumentSubmittedDtos>> GetStudentDocsById(long StudentId);
    }
}
