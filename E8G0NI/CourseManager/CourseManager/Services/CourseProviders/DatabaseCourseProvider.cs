using CourseManager.DbContexts;
using CourseManager.DTOs;
using CourseManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Services.CourseProviders
{
    public class DatabaseCourseProvider : ICourseProvider
    {
        private readonly CourseDbContextFactory _dbContextFactory;

        public DatabaseCourseProvider(CourseDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<CourseModel>> GetAllCourses()
        {
            using (CourseDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<CourseDTO> courseDTOs = await context.Courses.ToListAsync();

                return courseDTOs.Select(c => ToCourse(c));
            }
        }

        private static CourseModel ToCourse(CourseDTO dto)
        {
            return new CourseModel(dto.Code, dto.Name, dto.Lecturer, dto.Credit, dto.Limit, dto.Language, dto.Description);
        }
    }
}
