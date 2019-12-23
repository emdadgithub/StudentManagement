using StudentManagement.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Service.Services.StudentInfo
{
    public interface IStudentService
    {
        Task<List<StudentModel>> GetStudentsAsync();
        Task<List<StudentModel>> GetStudentsBySearchAsync(string searchText, int? pageNumber, int pageSize);
        Task<bool> InsertStudentAsync(StudentModel student);
        bool UpdateStudent(StudentModel student);
        bool DeleteStudent(int studentId);
    }
}
