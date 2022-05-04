using Microsoft.EntityFrameworkCore;
using CourseManager.DbContexts;
using CourseManager.DTOs;
using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Services.CourseConflictValidators
{
    public class DatabaseCourseConflictValidator : ICourseConflictValidator
    {
        private readonly CourseDbContextFactory _dbContextFactory;

        public DatabaseCourseConflictValidator(CourseDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<CourseModel?> GetConflictingCourse(CourseModel course)
        {
            using (CourseDbContext context = _dbContextFactory.CreateDbContext())
            {
                CourseDTO courseDTO = (CourseDTO)context.Courses
                    .Where(c => c.Code == course.Code);

                if (courseDTO == null)
                {
                    return null;
                }

                return ToCourse(courseDTO);
            }
        }

        private static CourseModel ToCourse(CourseDTO dto)
        {
            return new CourseModel(dto.Code, dto.Name, dto.Lecturer, dto.Credit, dto.Limit, dto.Language, dto.Description);
        }
    }
}
