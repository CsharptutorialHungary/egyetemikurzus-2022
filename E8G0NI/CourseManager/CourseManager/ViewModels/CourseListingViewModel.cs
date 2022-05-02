using CourseManager.Commands;
using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseManager.ViewModels
{
    public class CourseListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<CourseViewModel> _courses;

        public IEnumerable<CourseViewModel> Courses => _courses;

        public ICommand CancelCommand { get; }
        public ICommand ListHungarianCourses { get; }
        public ICommand ListEnglishCourses { get; }
        public ICommand ListMaxCredit { get; }
        public ICommand ListMaxLimit { get; }

        public ObservableCollection<string> Languages = new ObservableCollection<string>()
        {
            "Hungarian",
            "English"
        };

        public CourseListingViewModel()
        {
            _courses = new ObservableCollection<CourseViewModel>();

            CancelCommand = new NavigateCommand();

            _courses.Add(new CourseViewModel(new CourseModel("IB500g", "Programozás Alapjai", "Nagy József", 4, 60, "Hungarian", "")));
            _courses.Add(new CourseViewModel(new CourseModel("IB500gEN", "Programming Basics", "John Doe", 4, 60, "English", "")));
        }
    }
}
