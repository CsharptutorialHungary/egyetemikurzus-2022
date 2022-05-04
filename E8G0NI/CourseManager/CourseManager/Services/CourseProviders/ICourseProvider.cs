using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Services.CourseProviders
{
    public interface ICourseProvider
    {
        Task<IEnumerable<CourseModel>> GetAllCourses();
    }
}
