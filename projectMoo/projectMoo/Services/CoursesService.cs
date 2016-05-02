using projectMoo.Models;
using projectMoo.Models.Entities;
using projectMoo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectMoo.Services
{
    public class CoursesService
    {
        private ApplicationDbContext _db;

        public CoursesService()
        {
            _db = new ApplicationDbContext();
        }

        public List<CourseViewModel> getCoursesForUser(string userId)
        {
            var links = (from courseRelation in _db.UserCourses
                               where courseRelation.UserID == userId
                               select courseRelation).ToList();

            List<Course> courses = new List<Course>();

            List<CourseViewModel> coursesViewModel = new List<CourseViewModel>();


            foreach ( UserCourse c in links)
            {
                Course userCourse = (from storedCourse in _db.Courses
                              where storedCourse.ID == c.CourseID
                              select storedCourse).SingleOrDefault();

                courses.Add(userCourse);

            }

            foreach (Course c in courses)
            {
                coursesViewModel.Add(new CourseViewModel
                {
                    Title = c.Title,
                    Description = c.Description,
                    Assignments = null
                });
            }

            return coursesViewModel;
        }
    }
}