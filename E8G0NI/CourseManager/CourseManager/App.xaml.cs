using CourseManager.Models;
using CourseManager.Stores;
using CourseManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CourseManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly CourseModel _course;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _course = new CourseModel("IB500g", "Programming Basics", "Nagy József", 4, 60, "Hungarian", "");
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // starting view
            _navigationStore.CurrentViewModel = CreateCourseListingViewModel();

            // CourseModel course = new CourseModel("IB500g", "Programming Basics", "Nagy József", 4, 60, "Hungarian", "");
            // MessageBox.Show(course.Name);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private CreateCourseViewModel CreateCreateCourseViewModel()
        {
            return new CreateCourseViewModel(_course, _navigationStore, CreateCourseListingViewModel);
        }

        private CourseListingViewModel CreateCourseListingViewModel()
        {
            return new CourseListingViewModel(_navigationStore, CreateCreateCourseViewModel);
        }

        //private HomeViewModel CreateHomeViewModel()
        //{
        //    return new HomeViewModel(_navigationStore, HomeViewModel);
        //}
    }
}
