using CourseManager.Models;
using CourseManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
