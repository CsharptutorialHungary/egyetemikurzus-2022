using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.DbContexts
{
    public class CourseDbContextFactory
    {
        private readonly string _connectionString;

        public CourseDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CourseDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
            return new CourseDbContext(options);
        }
    }
}
