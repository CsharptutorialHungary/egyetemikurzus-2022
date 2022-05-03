using CourseManager.Commands;
using CourseManager.Models;
using CourseManager.Services;
using CourseManager.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseManager.ViewModels
{
    public class CreateCourseViewModel : ViewModelBase
    {
        private string _code;
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                OnPropertyChanged(nameof(Code));
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _lecturer;
        public string Lecturer
        {
            get
            {
                return _lecturer;
            }
            set
            {
                _lecturer = value;
                OnPropertyChanged(nameof(Lecturer));
            }
        }

        private string _language;
        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
                OnPropertyChanged(nameof(Language));
            }
        }

        private int _credit;
        public int Credit
        {
            get
            {
                return _credit;
            }
            set
            {
                _credit = value;
                OnPropertyChanged(nameof(Credit));
            }
        }

        private int _limit;
        public int Limit
        {
            get
            {
                return _limit;
            }
            set
            {
                _limit = value;
                OnPropertyChanged(nameof(Limit));
            }
        }

        private string _description = "";
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public CreateCourseViewModel(CourseModel course, NavigationService courseViewNavigationService)
        {
            SubmitCommand = new CreateCourseCommand(this, course, courseViewNavigationService);
            CancelCommand = new NavigateCommand(courseViewNavigationService);
        }
    }
}
