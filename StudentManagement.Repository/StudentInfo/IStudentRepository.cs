using StudentManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repository.StudentInfo
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<List<Student>> GetStudentsAsync();
        Task<List<Student>> GetStudentsBySearchAsync(string searchText, int? pageNumber, int pageSize);
        Task<bool> InsertStudentAsync(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(int studentId);
    }
}
