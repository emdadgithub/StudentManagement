using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Service.Model;
using StudentManagement.Service.Services.StudentInfo;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("students")]
        public async Task<List<StudentModel>> GetStudents()
        {
            var response = await _studentService.GetStudentsAsync();
            return response;
        }

        [HttpPost]
        [Route("studentSearch")]
        public async Task<List<StudentModel>> GetStudentsBySearchAsync(StudentModel student)
        {
            var response = await _studentService.GetStudentsBySearchAsync(student.SearchText, student.PageNumber, student.PageSize);
            return response;
        }

        [HttpPost]
        [Route("studentStore")]
        public async Task<bool> InsertStudentAsync(StudentModel student)
        {
            var response = await _studentService.InsertStudentAsync(student);
            return response;
        }

        [HttpPut]
        [Route("studentUpdate")]
        public bool UpdateStudent(StudentModel student)
        {
            var response = _studentService.UpdateStudent(student);
            return response;
        }

        [HttpDelete]
        [Route("studentDelete/{studentId}")]
        public bool DeleteStudent(int studentId)
        {
            var response = _studentService.DeleteStudent(studentId);
            return response;
        }
    }
}