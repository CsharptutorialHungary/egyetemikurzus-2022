using CourseManager.Models;
using CourseManager.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseManager.Commands
{
    public class CreateCourseCommand : CommandBase
    {
        private readonly CreateCourseViewModel _createCourseViewModel;
        private readonly CourseModel _course;

        public CreateCourseCommand(CreateCourseViewModel createCourseViewModel, CourseModel courseModel)
        {
            _createCourseViewModel = createCourseViewModel;
            _course = courseModel;

            _createCourseViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_createCourseViewModel.Code) && 
                !string.IsNullOrEmpty(_createCourseViewModel.Name) &&
                !string.IsNullOrEmpty(_createCourseViewModel.Lecturer) &&
                _createCourseViewModel.Credit > 0 &&
                _createCourseViewModel.Limit > 0 &&
                !string.IsNullOrEmpty(_createCourseViewModel.Language) &&
                base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            CourseModel course = new CourseModel(_createCourseViewModel.Code, 
                _createCourseViewModel.Name,
                _createCourseViewModel.Lecturer,
                _createCourseViewModel.Credit,
                _createCourseViewModel.Limit,
                _createCourseViewModel.Language,
                _createCourseViewModel.Description);

            MessageBox.Show("Created course successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CourseViewModel.Code) ||
                e.PropertyName == nameof(CourseViewModel.Name) ||
                e.PropertyName == nameof(CourseViewModel.Lecturer) ||
                e.PropertyName == nameof(CourseViewModel.Credit) ||
                e.PropertyName == nameof(CourseViewModel.Limit) ||
                e.PropertyName == nameof(CourseViewModel.Language))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
