using API.Uitilities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Uitilities.Repositories
{
    public interface IAdmissionRepository
    {
        Task<StudentDtos?> InsertStudentOnlineApp(StudentDtos student);
        Task<List<StudentDtos>> GetOnlineApplicationByStudent(DataTableRequestDto req) ;
    }
}
