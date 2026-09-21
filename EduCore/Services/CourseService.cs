using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using EduCore.Data;
using EduCore.DTO;
using EduCore.Models;
using EduCore.Repository;
using EduCore.ViewModels;
using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EduCore.Services
{
    public class CourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly DepartmentService _departmentService;
        private readonly InstructorService _instructorService;

        public CourseService(ICourseRepository courseRepository , 
            DepartmentService departmentService ,
            InstructorService instructorService) {
            _courseRepository = courseRepository;
            _departmentService = departmentService;
            _instructorService = instructorService;
        }

        public List<Course>? GetAll()
        {
            if (_courseRepository.Exist())
                return _courseRepository.GetAll();
            else return null;
        }

       public List<Course>? Pagination(int PageNumber)
        {
            const int pageSize = 2;
            if (_courseRepository.Exist())
                return _courseRepository.GetPage(PageNumber, pageSize);
            else return null;
        }

        public Course? GetCourseById(int id)
        {
            return _courseRepository.GetById(id);
        }


        public void AddCourse(AddCoursesViewModel CourseFromReq)
        {
            var course = new Course()
            {
                Name = CourseFromReq.Name,
                Degree = CourseFromReq.Degree,
                minDegree = CourseFromReq.minDegree,
                Hourse = CourseFromReq.Hourse,
                deptId = CourseFromReq.DeptId
            };
           _courseRepository.Add(course);
            _courseRepository.Save();
        }

        public void UpdateCourse(Course crs)
        {
            _courseRepository.Update(crs);
            _courseRepository.Save();
        }
        public void DeleteCourse(int id)
        {
                _courseRepository.Delete(id);
                _courseRepository.Save();
        }

        public bool Exist(int id)
        {
            return _courseRepository.Exist(id);
        }
        public bool Exist()
        {
            return _courseRepository.Exist();
        }

        public DisplayCourseWithItsTraineeResults? CourseTraineesDegreesById(int crsId)
        {
            
            var course = _courseRepository.GetById(crsId);
            
            if (course is null) 
                return null;
            return _courseRepository.GetCourseWithTraineeResults(course);
         
        }

        public List<CoursesDataByDepartmetnDTO>? CoursesByDeptId(int deptId)
        {
            if (_departmentService.Exist(deptId))
                return _courseRepository.GetCoursesByDeptId(deptId);
            else return null;
        }

        public bool AssignInstructor(AssignInstructorViewModel data)
        {
            var course = _courseRepository.GetById(data.CourseId);
            var instructor = _instructorService.GetById(data.InstructorId);
            if (course is null || instructor is null)
                return false;
            course.instructors.Add(instructor);
            return true;
        }

        public void Save()
        {
            _courseRepository.Save();
        }
    }
}
