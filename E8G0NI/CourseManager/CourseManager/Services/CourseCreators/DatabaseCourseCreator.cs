using CourseManager.DbContexts;
using CourseManager.DTOs;
using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Services.CourseCreators
{
    public class DatabaseCourseCreator : ICourseCreator
    {
        private readonly CourseDbContextFactory _dbContextFactory;

        public DatabaseCourseCreator(CourseDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateCourse(CourseModel course)
        {
            using (CourseDbContext context = _dbContextFactory.CreateDbContext())
            {
                CourseDTO courseDTO = ToCourseDTO(course);

                context.Courses.Add(courseDTO);
                await context.SaveChangesAsync();
            }
        }

        private CourseDTO ToCourseDTO(CourseModel course)
        {
            return new CourseDTO()
            {
                Code = course.Code,
                Name = course.Name,
                Lecturer = course.Lecturer,
                Credit = course.Credit,
                Limit = course.Limit,
                Language = course.Language,
                Description = course.Description,
            };
        }
    }
}
