using AutoMapper;
using StudentManagement.Data;
using StudentManagement.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapping from Domain Model to Entity Model and vice versa
            CreateMap<Student, StudentModel>();
            CreateMap<StudentModel, Student>();
        }

    }
}
