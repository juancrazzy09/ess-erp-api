using API.Uitilities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Uitilities.Repositories
{
    public interface IAdmissionRepository
    {
        Task<StudentDtos?> InsertStudentOnlineApp(StudentDtos student);
        Task<List<StudentDtos>> GetOnlineApplicationByStudent(string keyword, int page = 1, int pageSize = 10) ;
    }
}
