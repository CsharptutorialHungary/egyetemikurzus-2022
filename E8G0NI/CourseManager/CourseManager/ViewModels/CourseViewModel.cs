using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.ViewModels
{
    public class CourseViewModel : ViewModelBase
    {
        private readonly CourseModel _course;

        public string Code => _course.Code;
        public string Name => _course.Name;
        public string Lecturer => _course.Lecturer;
        public int Credit => _course.Credit;
        public int Limit => _course.Limit;
        public string Language => _course.Language;

        public CourseViewModel(CourseModel course)
        {
            _course = course;
        }
    }
}
