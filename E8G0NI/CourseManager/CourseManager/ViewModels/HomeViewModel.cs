using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseManager.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand AddCourse { get; }
        public ICommand ViewCourses { get; }
        public ICommand DeleteCourse { get; }

        public HomeViewModel()
        {

        }
    }
}
