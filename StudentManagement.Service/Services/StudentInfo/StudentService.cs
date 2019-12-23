using AutoMapper;
using StudentManagement.Data;
using StudentManagement.Repository.StudentInfo;
using StudentManagement.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Service.Services.StudentInfo
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        public StudentService(IMapper mapper, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentModel>> GetStudentsAsync()
        {
            var stuents = await _studentRepository.GetStudentsAsync();
            return _mapper.Map<List<Student>, List<StudentModel>>(stuents);
        }

        public async Task<List<StudentModel>> GetStudentsBySearchAsync(string searchText, int? pageNumber, int pageSize)
        {
            var response = await _studentRepository.GetStudentsBySearchAsync(searchText, pageNumber, pageSize);
            return _mapper.Map<List<Student>,List<StudentModel>>(response);
        }

        public async Task<bool> InsertStudentAsync(StudentModel student)
        {
            student.Id = 0;
            var studentInformation = _mapper.Map<StudentModel, Student>(student);
            studentInformation.CreatedOn = DateTime.UtcNow;

            var response = await _studentRepository.InsertStudentAsync(studentInformation);
            return response;
        }

        public bool UpdateStudent(StudentModel student)
        {
            var studentInformation = _mapper.Map<StudentModel, Student>(student);
            var response = _studentRepository.UpdateStudent(studentInformation);
            return response;
        }

        public bool DeleteStudent(int studentId)
        {
            var response = _studentRepository.DeleteStudent(studentId);
            return response;
        }


    }
}
