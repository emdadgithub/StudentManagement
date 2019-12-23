using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repository.StudentInfo
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _dbContext;
        public StudentRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(d => d.Id == studentId);
            return student;
        }

        public async Task<List<Student>> GetStudentsBySearchAsync(string searchText,int? pageNumber,int pageSize)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                var students = _dbContext.Students.Where(s => s.Name.ToLower().Contains(searchText)
                                       || s.Email.Contains(searchText)
                                       || s.FathersName.ToLower().Contains(searchText)
                                       || s.MothersName.ToLower().Contains(searchText));

                var response = await PaginatedList<Student>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize);
                return response;
            }
           
            return null;
        }
        public async Task<List<Student>> GetStudentsAsync()
        {
            var students = await _dbContext.Students.ToListAsync();
            return students;
        }

        public async Task<bool> InsertStudentAsync(Student student)
        {
            _dbContext.Add(student);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public bool UpdateStudent(Student student)
        {
            var studentInfo = _dbContext.Students.FirstOrDefault(v => v.Id == student.Id);
            if (studentInfo != null)
            {
                studentInfo.Name = student.Name;
                studentInfo.RollNo = student.RollNo;
                studentInfo.PhoneNo = student.PhoneNo;
                studentInfo.Address = student.Address;
                studentInfo.Email = student.Email;
                studentInfo.FathersName = student.FathersName;
                studentInfo.MothersName = student.MothersName;
            }

            _dbContext.Students.Attach(studentInfo);
            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteStudent(int studentId)
        {
            var studentInfo = _dbContext.Students.FirstOrDefault(v => v.Id == studentId);
            if (studentInfo != null)
            {
                _dbContext.Students.Remove(studentInfo);
                return _dbContext.SaveChanges() > 0;
            }

            return false;
        }
    }
}
